using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SIM.Instances;

namespace SIM.Tool.Plugins.LinqpadTools.Repairers
{
    public interface IConfigRepairer
    {
        void Repair(XmlDocument doc, Instance instance);
    }
}
