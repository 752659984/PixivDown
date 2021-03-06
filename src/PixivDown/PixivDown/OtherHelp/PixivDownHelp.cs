﻿using Command;
using Command.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PixivDown
{
    public class PixivDownHelp
    {
        public Thread mainThread { get; set; }
        public Multithreading mut { get; set; }
        public bool isSumThread { get; set; }
        public string getType { get; set; }
        public IBaseForm form { get; set; }
        public bool isSingle { get; set; }
        private int count;
        public int Sleep { get; set; }

        private void InitControl(IBaseForm b, Form f)
        {
            var type = typeof(IBaseForm);
            var ps = type.GetProperties();
            foreach (var p in ps)
            {
                var name = p.Name[0].ToString().ToLower() + p.Name.Substring(1);
                var cs = f.Controls.Find(name, false);
                if (cs.Length > 0)
                {
                    p.SetValue(b, cs[0]);
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public PixivDownHelp(IBaseForm b, Form f, bool isSingle)
        {
            InitControl(b, f);
            this.form = b;
            //this.form = new BaseForm();//这个不行
            this.isSumThread = false;
            this.getType = "";
            this.mut = null;
            this.mainThread = null;
            this.isSingle = isSingle;
            this.count = 0;
            this.Sleep = 0;
        }

        #region 通用遍历列表

        /// <summary>
        /// 遍历列表页面，获取所有子项目，并自动获取下一页
        /// </summary>
        /// <param name="listUrl"></param>
        /// <param name="type"></param>
        /// <param name="doWork"></param>
        private void EachListPage(string listUrl, DownContentType type, Action<string> doWork)
        {
            try
            {
                while (mut.IsContinue)
                {

                    if (isSingle)
                    {
                        form.Invoke(new Action(() => { form.RtxtSuccess.Text = ""; form.TxtCurrListUrl.Text = listUrl; }));
                    }

                    AddSuccessMsg(string.Format("正在获取URL：{0} 的html！\r\n", listUrl));

                    var html = DownHelp.GetHtmlString(listUrl, Encoding.UTF8, 5);
                    if (html == "")
                    {
                        AddErrorMsg(string.Format("获取URL：{0} 的html失败！\r\n", listUrl));
                        return;
                    }

                    AddSuccessMsg(string.Format("获取URL：{0} 的html成功！\r\n", listUrl));

                    Regex pReg = new Regex(RegexHelp.GetRegex(type, RegexType.ListParentRegex), RegexOptions.Singleline);
                    var pm = pReg.Match(html);
                    if (pm == null || pm.Value == "")
                    {
                        AddErrorMsg(string.Format("获取URL：{0} 的父容器失败！\r\n", listUrl));
                        return;
                    }

                    var pHtml = pm.Value;

                    Regex lReg = new Regex(RegexHelp.GetRegex(type, RegexType.ListRegex), RegexOptions.Singleline);
                    var lms = lReg.Matches(pHtml);
                    if (lms == null || lms.Count <= 0)
                    {
                        AddErrorMsg(string.Format("获取URL：{0} 子项目失败！\r\n", listUrl));
                        return;
                    }

                    foreach (Match item in lms)
                    {
                        if (!mut.IsContinue)
                            return;

                        var itemUrl = item.Groups["Url"].Value;

                        doWork(itemUrl);
                    }

                    if (!mut.IsContinue)
                        return;

                    Regex nReg = new Regex(RegexHelp.GetRegex(type, RegexType.NextListRegex), RegexOptions.Singleline);
                    var nm = nReg.Match(html);
                    if (nm == null || nm.Groups["Next"].Value == "")
                    {
                        AddErrorMsg(string.Format("没有在：{0} 中获取到下一页！\r\n", listUrl));
                        form.Invoke(new Action(() =>
                        {
                            if (form.RadAllFollow.Checked && type == DownContentType.AllFollow)
                            {
                                form.LblOtherText.Text = string.Format("关注的{0}公开的画师已没有一下页！", getType == "show" ? "" : "非");
                            }
                            else if (form.RadSingle.Checked && type == DownContentType.SinglePainter)
                            {
                                form.LblOtherText.Text = "当前画师作品已没有一下页！";
                            }
                            else if (form.RadCollection.Checked && type == DownContentType.OwnCollection)
                            {
                                if (getType == "show" || getType == "hide")
                                {
                                    form.LblOtherText.Text = string.Format("收藏的{0}公开的作品已没有一下页！", getType == "show" ? "" : "非");
                                }
                                else
                                {
                                    form.LblOtherText.Text = string.Format("画师{0}收藏的作品已没有一下页！", getType);
                                }
                            }
                            else if (form.RadCollection.Checked && type == DownContentType.GetSearch)
                            {
                                form.LblOtherText.Text = string.Format("搜索的内容已没有一下页！");
                            }
                        }));
                        return;
                    }

                    var nextUrl = HtmlHelp.NeedHost(listUrl, nm.Groups["Next"].Value);
                    //EachListPage(nextUrl, type, doWork);
                    listUrl = nextUrl;
                    AddSuccessMsg(string.Format("正在获取下一页：{0}！\r\n", listUrl));
                }
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
        }



        /// <summary>
        /// 获取单个作品
        /// </summary>
        /// <param name="objParame"></param>
        public void GetSingleWorks(object objParame)
        {
            try
            {
                if (!mut.IsContinue)
                    return;

                //因为循环里没有做修改，所有可以放外面
                var parame = (RequestParameEntity)objParame;

                form.BeginInvoke(new Action(() => { form.RtxtSuccess.Text = ""; }));

                var ri = new RequestItemParameEntity() { ItemUrl = parame.ListUrl, SavePath = parame.SavePath };
                
                GetWorksItem(ri);

                if (parame.DownRelatedWorks)
                {
                    GetRelatedWorks(objParame);
                }
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                if (mainThread != null && mainThread.IsAlive)
                {
                    mainThread.Abort();
                }
            }
        }




        /// <summary>
        /// 获取单个画师，只能由DoGetThread执行
        /// </summary>
        /// <param name="listUrl">画师作品列表页</param>
        public void GetSingle(object objParame)
        {
            try
            {
                if (!mut.IsContinue)
                    return;

                //因为循环里没有做修改，所有可以放外面
                var parame = (RequestParameEntity)objParame;

                form.BeginInvoke(new Action(() => { form.RtxtSuccess.Text = ""; }));

                if (isSingle)
                {
                    form.Invoke(new Action(() => { form.TxtSavePath.Text = parame.SavePath; }));
                }

                EachListPage(parame.ListUrl, DownContentType.SinglePainter, new Action<string>(itemUrl =>
                {
                    if (!mut.IsContinue)
                        return;

                    itemUrl = HtmlHelp.NeedHost(parame.ListUrl, itemUrl);

                    var ri = new RequestItemParameEntity() { ItemUrl = itemUrl, SavePath = parame.SavePath };

                    if (isSingle)
                    {
                        GetWorksItem(ri);
                    }
                    else
                    {
                        while (!mut.DoDownAction(ri, GetWorksItem) && mut.IsContinue)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                if (!isSingle)
                {
                    mut.RemoveGThread();
                }
            }
        }





        /// <summary>
        /// 【暂不开发】检查画师最后的那个作品是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CheckDone(string id)
        {
            return true;
        }

        /// <summary>
        /// 根据画师ID获取完整的列表网址，只能由mainThread执行
        /// </summary>
        /// <param name="id">画师id</param>
        /// <returns></returns>
        private string GetListUrlByID(string id, string savePath)
        {
            lock (Multithreading.ObjLockExistFile)
            {
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                else if (form.RadDupDir.Checked || (form.RadDupLast.Checked && CheckDone(id)))
                {
                    //1、仅根据ID
                    //2、根据最后一张图片判断，可能不准确
                    if (form.ChkNeglect.Checked)
                    {
                        AddErrorMsg(string.Format("略过{0}，因为已经存在！\r\n", id));
                    }
                    return "";
                }
                else
                {
                    //radDupNot.Checked
                    //不去重，只会判断是否已下载图片，没下载的图片就会下载
                }
            }

            AddSuccessMsg(string.Format("开始获取{0}的作品！\r\n", id));

            return "https://www.pixiv.net/member_illust.php?id=" + id;
        }

        /// <summary>
        /// 根据type获取关注的画师，只能由mainThread执行
        /// </summary>
        /// <param name="reqParame"></param>
        /// <param name="type"></param>
        private void GetAllFollowByType(RequestParameEntity reqParame, string type)
        {
            getType = type;

            string paListUrl = string.Format("https://www.pixiv.net/bookmark.php?type=user&rest={0}&p=1", type);
            EachListPage(paListUrl, DownContentType.AllFollow, new Action<string>(id =>
            {
                if (!mut.IsContinue)
                    return;

                //因为是引用类型，所以要复制
                var parame = (RequestParameEntity)reqParame.Clone();

                //因为这里是遍历集合，所以不能只用SavePath
                parame.SavePath = parame.ParentPath + "/" + id;
                parame.SavePath = parame.SavePath.Replace("\\", "/").Replace("//", "/");
                var listUrl = GetListUrlByID(id, parame.SavePath);
                if (listUrl != "")
                {
                    //列表Url从关注列表Url变为某个画师的作品列表Url
                    parame.ListUrl = listUrl;

                    if (isSingle)
                    {
                        GetSingle(parame);
                    }
                    else
                    {
                        while (!mut.DoGetAction(parame, GetSingle) && mut.IsContinue)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
            }));
        }

        /// <summary>
        /// 获取所有关注的画师，只能由mainThread执行
        /// </summary>
        public void GetAllFollow(object objParame)
        {
            try
            {
                GetAllFollowByType((RequestParameEntity)objParame, "show");
                GetAllFollowByType((RequestParameEntity)objParame, "hide");
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                if (mainThread != null && mainThread.IsAlive)
                {
                    mainThread.Abort();
                }
            }
        }





        /// <summary>
        /// 根据Type获取自己的收藏，只能由mainThread执行
        /// </summary>
        /// <param name="reParame"></param>
        /// <param name="type"></param>
        private void GetCollectionByType(RequestParameEntity reParame, string type, string url)
        {
            getType = type;

            var listUrl = url + type;
            EachListPage(listUrl, DownContentType.OwnCollection, new Action<string>(itemUrl =>
            {
                if (!mut.IsContinue)
                    return;

                itemUrl = HtmlHelp.NeedHost(listUrl, itemUrl);

                var ri = new RequestItemParameEntity() { ItemUrl = itemUrl, SavePath = reParame.SavePath };

                if (isSingle)
                {
                    GetWorksItem(ri);
                }
                else
                {
                    while (!mut.DoDownAction(ri, GetWorksItem) && mut.IsContinue)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }));
        }

        /// <summary>
        /// 获取自己的收藏，只能由mainThread执行
        /// </summary>
        public void GetCollection(object objParame)
        {
            try
            {
                var parame = (RequestParameEntity)objParame;

                GetCollectionByType(parame, "show", "https://www.pixiv.net/bookmark.php?rest=");
                GetCollectionByType(parame, "hide", "https://www.pixiv.net/bookmark.php?rest=");
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                if (mainThread != null && mainThread.IsAlive)
                {
                    mainThread.Abort();
                }
            }
        }


        /// <summary>
        /// 下载指定画师的收藏
        /// </summary>
        /// <param name="objParame"></param>
        public void GetAuthorCollection(object objParame)
        {
            try
            {
                var parame = (RequestParameEntity)objParame;

                GetCollectionByType(parame, parame.ID, "https://www.pixiv.net/bookmark.php?id=");
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                if (mainThread != null && mainThread.IsAlive)
                {
                    mainThread.Abort();
                }
            }
        }




        /// <summary>
        /// 下载搜索
        /// Url 必须是完整的地址，只能由mainThread执行
        /// </summary>
        /// <param name="objParame"></param>
        public void GetSearch(object objParame)
        {
            try
            {
                var parame = (RequestParameEntity)objParame;
                EachListPage(parame.ListUrl, DownContentType.GetSearch, new Action<string>(itemUrl =>
                {
                    if (!mut.IsContinue)
                        return;

                    itemUrl = "/member_illust.php?mode=medium&illust_id=" + itemUrl;
                    itemUrl = HtmlHelp.NeedHost(parame.ListUrl, itemUrl);

                    //都下载同一个地方，不用克隆
                    var ri = new RequestItemParameEntity() { ItemUrl = itemUrl, SavePath = parame.SavePath };

                    if (isSingle)
                    {
                        GetWorksItem(ri);
                    }
                    else
                    {
                        while (!mut.DoDownAction(ri, GetWorksItem) && mut.IsContinue)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                if (mainThread != null && mainThread.IsAlive)
                {
                    mainThread.Abort();
                }
            }
        }





        /// <summary>
        /// 获取相关作品ID集合
        /// </summary>
        /// <param name="html"></param>
        /// <param name="regStr"></param>
        /// <returns></returns>
        public string[] GetRelatedWorks(string html, string regStr)
        {
            var regFirstIds = new Regex(regStr, RegexOptions.Singleline);
            var mFirstIds = regFirstIds.Matches(html);
            if (mFirstIds != null && mFirstIds.Count > 0)
            {
                var result = new string[mFirstIds.Count];
                for (int i = 0; i < mFirstIds.Count; i++)
                {
                    result[i] = mFirstIds[i].Groups["ID"].Value;
                }
                return result;
            }

            return null;
        }

        /// <summary>
        /// 获取某个作品的相关作品
        /// </summary>
        /// <param name="parame"></param>
        /// <returns></returns>
        public List<string> GetRelatedWorksIds(RequestParameEntity parame)
        {
            var itemUrl = parame.ListUrl;
            var id = parame.ID;
            var result = new List<string>();

            //获取相关作品请求参数
            var limitUrl = $"https://www.pixiv.net/ajax/illust/{id}/recommend/init?limit=18";

            var limitHtml = DownHelp.GetHtmlString(limitUrl, Encoding.UTF8, 5);
            if (limitHtml == "")
            {
                AddErrorMsg(string.Format("获取URL：{0} 的html失败！\r\n", limitUrl));
                return null;
            }
            AddSuccessMsg(string.Format("获取URL：{0} 的html成功！\r\n", limitUrl));

            var firstIds = GetRelatedWorks(limitHtml, RegexHelp.Other.GetFirstIds);
            result.AddRange(firstIds);

            var regNext = new Regex(RegexHelp.Other.GetNextIdsParent, RegexOptions.Singleline);
            var mNext = regNext.Match(limitHtml);
            if (mNext != null && mNext.Groups["Main"].Value != "")
            {
                var secondIds = GetRelatedWorks(mNext.Groups["Main"].Value, RegexHelp.Other.GetNextIds);
                result.AddRange(secondIds);
            }

            return result;
        }

        /// <summary>
        /// 下载相关作品
        /// </summary>
        /// <param name="objParame"></param>
        public void GetRelatedWorks(object objParame)
        {
            try
            {
                var parame = (RequestParameEntity)objParame;
                var ids = GetRelatedWorksIds(parame);
                if (ids != null && ids.Count > 0)
                {
                    foreach (var id in ids)
                    {
                        var itemUrl = "https://www.pixiv.net/member_illust.php?mode=medium&illust_id=" + id;
                        var ri = new RequestItemParameEntity() { ItemUrl = itemUrl, SavePath = parame.SavePath };

                        if (isSingle)
                        {
                            GetWorksItem(ri);
                        }
                        else
                        {
                            while (!mut.DoDownAction(ri, GetWorksItem) && mut.IsContinue)
                            {
                                Thread.Sleep(1000);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddErrorMsg(ex.Message + "\r\n");
                HtmlHelp.SaveStringToTxt(ex.Message + "\r\n" + ex.StackTrace + "\r\n\r\n", "Error.txt");
            }
            finally
            {
                //if (mainThread != null && mainThread.IsAlive)
                //{
                //    mainThread.Abort();
                //}
            }
        }

        #endregion 通用遍历列表

        #region 获取画师方法，只能由DoDownThread执行

        /// <summary>
        /// 根据作品的网址获取作品
        /// </summary>
        /// <param name="itemUrl">作品url</param>
        public void GetWorksItem(object objParame)
        {
            try
            {
                var parame = (RequestItemParameEntity)objParame;
                var itemUrl = parame.ItemUrl;
                var savePath = parame.SavePath;
                var index = itemUrl.IndexOf("id=");
                if (index < 0)
                {
                    AddErrorMsg(string.Format("获取URL：{0} 的id失败！\r\n", itemUrl));
                    return;
                }
                //作品id
                var pid = itemUrl.Substring(index + 3);

                if (isSingle)
                {
                    form.Invoke(new Action(() => { form.TxtItemUrl.Text = itemUrl; }));
                }

                AddSuccessMsg(string.Format("正在获取URL：{0} 的html！\r\n", itemUrl));

                //获取作品页的html
                var html = DownHelp.GetHtmlString(itemUrl, Encoding.UTF8, 5);
                if (html == "")
                {
                    AddErrorMsg(string.Format("获取URL：{0} 的html失败！\r\n", itemUrl));
                    return;
                }
                AddSuccessMsg(string.Format("获取URL：{0} 的html成功！\r\n", itemUrl));

                //获取作品的类型
                var tReg = new Regex(RegexHelp.Other.GetIllustType, RegexOptions.Singleline);
                var tm = tReg.Match(html);
                if (tm == null || tm.Groups["T"].Value == "")
                {
                    AddErrorMsg(string.Format("获取URL：{0} 的类型失败！\r\n", itemUrl));
                    return;
                }
                var t = tm.Groups["T"].Value;

                if (t == "2")
                {
                    //动图
                    GetCanvasZipFile(itemUrl, savePath, pid);
                }
                else
                {
                    //单图或多图
                    //获取图片数量，以判别时单张还是多张
                    var pReg = new Regex(RegexHelp.Other.GetItemPageCount, RegexOptions.Singleline);
                    var pm = pReg.Match(html);
                    if (pm == null || pm.Groups["P"].Value == "")
                    {
                        AddErrorMsg(string.Format("获取URL：{0} 的作品的子页数失败！\r\n", itemUrl));
                        return;
                    }
                    var pageCount = int.Parse(pm.Groups["P"].Value);

                    //判断是只有单个还是有查看更多
                    if (pageCount > 1)
                    {
                        var moreUrl = "https://www.pixiv.net/member_illust.php?mode=manga&illust_id=" + pid;

                        GetMoreImage(moreUrl, savePath);
                    }
                    else
                    {
                        GetSigImage(itemUrl, html, savePath);
                    }
                }

                Thread.Sleep(Sleep);
            }
            catch (Exception e)
            {
                AddErrorMsg(e.Message + "\r\n");
            }
            finally
            {
                if (!isSingle)
                {
                    mut.RemoveDThread();
                }
            }
        }


        /// <summary>
        /// 获取更多图片
        /// </summary>
        /// <param name="moreUrl">查看更多Url</param>
        public void GetMoreImage(string moreUrl, string savePath)
        {
            AddSuccessMsg(string.Format("正在获取URL：{0} 的html！\r\n", moreUrl));

            var html = DownHelp.GetHtmlString(moreUrl, Encoding.UTF8, 5);
            if (html == "")
            {
                AddErrorMsg(string.Format("获取URL：{0} 的html失败！\r\n", moreUrl));
                return;
            }

            AddSuccessMsg(string.Format("获取URL：{0} 的html成功！\r\n", moreUrl));


            //获取放大镜集合
            var mReg = new Regex(RegexHelp.Other.GetMaxButton, RegexOptions.Singleline);
            var mms = mReg.Matches(html);
            if (mms != null && mms.Count > 0)
            {
                //获取放大后的图片
                foreach (Match m in mms)
                {
                    var mUrl = m.Groups["Url"].Value;
                    mUrl = HtmlHelp.NeedHost(moreUrl, mUrl);
                    var mHtml = DownHelp.GetHtmlString(mUrl, Encoding.UTF8, 5);

                    var mmReg = new Regex(RegexHelp.Other.GetImageWhenMax, RegexOptions.Singleline);
                    var mmm = mmReg.Match(mHtml);
                    if (mmm == null || mmm.Groups["Url"].Value == "")
                    {
                        AddErrorMsg(string.Format("获取URL：{0} 的图片失败！\r\n", mUrl));
                        return;
                    }

                    var imgUrl = HtmlHelp.NeedHost(mUrl, mmm.Groups["Url"].Value);

                    lock (Multithreading.ObjLockExistFile)
                    {
                        if (File.Exists(savePath + "/" + Path.GetFileName(imgUrl)))
                        {
                            if (form.ChkNeglect.Checked)
                            {
                                AddErrorMsg(string.Format("跳过已存在的图片：{0}！\r\n", imgUrl));
                            }
                            continue;
                        }
                    }

                    AddSuccessMsg(string.Format("正在下载图片：{0} \r\n", imgUrl));
                    var filePath = savePath + "/" + Path.GetFileName(imgUrl);
                    bool b = DownHelp.DownImage(imgUrl, filePath, 1024, moreUrl, 5);

                    if (b)
                        AddSuccessMsg(string.Format("下载图片：{0} 成功\r\n", imgUrl));
                    else
                    {
                        var txt = string.Format("下载图片：{0} 失败\r\n Url：{1}\r\n", imgUrl, moreUrl);
                        AddErrorMsg(txt);
                        HtmlHelp.SaveStringToTxt(txt, "FaildMsg.txt");
                    }
                }
            }
            else
            {
                AddErrorMsg(string.Format("没有获取到放大镜集合：{0}！\r\n", moreUrl));
                return;
                //直接获取图片
                var msReg = new Regex(RegexHelp.Other.GetImageWhenNotMax, RegexOptions.Singleline);
                var imgMs = msReg.Matches(html);

                foreach (Match m in imgMs)
                {
                    var imgUrl = m.Groups["Url"].Value;
                    imgUrl = HtmlHelp.NeedHost(moreUrl, imgUrl);

                    lock (Multithreading.ObjLockExistFile)
                    {
                        if (File.Exists(savePath + "/" + Path.GetFileName(imgUrl)))
                        {
                            if (form.ChkNeglect.Checked)
                            {
                                AddErrorMsg(string.Format("跳过已存在的图片：{0}！\r\n", imgUrl));
                            }
                            continue;
                        }
                    }

                    AddSuccessMsg(string.Format("正在下载图片：{0} \r\n", imgUrl));
                    
                    var filePath = savePath + "/" + Path.GetFileName(imgUrl);
                    bool b = DownHelp.DownImage(imgUrl, filePath, 1024, moreUrl, 5);

                    if (b)
                        AddSuccessMsg(string.Format("下载图片：{0} 成功\r\n", imgUrl));
                    else
                    {
                        var txt = string.Format("下载图片：{0} 失败\r\n Url：{1}\r\n", imgUrl, moreUrl);
                        AddErrorMsg(txt);
                        HtmlHelp.SaveStringToTxt(txt, "FaildMsg.txt");
                    }
                }
            }
        }


        /// <summary>
        /// 获取单个图片
        /// </summary>
        /// <param name="itemUrl"></param>
        /// <param name="html"></param>
        public void GetSigImage(string itemUrl, string html, string savePath)
        {
            var imgR = new Regex(RegexHelp.Other.GetSingleImage, RegexOptions.Singleline);
            var imgM = imgR.Match(html);

            if (imgM == null || imgM.Groups["Url"].Value == "")
            {
                AddErrorMsg(string.Format("获取URL：{0} 的图片失败！\r\n", itemUrl));
                return;
            }

            var imgUrl = HtmlHelp.NeedHost(itemUrl, imgM.Groups["Url"].Value);

            lock (Multithreading.ObjLockExistFile)
            {
                if (File.Exists(savePath + "/" + Path.GetFileName(imgUrl)))
                {
                    if (form.ChkNeglect.Checked)
                    {
                        AddErrorMsg(string.Format("跳过已存在的图片：{0}！\r\n", imgUrl));
                    }
                    return;
                }
            }

            AddSuccessMsg(string.Format("正在下载图片：{0} \r\n", imgUrl));

            var filePath = savePath + "/" + Path.GetFileName(imgUrl);
            bool b = DownHelp.DownImage(imgUrl, filePath, 1024, itemUrl, 5);

            if (b)
                AddSuccessMsg(string.Format("下载图片：{0} 成功\r\n", imgUrl));
            else
            {
                var txt = string.Format("下载图片：{0} 失败\r\n Url：{1}\r\n", imgUrl, itemUrl);
                AddErrorMsg(txt);
                HtmlHelp.SaveStringToTxt(txt, "FaildMsg.txt");
            }
        }



        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="objParame"></param>
        public void UnZipFile(object objParame)
        {
            var parame = (Dictionary<string, string>)objParame;
            var savePath = parame["SavePath"].Replace("\\", "/").Replace("//", "/");
            var fileUrl = parame["FileUrl"].Replace("\\", "/").Replace("//", "/");
            var fileName = parame["FileName"].Replace("\\", "/").Replace("//", "/");
            var delay = parame["Delay"];

            //将文件解压
            var zipDir = savePath + "/" + Path.GetFileNameWithoutExtension(fileUrl);

            try
            {
                ZipHelp.ExtractToDirectory(fileName, zipDir);

                //将文件解压后的文件夹中的图片转为GIF
                var fs = Directory.GetFiles(zipDir);
                GifHelp.ImageToGif(fs, zipDir + ".gif", int.Parse(delay));
            }
            catch (Exception ex)
            {
                AddErrorMsg(string.Format("解压文件{0}失败！\r\n{1}\r\n", fileName, ex.Message));
                HtmlHelp.SaveStringToTxt(ex.StackTrace + "\r\n", "Error.txt");
            }
            finally
            {
                mut.DisposeUnZipThread();
            }
        }

        /// <summary>
        /// 获取指定作品的动画
        /// </summary>
        public void GetCanvasZipFile(string itemUrl, string savePath, string pid)
        {
            //可以获取zip的url
            var zipHtmlUrl = string.Format("https://www.pixiv.net/ajax/illust/{0}/ugoira_meta", pid);

            var html = DownHelp.GetHtmlString(zipHtmlUrl, Encoding.UTF8, 5);
            var fReg = new Regex(RegexHelp.Other.GetAnimation, RegexOptions.Singleline);
            var fM = fReg.Match(html);

            if (fM == null || fM.Groups["Url"].Value == "")
            {
                AddErrorMsg(string.Format("获取 {0} 的动画失败！\r\n", itemUrl));
                return;
            }

            //zip的Url路径
            var fileUrl = fM.Groups["Url"].Value.Replace("\\/", "/");

            //zip文件名
            var fileName = savePath + "/" + Path.GetFileName(fileUrl);
            lock (Multithreading.ObjLockExistFile)
            {
                if (File.Exists(fileName))
                {
                    if (form.ChkNeglect.Checked)
                    {
                        AddErrorMsg(string.Format("文件{0}已存在，已忽略！\r\n", fileName));
                    }
                    return;
                }
            }

            //获取文件总大小
            var total = HtmlHelp.GetFileContenLength(fileUrl, itemUrl);
            if (total == 0)
            {
                AddErrorMsg(string.Format("获取 {0} 的大小失败！\r\n", fileUrl));
                return;
            }

            //分批获取文件
            var b = HtmlHelp.DownFile(fileUrl, fileName, itemUrl, 299999, total);
            if (b)
            {
                AddSuccessMsg(string.Format("下载 {0} 的文件成功！\r\n", fileUrl));
            }
            else
            {
                AddErrorMsg(string.Format("下载 {0} 的文件失败！\r\n Url：{1}\r\n", fileUrl, itemUrl));
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                return;
            }

            //获取delay
            var dr = new Regex(RegexHelp.Other.GetDelay, RegexOptions.Singleline);
            var dm = dr.Match(html);
            var delay = "50";
            if (dm != null && dm.Groups["Delay"].Value != "")
            {
                delay = dm.Groups["Delay"].Value;
            }

            var dic = new Dictionary<string, string>()
            {
                { "SavePath" , savePath },
                { "FileUrl", fileUrl },
                { "FileName", fileName },
                { "Delay", delay}
            };
            while (!mut.UnZipFile(dic, UnZipFile))
            {
                Thread.Sleep(5000);
            }
        }

        #endregion 获取方法

        #region 其他方法

        public void AddSuccessMsg(string msg)
        {
            try
            {
                form.BeginInvoke(new Action(() =>
                {
                    form.RtxtSuccess.AppendText(msg);
                    ++count;
                    if (count >= 500)
                    {
                        count = 0;
                        form.RtxtSuccess.Text = "";
                    }
                }));
            }
            catch { }
        }

        public void AddErrorMsg(string msg)
        {
            try
            {
                form.BeginInvoke(new Action(() =>
                {
                    form.RtxtError.AppendText(msg);
                }));
            }
            catch { }
        }

        /// <summary>
        /// 加载页面的配置信息
        /// </summary>
        public void LoadXmlConfig()
        {
            if (XmlHelp.doc == null)
                XmlHelp.InitXmlDoucument();

            try
            {
                form.DdlListUrl.Items.Clear();
                var users = XmlHelp.GetXmlNodesByPath("Config:PixivSingleForm:Painter");
                foreach (XmlNode n in users)
                {
                    form.DdlListUrl.Items.Add(n.SelectSingleNode("ID").InnerText);
                }
            }
            catch { }
        }

        /// <summary>
        /// 保存画师信息
        /// </summary>
        public void SavePainterInfo()
        {
            if (form.RadSingle.Checked)
            {
                XmlHelp.SetXmlNode("Config:PixivSingleForm:Painter"
                    , new Dictionary<string, string>()
                    {
                    { "ID", form.DdlListUrl.Text },
                    { "SavePath", form.TxtSavePath.Text }
                    }
                    , "ID");
            }
        }

        /// <summary>
        /// 计算线程数
        /// </summary>
        public void SumThread()
        {
            while (isSumThread)
            {
                try
                {
                    var d = mut.GetThreadList.Count;
                    if (mainThread != null && mainThread.IsAlive)
                        d += 1;

                    form.Invoke(new Action(() => {
                        form.LblGetThread.Text = d.ToString();
                        form.LblDownThread.Text = mut.DownThreadList.Count.ToString();
                    }));
                }
                catch { }
                Thread.Sleep(1000);
            }
        }

        #endregion 其他方法
    }
}
