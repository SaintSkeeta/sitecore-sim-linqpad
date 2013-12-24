using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SIM.Base;
using SIM.Instances;

namespace SIM.Tool.Plugins.LinqpadTools.Repairers
{
    public class Log4netRepairer : IConfigRepairer
    {
        public virtual void Repair(XmlDocument doc, Instance instance)
        {
            Assert.ArgumentNotNull(doc, "doc");
            var log4netNode = doc.SelectSingleNode("/configuration/log4net");
            if (log4netNode == null)
            {
                return;
            }
            var nodes = log4netNode.SelectNodes("//encoding");
            if (nodes == null || nodes.Count == 0)
            {
                return;
            }
            foreach (XmlNode node in nodes)
            {
                node.ParentNode.RemoveChild(node);
            }
        }
    }
}
