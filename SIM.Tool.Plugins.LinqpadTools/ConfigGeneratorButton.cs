using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIM.Instances;
using SIM.Tool.Base;
using SIM.Tool.Base.Plugins;
using SIM.Tool.Plugins.LinqpadTools.Dialogs;

namespace SIM.Tool.Plugins.LinqpadTools
{
    public class ConfigGeneratorButton : IMainWindowButton
    {
        public bool IsEnabled(Window mainWindow, Instance instance)
        {
            return (instance != null);
        }

        public void OnClick(Window mainWindow, Instance instance)
        {
            WindowHelper.ShowDialog(new ConfigGeneratorDialog(instance), mainWindow);
        }
    }
}
