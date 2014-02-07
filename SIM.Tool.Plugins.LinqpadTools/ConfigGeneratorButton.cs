using SIM.Base;
using SIM.Instances;
using SIM.Tool.Base;
using SIM.Tool.Base.Plugins;
using SIM.Tool.Dialogs;
using SIM.Tool.Plugins.LinqpadTools.Repairers;
using System;
using System.Windows;
using System.Xml;

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
            string folderDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\LINQPad4\";
            string filename = "LINQPad.config";
            string title = "LINQPad.config File Generator";
            string description = "This config file allows you to use the Sitecore API within LINQPad.";

            WindowHelper.ShowDialog(new ConfigGeneratorDialog(instance, folderDirectory, filename, title, description, CreateLinqConfig), mainWindow);
        }

        public XmlDocument CreateLinqConfig(Instance instance)
        {
            var doc = instance.GetWebResultConfig();
            this.RunRepairers(doc, instance);

            return doc;
        }

        private void RunRepairers(XmlDocument doc, Instance instance)
        {
            Assert.ArgumentNotNull(doc, "doc");
            Assert.ArgumentNotNull(instance, "instance");

            foreach (var repairer in ConfigRepairerManager.ConfigRepairers)
            {
                repairer.Repair(doc, instance);
            }
        }
    }
}
