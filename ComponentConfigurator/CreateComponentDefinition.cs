using Common.Data;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComponentConfigurator
{
    public class CreateComponentDefinition : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CreateComponentDefinition()
          : base("Create Component Definition", "CC",
            "Define component data, inputs and output parameters for a custom component.",
            "Component Configurator", "")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Component Data", "CD", "ComponentData for this component.", GH_ParamAccess.item);
            pManager.AddGenericParameter("Parameter Data", "PD", "A list of input output parameters as ParamData.", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Component Definition", "CD", "An instance of ComponentDefinition.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var paramDataObjs = new List<GH_ObjectWrapper>();
            var componentParameters = new List<ParamData>();
            GH_ObjectWrapper componentDataObj = new GH_ObjectWrapper();
            ComponentData componentData = null;

            if (!DA.GetData(0, ref componentDataObj)) return;
            if (!DA.GetDataList(1, paramDataObjs) || paramDataObjs == null || paramDataObjs.Count == 0) return;

            //cast list of objs to ParamData
            componentParameters = paramDataObjs.Select(o => o.Value as ParamData).ToList();

            //require at least a single param, and that casting was successful.
            if (!componentParameters?.Any() ?? false) return;

            if (componentDataObj != null)
            {
                componentData = componentDataObj.Value as ComponentData;
            }

            if (componentData == null) return;
           
            var componentDefinition = new ComponentDefinition()
            {
                Parameters = componentParameters,
                ComponentData = componentData
            };
          
            DA.SetData(0, componentDefinition);
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
        public override Guid ComponentGuid => new Guid("6F600388-2B48-4305-9560-10A3DE807C37");
    }
}