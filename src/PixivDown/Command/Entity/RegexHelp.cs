using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Entity
{
    public class RegexHelp
    {
        public static List<EachListRegex> ListRegex = new List<EachListRegex>();

        public static OtherRegex Other = new OtherRegex();

        public static string GetRegex(DownContentType type1, RegexType type2)
        {
            var c = ListRegex.First(t => t.ContentType == type1 && t.Regexs.ContainsKey(type2));
            return c != null ? c.Regexs[type2] : "";
        }
    }

    public class EachListRegex
    {
        /// <summary>
        /// 下载内容类型
        /// </summary>
        public DownContentType ContentType { get; set; }

        /// <summary>
        /// 正则表达式集合
        /// </summary>
        public Dictionary<RegexType, string> Regexs { get; set; }

        public EachListRegex()
        {
            Regexs = new Dictionary<RegexType, string>();
        }
    }

    public enum DownContentType
    {
        /// <summary>
        /// 单个画师
        /// </summary>
        SinglePainter = 0,
        /// <summary>
        /// 所有关注的画师
        /// </summary>
        AllFollow = 1,
        /// <summary>
        /// 自己的收藏
        /// </summary>
        OwnCollection = 2,
        /// <summary>
        /// 下载搜索
        /// </summary>
        GetSearch = 3
    }

    public enum RegexType
    {
        /// <summary>
        /// 父容器
        /// </summary>
        ListParentRegex = 0,
        /// <summary>
        /// 需要遍历的集合
        /// </summary>
        ListRegex = 1,
        /// <summary>
        /// 下一页列表
        /// </summary>
        NextListRegex = 2
    }

    public class OtherRegex
    {
        /// <summary>
        /// 获取放大按钮
        /// </summary>
        public string GetMaxButton = "</script>\\s*<a href=\"(?'Url'[^<>]*?)\"[^<>]*?显示原图";

        /// <summary>
        /// 没有获取到放大按钮时，直接获取图片
        /// </summary>
        public string GetImageWhenNotMax = "<img src=\"[^<>]*?\"[^<>]*?data-src=\"(?'Url'[^<>]*?)\"[^<>]*?>";

        /// <summary>
        /// 获取放大后的图片
        /// </summary>
        public string GetImageWhenMax = "<img[^<>]*?src=\"(?'Url'[^<>]*?)\"";


        /// <summary>
        /// 获取动画
        /// </summary>
        public string GetAnimation = "\"src\":\"(?'Url'[^<>]*?)\"";

        /// <summary>
        /// 获取动画的delay
        /// </summary>
        public string GetDelay = "\"delay\":(?'Delay'\\d+)}";



        //——————新版

        /// <summary>
        /// 判断当前作品的子页数，为1则只有一张图片，大于1则时有多张图片
        /// </summary>
        public string GetItemPageCount = "\"pageCount\":(?'P'\\d+),\"bookmarkCount\"";

        /// <summary>
        /// 获取一张图片（新）
        /// </summary>
        public string GetSingleImage = "\"original\":\"(?'Url'[^<>]*?)\"";

        /// <summary>
        /// 获取图片的类型，2是动图，0是多图或单图
        /// </summary>
        public string GetIllustType = "\"illustType\":(?'T'\\d+),";


        //——————获取相关作品
        /// <summary>
        /// 获取相关作品真正需要下载的作品ID
        /// </summary>
        public string GetFirstIds = "{\"workId\":\"(?'ID'\\d+)\",";

        /// <summary>
        /// 获取相关作品参数的文本，后面
        /// </summary>
        public string GetNextIdsParent = "\"nextIds\":\\[(?'Main'[^\\{\\}\\[\\]]*?)\\],\"recommendMethods\"";

        /// <summary>
        /// 获取相关作品参数的集合，后面
        /// </summary>
        public string GetNextIds = "\"(?'ID'\\d+)\"";
    }
}
