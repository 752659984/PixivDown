using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Command.Entity
{
    class GetListParameter
    {
        public Match Item { get; set; }
        public string Html { get; set; }
        public string ListUrl { get; set; }
    }
}
