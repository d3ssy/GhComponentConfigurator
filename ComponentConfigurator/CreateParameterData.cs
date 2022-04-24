using Common.Data;
using Grasshopper.Kernel;
using System;

namespace ComponentConfigurator
{
    public class CreateParameterData : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CreateParameterData()
          : base("Create I/O Parameter", "PD",
            "Creates an Input or Output custom gh component parameter.",
            "Component Configurator", "")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Name", "N", "Parameter name.", GH_ParamAccess.item);
            pManager.AddTextParameter("Nickname", "NN", "Parameter nickname.", GH_ParamAccess.item);
            pManager.AddTextParameter("Description", "D", "Parameter description.", GH_ParamAccess.item);
            pManager.AddTextParameter("Usage", "U", "Parameter name.", GH_ParamAccess.item);
            pManager.AddTextParameter("Data Access", "DA", "GH_ParamDataAccess type.", GH_ParamAccess.item);
            pManager.AddTextParameter("Param Type", "PT", "GH_ParamType type.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Parameter Data", "D", "An instance of ParamData.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string name = null, nickname = null, description = null, usage = null, access = null, type = null;

            ParamAccess paramAccess;
            ParamType paramType;
            Usage paramUsage;

            if (!DA.GetData(0, ref name)) return;
            if (!DA.GetData(1, ref nickname)) return;
            if (!DA.GetData(2, ref description)) return;
            if (!DA.GetData(3, ref usage) || !Enum.TryParse(usage, out paramUsage)) return;
            if (!DA.GetData(4, ref access) || !Enum.TryParse(access, out paramAccess)) return;
            if (!DA.GetData(5, ref type) || !Enum.TryParse(type, out paramType)) return;

            var paramData = new ParamData() {
                Access = paramAccess,
                ParamType = paramType,
                Description = description,
                Name = name,
                Nickname = nickname,
                Usage = paramUsage
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
        public override Guid ComponentGuid => new Guid("A1819857-1C60-4413-8E54-8DE0288AA08D");
    }
}