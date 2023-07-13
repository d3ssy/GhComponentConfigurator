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
                        case ParamType.Angle:
                            methodName = "AddAngleParameter";
                            break;
                        case ParamType.Arc:
                            methodName = "AddArcParameter";
                            break;
                        case ParamType.Bool:
                            methodName = "AddBooleanParameter";
                            break;
                        case ParamType.Box:
                            methodName = "AddBoxParameter";
                            break;
                        case ParamType.Brep:
                            methodName = "AddBrepParameter";
                            break;
                        case ParamType.Circle:
                            methodName = "AddCircleParameter";
                            break;
                        case ParamType.Colour:
                            methodName = "AddColourParameter";
                            break;
                        case ParamType.ComplexNumber:
                            methodName = "AddComplexNumberParameter";
                            break;
                        case ParamType.Curve:
                            methodName = "AddCurveParameter";
                            break;
                        case ParamType.Geometry:
                            methodName = "AddGeometryParameter";
                            break;
                        case ParamType.Integer:
                            methodName = "AddIntegerParameter";
                            break;
                        case ParamType.Interval:
                            methodName = "AddIntervalParameter";
                            break;
                        case ParamType.Line:
                            methodName = "AddLineParameter";
                            break;
                        case ParamType.Matrix:
                            methodName = "AddMatrixParameter";
                            break;
                        case ParamType.Mesh:
                            methodName = "AddMeshParameter";
                            break;
                        case ParamType.Number:
                            methodName = "AddNumberParameter";
                            break;
                        case ParamType.Path:
                            methodName = "AddPathParameter";
                            break;
                        case ParamType.Point:
                            methodName = "AddPointParameter";
                            break;
                        case ParamType.Plane:
                            methodName = "AddPlaneParameter";
                            break;
                        case ParamType.Rectangle:
                            methodName = "AddRectangleParameter";
                            break;
                        case ParamType.SubD:
                            methodName = "AddSubDParameter";
                            break;
                        case ParamType.Surface:
                            methodName = "AddSurfaceParameter";
                            break;
                        case ParamType.Text:
                            methodName = "AddTextParameter";
                            break;
                        case ParamType.Transform:
                            methodName = "AddTransformParameter";
                            break;
                        case ParamType.Vector:
                            methodName = "AddVectorParameter";
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
