
using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace GrasshopperComponentNamespace
{
    public class GrasshopperComponent : GH_Component
    {
        public GrasshopperComponent()
          : base("Test Component",
          "TC",
          "A test component.",
          "Component Configurator", 
          "Test")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
			 pManager.AddPointParameter.("Test Input Point", "TI", "An input point param.", GH_ParamAccess.Item);

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
			 pManager.AddNumberParameter.("Test Output Number", "TO", "An output number param.", GH_ParamAccess.Item);

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
            get { return new Guid("c2669b25-868b-40f2-ad51-404cde9b8de5"); }
        }
    }
}
