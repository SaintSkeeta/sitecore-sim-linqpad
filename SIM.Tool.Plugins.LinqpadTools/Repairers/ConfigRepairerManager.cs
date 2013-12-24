using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIM.Tool.Plugins.LinqpadTools.Repairers
{
    public class ConfigRepairerManager
    {
        private static List<IConfigRepairer> _repairers = new List<IConfigRepairer>();
        public static IConfigRepairer[] ConfigRepairers 
        {
            get { return _repairers.ToArray(); }
        }
        
        public static void AddConfigRepairer(IConfigRepairer repairer)
        {
            if (! _repairers.Contains(repairer))
            {
                _repairers.Add(repairer);
            }
        }

        public static void RemoveConfigRepairer(IConfigRepairer repairer)
        {
            if (_repairers.Contains(repairer))
            {
                _repairers.Remove(repairer);
            }
        }
    }
}
