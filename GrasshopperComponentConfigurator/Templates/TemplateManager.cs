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
                        case ParamType.Point:
                            methodName = "AddPointParameter";
                            break;
                        case ParamType.Plane:
                            methodName = "AddPlaneParameter";
                            break;
                        default:
                            methodName = "AddGenericParameter";
                            break;
                    }

                    var paramAccess = parameterData.Access;
                    string paramAccessStr;
                    switch (paramAccess)
                    {
                        case ParamAccess.List:
                            paramAccessStr = "GH_ParamAccess.List";
                            break;
                        case ParamAccess.Tree:
                            paramAccessStr = "GH_ParamAccess.Tree";
                            break;
                        default:
                            paramAccessStr = "GH_ParamAccess.Item";
                            break;
                    }
                    sb.AppendLine($"\t\t\t pManager.{methodName}.(\"{parameterData.Name}\", \"{parameterData.Nickname}\", \"{parameterData.Description}\", {paramAccessStr});");
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
