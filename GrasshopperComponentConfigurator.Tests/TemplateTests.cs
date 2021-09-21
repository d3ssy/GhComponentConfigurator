using System;
using System.Collections.Generic;
using System.IO;
using GrasshopperComponentConfigurator.Models;
using GrasshopperComponentConfigurator.Templates;
using Xunit;

namespace GrasshopperComponentConfigurator.Tests
{
    public class TemplateTests
    {
        private readonly string _outputPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "GhComponentTemplateTest.cs");

        [Fact]
        public void It_Writes_A_Default_Class_File_From_Text_Template_At_Run_Time()
        {
            //Arrange
            var template = new GrasshopperComponent();
            var templateString = template.TransformText();

            
            //Act
            if (File.Exists(_outputPath))
            {
                File.Delete(_outputPath);
            }

            File.WriteAllText(_outputPath, templateString);

            //Assert
            Assert.True(File.Exists(_outputPath));
        }

        [Fact]
        public void It_Writes_A_Class_File_From_Text_Template_At_Run_Time()
        {
            //Arrange
            var data = new ComponentData();
            //var paramsData = new List<ParamData>
            //{
            //    new ParamData(){Access = ParamAccess.Item, Name = "Input1", Nickname = "In1", ParamType = ParamType.Number, Usage = Usage.Input},
            //    new ParamData(){Access = ParamAccess.Item, Name = "Input2", Nickname = "In2", ParamType = ParamType.Text, Usage = Usage.Input},
            //    new ParamData(){Access = ParamAccess.Item, Name = "Output1", Nickname = "Out1", ParamType = ParamType.Text, Usage = Usage.Output},
            //    new ParamData(){Access = ParamAccess.Item, Name = "Output2", Nickname = "Out2", ParamType = ParamType.Number, Usage = Usage.Output}
            //};

            //data.Parameters = paramsData;
            data.Namespace = "MyComponentNamespace";
            data.Name = "MyComponentName";
            data.Nickname = "MyComponentNickName";
            data.Category = "MyComponentCategory";
            data.SubCategory = "MyComponentSubCategory";
            data.Description = "MyComponentDescription";

            var template = new GrasshopperComponent(data);
            var templateString = template.TransformText();

            //Act
            if (File.Exists(_outputPath))
            {
                File.Delete(_outputPath);
            }

            File.WriteAllText(_outputPath, templateString);

            //Assert
            Assert.True(File.Exists(_outputPath));
        }
    }
}
