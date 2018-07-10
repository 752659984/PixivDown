using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Command.Entity
{
    public class DownFileParameter
    {
        public Match Item { get; set; }
        public string BaseUrl { get; set; }
        public string Url { get; set; }
        public string TxtContent { get; set; }
        public string SavePath { get; set; }
    }
}
