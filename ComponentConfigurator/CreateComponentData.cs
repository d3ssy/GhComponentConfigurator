using Common.Data;
using Grasshopper.Kernel;
using System;

namespace ComponentConfigurator
{
    public class CreateComponentData : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CreateComponentData()
          : base("Create Component Data", "CD",
            "Create high level properties of a custom gh component.",
            "Component Configurator", "")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Component name.", GH_ParamAccess.item);
            pManager.AddTextParameter("Nickname", "NN", "Component nickname.", GH_ParamAccess.item);
            pManager.AddTextParameter("Description", "D", "Component description.", GH_ParamAccess.item);
            pManager.AddTextParameter("Category", "C", "Component category.", GH_ParamAccess.item);
            pManager.AddTextParameter("Sub-category", "SC", "GH_ParamDataAccess type.", GH_ParamAccess.item);
            pManager.AddTextParameter("Exposure", "E", "Component Exposure level.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Component Data", "CD", "An instance of ComponentData.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = null, nickname = null, description = null, category = null, subCategory = null, exposure = null;

            if (!DA.GetData(0, ref name)) return;
            if (!DA.GetData(1, ref nickname)) return;
            if (!DA.GetData(2, ref description)) return;
            if (!DA.GetData(3, ref category)) return;
            if (!DA.GetData(4, ref subCategory)) return;
            if (!DA.GetData(5, ref exposure)) return;

            var paramData = new ComponentData() {
                Description = description,
                Name = name,
                Nickname = nickname,
                Category = category,
                SubCategory = subCategory                
            };

            DA.SetData(0, paramData);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon => null;

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("AEF63464-A033-4A70-9269-B0B40D9F2D87");
    }
}