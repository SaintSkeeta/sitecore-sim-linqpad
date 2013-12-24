using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIM.Tool.Base.Plugins;
using SIM.Tool.Plugins.LinqpadTools.Repairers;

namespace SIM.Tool.Plugins.LinqpadTools.Pipelines
{
    public class AddConfigStorePathRepairer : IInitProcessor
    {
        public void Process()
        {
            ConfigRepairerManager.AddConfigRepairer(new ConfigStorePathRepairer());
        }
    }
}
