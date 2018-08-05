using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Entity
{
    public class RequestParameEntity: ICloneable
    {
        public string ID { get; set; }

        public string ListUrl { get; set; }

        public string SavePath { get; set; }

        public string ParentPath { get; set; }

        public bool DownRelatedWorks { get; set; }

        /// <summary>  
        /// ICloneable 成员   
        /// </summary>  
        /// <returns></returns>  
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class RequestItemParameEntity : ICloneable
    {
        public string ItemUrl { get; set; }

        public string SavePath { get; set; }

        /// <summary>  
        /// ICloneable 成员   
        /// </summary>  
        /// <returns></returns>  
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
