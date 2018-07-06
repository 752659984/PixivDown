using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Command.Entity;

namespace Command
{
    public class HtmlHelp
    {
        #region Pixiv获取

        private static CookieContainer cookies = new CookieContainer();
        public static string cookiesString = "";
        private static string PostKey = "";

        /// <summary>
        /// 获取html
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetHtmlString(string url, Encoding encoding)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*;q=0.8";
                request.Headers["Cache-Control"] = "max-age=0";
                var regex = new Regex("http[s]{0,1}://(?'Host'.*?)/", RegexOptions.Singleline);
                var m = regex.Match(url);
                var host = m == null || m.Groups["Host"].ToString() == null ? url : m.Groups["Host"].ToString();
                request.Host = host;
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.86 Safari/537.36";

                //request.CookieContainer = cookies;
                request.Headers["Cookie"] = cookiesString;

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                sr = new StreamReader(stream, encoding);

                string str = sr.ReadToEnd();

                return str;
            }
            catch (Exception e)
            {
                return "";
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (sr != null)
                    sr.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }



        /// <summary>
        /// 下载指定url的图片到指定的路径
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="maxsize"></param>
        /// <param name="allowAutoRedirect"></param>
        /// <param name="dic"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool DownPixivImage(string url, string filePath, int maxsize, string referer)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            FileStream filestream = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Accept = "image/png, image/svg+xml, image/jxr, image/*; q=0.8, */*; q=0.5";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Host = "i.pximg.net";
                request.Referer = referer;

                response = (HttpWebResponse)request.GetResponse();

                filestream = new FileStream(filePath, FileMode.Create);

                stream = response.GetResponseStream();

                byte[] buff = new byte[maxsize];

                int n = 0;
                while ((n = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    filestream.Write(buff, 0, n);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (filestream != null)
                    filestream.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }



        /// <summary>
        /// 获取文件总大小
        /// </summary>
        /// <returns></returns>
        public static long GetFileContenLength(string url, string referer)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            FileStream filestream = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                request.Accept = "*/*";
                request.Referer = referer;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36";

                response = (HttpWebResponse)request.GetResponse();

                return response.ContentLength;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (filestream != null)
                    filestream.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }

        /// <summary>
        /// 从指定的range下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="referer"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool DownFileHasRange(string url, string fileName, string referer, long from, long to)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            FileStream filestream = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "*/*";
                //request.Referer = "https://www.pixiv.net/member_illust.php?mode=medium&illust_id=64642258";
                request.Referer = referer;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36";
                request.AddRange(from, to);

                response = (HttpWebResponse)request.GetResponse();

                filestream = new FileStream(fileName, FileMode.Append);

                stream = response.GetResponseStream();

                byte[] buff = new byte[102400];

                int n = 0;
                while ((n = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    filestream.Write(buff, 0, n);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (filestream != null)
                    filestream.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }

        /// <summary>
        /// 每次按指定大小，下载指定大小的文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="referer"></param>
        /// <param name="req">每次下载量</param>
        /// <param name="contenLength">文件总大小</param>
        /// <returns></returns>
        public static bool DownFile(string url, string fileName, string referer, long req, long contenLength)
        {
            var total = contenLength;
            long from = 0;
            long to = 0;
            long curr = 0;

            while (curr < total)
            {
                if (total - curr >= req)
                    to = req + from;
                else
                    to = total - curr + from;

                var b = DownFileHasRange(url, fileName, referer, from, to);

                if (!b)
                    return false;
                else
                {
                    curr += to - from;
                    from = to + 1;
                }
            }

            return true;
        }



        /// <summary>
        /// 将string保存到txt
        /// </summary>
        /// <returns></returns>
        public static void SaveStringToTxt(string content, string path, bool append = true)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path, append, Encoding.UTF8);
                sw.Write(content);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                }
            }
        }

        /// <summary>
        /// 返回图片url的文件名
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public static string GetImgNameByUrl(string imgUrl)
        {
            var index = imgUrl.LastIndexOf("/");
            if (index < 0)
                index = imgUrl.LastIndexOf("\\");
            if (index >= 0)
            {
                return imgUrl.Substring(index + 1);
            }
            else
            {
                return imgUrl;
            }
        }

        /// <summary>
        /// 查看url是否需要host
        /// </summary>
        /// <param name="url">http://www.baidu.com/abc</param>
        /// <param name="currUrl">/bcd</param>
        /// <returns></returns>
        public static string NeedHost(string url, string currUrl)
        {
            try
            {
                if (!url.Contains("?"))
                {
                    url = url[url.Length - 1] != '/' ? url + "/" : url;
                }
                url = url.Replace("\\", "/").Replace("amp;", "").Replace("%3B", "");
                currUrl = currUrl.Replace("\\/", "/").Replace("\\", "/").Replace("amp;", "").Replace("%3B", "");

                if (currUrl[0].ToString() == "/")
                {
                    Regex reg = new Regex("http[s]{0,1}://.*?/");
                    url = reg.Match(url).Value;
                }
                if (currUrl[0].ToString() == "?")
                {
                    if (url.Contains("?"))
                    {
                        url = url.Substring(0, url.IndexOf("?"));
                    }
                    url = url.Replace("//", "/").Replace(":/", "://");
                    return url + "/" + currUrl;
                }

                var resultUrl = "";

                if (!(currUrl.Contains("http://") || currUrl.Contains("https://")) && !currUrl.Contains("www."))
                    resultUrl = url.Substring(0, url.LastIndexOf("/")) + "/" + currUrl;
                else
                    resultUrl = currUrl;

                return resultUrl.Replace("//", "/").Replace(":/", "://");
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("url：{0}，currUrl：{1}，message：{2}", url, currUrl, e.Message));
            }
        }


        #region 模拟登录

        public static byte[] GetCaptcha(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.Accept = "image/webp,image/apng,image/*,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36";
                request.Referer = "https://accounts.pixiv.net/login?lang=zh&source=pc&view_type=page&ref=wwwtop_accounts_index";

                request.Headers["Cookie"] = cookiesString;

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();

                var buffter = new byte[response.ContentLength];
                stream.Read(buffter, 0, buffter.Length);

                return buffter;

                //return str;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (sr != null)
                    sr.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }

        private static HtmlResultEntity GetCookie(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36";
                request.Referer = "https://www.pixiv.net/";

                request.Headers["Cookie"] = cookiesString;
                request.CookieContainer = cookies;

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                sr = new StreamReader(stream, Encoding.UTF8);

                string str = sr.ReadToEnd();

                var cookie = "";
                if (cookiesString == "")
                {
                    var resultAsync = request.GetResponseAsync();
                    var cs3 = resultAsync.Result.Headers.GetValues("Set-Cookie");
                    if (cs3 != null)
                    {
                        foreach (var s in cs3)
                        {
                            cookie += s;
                        }
                    }
                    resultAsync.Dispose();
                }
                return new HtmlResultEntity { Html = str, Cookie = cookie };


                //return str;
            }
            catch (Exception e)
            {
                return new HtmlResultEntity();
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (sr != null)
                    sr.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }

        private static HtmlResultEntity PostUrl(string url, string parame)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader sr = null;
            Stream stream = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.101 Safari/537.36";
                request.Referer = "https://accounts.pixiv.net/login?lang=zh&source=pc&view_type=page&ref=wwwtop_accounts_index";

                request.Headers["Cookie"] = cookiesString;
                request.CookieContainer = cookies;

                var bd = Encoding.UTF8.GetBytes(parame);
                var rs = request.GetRequestStream();
                rs.Write(bd, 0, bd.Length);

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                sr = new StreamReader(stream, Encoding.UTF8);

                string str = sr.ReadToEnd();

                var cookie = "";
                var resultAsync = request.GetResponseAsync();
                var cs3 = resultAsync.Result.Headers.GetValues("Set-Cookie");
                if (cs3 != null)
                {
                    foreach (var s in cs3)
                    {
                        cookie += s;
                    }
                }
                resultAsync.Dispose();

                return new HtmlResultEntity { Html = str, Cookie = cookie };

                //return str;
            }
            catch (Exception e)
            {
                return new HtmlResultEntity();
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (sr != null)
                    sr.Dispose();

                if (stream != null)
                    stream.Dispose();
            }
        }

        public static HtmlResultEntity Login(string name, string pwd, string captcha = "")
        {
            if (cookiesString == "")
            {
                //第一次请求cookie时空的
                var u1 = "https://accounts.pixiv.net/login?lang=zh&source=pc&view_type=page&ref=wwwtop_accounts_index";
                var result = GetCookie(u1);

                cookiesString = result.Cookie;
                GetHtmlString("https://accounts.pixiv.net/login_bc.gif", Encoding.UTF8);
                cookiesString += ";login_bc=1;";

                var html = (string)result.Html;
                var reg = new Regex("<input type=\"hidden\" name=\"post_key\" value=\"(?'Key'[^<>]*?)\">", RegexOptions.Singleline);
                var m = reg.Match(html);
                PostKey = m.Groups["Key"].Value;
            }

            //var u2 = "";
            //var p2 = "";
            //cookiesString += ";" + GetCookie("",p2);

            var u3 = "https://accounts.pixiv.net/api/login?lang=zh";
            var p3 = string.Format("pixiv_id={0}&password={1}&captcha={2}&g_recaptcha_response=&post_key={3}&source=pc&ref=wwwtop_accounts_index&return_to=https%3A%2F%2Fwww.pixiv.net%2F"
                , HttpUtility.UrlEncode(name, Encoding.UTF8)
                , HttpUtility.UrlEncode(pwd, Encoding.UTF8)
                , HttpUtility.UrlEncode(captcha, Encoding.UTF8)
                , HttpUtility.UrlEncode(PostKey, Encoding.UTF8));

            var re2 = PostUrl(u3, p3);
            if (re2.Html.Contains("success"))
                cookiesString = re2.Cookie;

            return re2;
        }

        #endregion 模拟登录

        #endregion Pixiv获取

        #region 其他获取方法

        public static string Get(string url)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            StreamReader sr = null;

            try
            {

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();

                sr = new StreamReader(stream);

                return sr.ReadToEnd();
            }
            catch
            {
                return "";
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (stream != null)
                    stream.Dispose();

                if (sr != null)
                    sr.Dispose();
            }
        }

        public static bool DownFile(string url, string fileName)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            FileStream fs = null;

            try
            {

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();

                fs = new FileStream(fileName, FileMode.Create);

                var buffter = new byte[1024];
                int n = 0;
                while ((n = stream.Read(buffter, 0, buffter.Length)) > 0)
                {
                    fs.Write(buffter, 0, n);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (stream != null)
                    stream.Dispose();

                if (fs != null)
                    fs.Dispose();
            }
        }

        public static bool DownFile(string url, string fileName, ProgressBar pb)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            FileStream fs = null;

            try
            {
                pb.Value = 0;

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();

                fs = new FileStream(fileName, FileMode.Create);

                var buffter = new byte[1024];
                var total = response.ContentLength;
                var count = 0.0;
                var n = 0;
                while ((n = stream.Read(buffter, 0, buffter.Length)) > 0)
                {
                    fs.Write(buffter, 0, n);
                    count += n;
                    pb.Value = (int)(count / total * 100);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (request != null)
                    request.Abort();

                if (response != null)
                    response.Dispose();

                if (stream != null)
                    stream.Dispose();

                if (fs != null)
                    fs.Dispose();
            }
        }

        #endregion 其他获取方法
    }
}
