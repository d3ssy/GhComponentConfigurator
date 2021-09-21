using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using GrasshopperComponentConfigurator.Models;
using GrasshopperComponentConfigurator.Templates;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace GrasshopperComponentConfigurator.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ParamData> ParameterData { get; set; }
        public ComponentData ComponentData { get; set; }
        public string OutputFilePath { get; set; }

        public MainViewModel()
        {
            //Add two default params on initialisation.
            ParameterData = new ObservableCollection<ParamData>()
            {
                new ParamData(){Usage = Usage.Input},
                new ParamData(){Usage = Usage.Output}

            };
            
            //Add default component data on initialisation.
            ComponentData = new ComponentData();
        }

        public string GenerateTemplate()
        {
            ComponentData.Parameters = ParameterData.ToList();

            var template = new GrasshopperComponent(ComponentData);
            return template.TransformText();
        }

        public void WriteTemplateToFile(string templateString)
        {
            string outputPath = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "GhComponentTemplateTest.cs");

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            File.WriteAllText(outputPath, templateString);
        }
    }
}
