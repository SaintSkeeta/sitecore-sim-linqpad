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
    public class NonAsciiRepairer : IConfigRepairer
    {
        protected virtual StringBuilder ToStringBuilder(XmlDocument doc)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(stringWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    doc.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                    return stringWriter.GetStringBuilder();
                }
            }
        }
        public virtual void Repair(XmlDocument doc, Instance instance)
        {
            //sample characters that are replaced: ™ “ ’ ” ’
            Assert.ArgumentNotNull(doc, "doc");
            var builder = ToStringBuilder(doc);
            var repaired = Regex.Replace(builder.ToString(), @"[^\u0000-\u007F]", string.Empty);
            doc.LoadXml(repaired);
        }
    }
}
