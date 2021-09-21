using System;
using GrasshopperComponentConfigurator.Models;
using System.Text;

namespace GrasshopperComponentConfigurator.Templates
{
    public partial class GrasshopperComponent
    {
        private readonly ComponentData _data;

        public GrasshopperComponent()
        {

        }

        public GrasshopperComponent(ComponentData data)
        {
            _data = data;
        }

        public string AddParameterMethodsString(Usage paramUsage)
        {
            //E.g. output: "pManager.AddTextParameter("name", "nickname", "description", access);"
            var sb = new StringBuilder();

            foreach (var parameterData in _data.Parameters)
            {
                if (parameterData.Usage == paramUsage)
                {
                    var methodName = "";
                    switch (parameterData.ParamType)
                    {
                        case ParamType.Number:
                            methodName = "AddNumberParameter";
                            break;
                        case ParamType.Text:
                            methodName = "AddTextParameter";
                            break;
                        case ParamType.Curve:
                            methodName = "AddCurveParameter";
                            break;
                        default:
                            methodName = "AddGenericParameter";
                            break;
                    }
                    
                    sb.AppendLine($"\t\t\t pManager.{methodName}.(\"{parameterData.Name}\", \"{parameterData.Nickname}\", \"{parameterData.Description}\", \"{parameterData.Access}\");");
                }
            }

            return sb.ToString();
        }

        public string GetNewGuidString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
