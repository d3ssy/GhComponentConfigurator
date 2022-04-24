
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace GrasshopperComponentNamespace
{
    public class GrasshopperComponent : GH_Component
    {
        public GrasshopperComponent()
          : base("Another Test Component",
          "ATC",
          "Another test component.",
          "Component Configurator", 
          "Test")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
			 pManager.AddCurveParameter.("Test Input Curve", "TI", "An input curve param.", GH_ParamAccess.Item);
			 pManager.AddPlaneParameter.("Test Input Curve", "TI", "An input plane param.", GH_ParamAccess.Item);

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }

        protected override void SolveInstance(IGH_componentDefinition.Parameters.Access DA)
        {

        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("6669bb37-115f-45bd-8b31-476f853d03fd"); }
        }
    }
}
