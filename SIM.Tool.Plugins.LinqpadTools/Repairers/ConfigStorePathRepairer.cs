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
    public class ConfigStorePathRepairer : IConfigRepairer
    {
        public virtual void Repair(XmlDocument doc, Instance instance)
        {
            Assert.ArgumentNotNull(doc, "doc");
            Assert.ArgumentNotNull(instance, "instance");

            var stores = doc.SelectSingleNode("/configuration/sitecore/configStores");
            if (stores != null && stores.ChildNodes.Count > 0)
            {
                var path = instance.WebRootPath + @"\App_Config\Security\";
                foreach (XmlNode node in stores.ChildNodes)
                {
                    if (node.Attributes == null)
                    {
                        continue;
                    }
                    var attr = node.Attributes["arg0"];
                    if (attr == null)
                    {
                        continue;
                    }
                    if (! attr.Value.StartsWith("/App_Config/Security/"))
                    {
                        continue;
                    }
                    var newValue = attr.Value.Replace("/App_Config/Security/", path);
                    attr.Value = newValue;
                }
            }
        }
    }
}
