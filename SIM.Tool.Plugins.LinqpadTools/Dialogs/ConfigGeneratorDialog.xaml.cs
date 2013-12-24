using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using SIM.Base;
using SIM.Instances;
using SIM.Tool.Plugins.LinqpadTools.Repairers;

namespace SIM.Tool.Plugins.LinqpadTools.Dialogs
{
    /// <summary>
    /// Interaction logic for ConfigGeneratorDialog.xaml
    /// </summary>
    public partial class ConfigGeneratorDialog : Window
    {
        public ConfigGeneratorDialog(Instance instance)
        {
            InitializeComponent();
            this.Instance = instance;
            Loaded += OnLoaded;
        }
        
        public Instance Instance { get; private set; }
        
        protected virtual void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            RefreshConfig(this.Instance); 
        }

        protected virtual void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshConfig(this.Instance); 
        }
        
        protected virtual void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.InitialDirectory = @"C:\Program Files (x86)\LINQPad4\";
            dialog.FileName = "LINQPad.config"; 
            dialog.DefaultExt = ".config"; 
            dialog.Filter = "Config files |*.config";

            var result = dialog.ShowDialog();
            if (result == true)
            {
                File.WriteAllText(dialog.FileName, contentsBox.Text); 
            }
        }

        protected virtual void RefreshConfig(Instance instance)
        {
            Assert.ArgumentNotNull(instance, "instance");
            var prev = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;

            var doc = instance.GetWebResultConfig();
            RunRepairers(doc, instance);
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(stringWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    doc.WriteTo(xmlWriter);
                    xmlWriter.Flush();
                    contentsBox.Text = stringWriter.GetStringBuilder().ToString();
                }
            }
            Mouse.OverrideCursor = prev;
        }

        protected virtual void RunRepairers(XmlDocument doc, Instance instance)
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
