using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Command
{
    public delegate bool SelectNode(XmlNode list);

    public class XmlHelp
    {
        public static XmlDocument doc = null;

        private static string XmlFileName = "Config.xml";

        public static void InitXmlDoucument()
        {
            if (!File.Exists(XmlFileName))
                throw new Exception("配置文件不存在！");
            
            doc = new XmlDocument();
            doc.Load(XmlFileName);
        }

        public static string GetInnerTextByPath(string path, string xmlFile = "")
        {
            var fileName = xmlFile == "" ? XmlFileName : xmlFile;

            if (!File.Exists(fileName))
                return null;

            if (xmlFile != "")
            {
                doc = new XmlDocument();
                doc.Load(fileName);
            }
            
            var ps = path.Split(':');
            var pNode = doc.SelectSingleNode(ps[0]);
            for (var i = 1; i < ps.Length; ++i)
            {
                pNode = pNode.SelectSingleNode(ps[i]);
            }

            return pNode.InnerText;
        }

        public static XmlNode GetXmlNodeByXmlNode(XmlNode pNode, string path)
        {
            var ps = path.Split(':');
            for (var i = 0; i < ps.Length; ++i)
            {
                pNode = pNode.SelectSingleNode(ps[i]);
            }

            return pNode;
        }

        public static string GetInnerTextByXmlNode(XmlNode pNode, string path)
        {
            return GetXmlNodeByXmlNode(pNode, path).InnerText;
        }

        public static XmlNode GetXmlNodeByPath(string path, string where, string xmlFile = "")
        {
            var fileName = xmlFile == "" ? XmlFileName : xmlFile;

            if (!File.Exists(fileName))
                return null;

            if (xmlFile != "")
            {
                doc = new XmlDocument();
                doc.Load(fileName);
            }

            var ps = path.Split(':');
            var pNode = doc.SelectSingleNode(ps[0]);
            for (var i = 1; i < ps.Length - 1; ++i)
            {
                pNode = pNode.SelectSingleNode(ps[i]);
            }

            if (where != "")
            {
                var ws = where.Split('=');
                var ns = pNode.SelectNodes(ps[ps.Length - 1]);
                for (var i = 0; i < ns.Count; ++i)
                {
                    var n = ns[i].SelectSingleNode(ws[0]);
                    if (n != null && n.InnerText == ws[1])
                    {
                        return ns[i];
                    }
                }
            }

            return pNode.SelectSingleNode(ps[ps.Length - 1]);
        }

        public static XmlNodeList GetXmlNodesByPath(string path, string xmlFile = "")
        {
            var fileName = xmlFile == "" ? XmlFileName : xmlFile;

            if (!File.Exists(fileName))
                return null;

            if (xmlFile != "")
            {
                doc = new XmlDocument();
                doc.Load(fileName);
            }

            var ps = path.Split(':');
            var pNode = doc.SelectSingleNode(ps[0]);
            for (var i = 1; i < ps.Length - 1; ++i)
            {
                pNode = pNode.SelectSingleNode(ps[i]);
            }

            return pNode.SelectNodes(ps[ps.Length - 1]);
        }

        public static bool SetXmlNode(string path, Dictionary<string, string> addItem, string key)
        {
            try
            {
                var ps = path.Split(':');
                var pnode = (XmlNode)doc;
                for (var i = 0; i < ps.Length - 1; ++i)
                {
                    var node = pnode.SelectSingleNode(ps[i]);
                    if (node == null)
                    {
                        node = doc.CreateElement(ps[i]);
                        pnode.AppendChild(node);
                        //break;
                    }
                    pnode = node;
                }

                var last = pnode.SelectNodes(ps[ps.Length - 1]).First(p => p.SelectSingleNode(key).InnerText == addItem[key]);
                if (last == null)
                {
                    last = doc.CreateElement(ps[ps.Length - 1]);
                    pnode.AppendChild(last);

                    foreach (var s in addItem)
                    {
                        var n = doc.CreateElement(s.Key);
                        n.InnerText = s.Value;
                        last.AppendChild(n);
                    }
                }
                else
                {
                    foreach (var s in addItem)
                    {
                        last.SelectSingleNode(s.Key).InnerText = s.Value;
                    }
                }

                doc.Save(XmlFileName);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    public static class XmlExtend
    {
        public static XmlNode First(this XmlNodeList list, SelectNode sn)
        {
            foreach (XmlNode n in list)
            {
                if (sn(n))
                    return n;
            }

            return null;
        }
    }
}
