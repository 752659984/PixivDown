using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class DownHelp
    {
        public static bool DownImage(string url, string dirname, int maxsize, string referer, int reDown)
        {
            var result = false;
            while (!result && reDown > 0)
            {
                result = HtmlHelp.DownPixivImage(url, dirname, 1024, referer);
                --reDown;
            }

            return result;
        }

        public static string GetHtmlString(string url, Encoding encoding, int reCount)
        {
            var result = "";
            while (result == "" && reCount > 0)
            {
                result = HtmlHelp.GetHtmlString(url, encoding);
                --reCount;
            }

            return result;
        }
    }
}
