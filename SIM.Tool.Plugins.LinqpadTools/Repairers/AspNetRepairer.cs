using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using SIM.Base;
using SIM.Instances;

namespace SIM.Tool.Plugins.LinqpadTools.Repairers
{
    public class AspNetRepairer : IConfigRepairer
    {
        public virtual void Repair(XmlDocument doc, Instance instance)
        {
            Assert.ArgumentNotNull(doc, "doc");
            RemoveNode("/configuration/system.webServer", doc);
            RemoveNode("/configuration/system.web", doc);
        }

        protected virtual void RemoveNode(string path, XmlDocument doc)
        {
            var node = doc.SelectSingleNode(path);
            if (node != null && node.ParentNode != null)
            {
                node.ParentNode.RemoveChild(node);
            }
        }
    }
}
