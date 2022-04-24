using Common.Data;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Grasshopper.Kernel.Special;
using System;
using System.Drawing;

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

            var paramData = new ComponentData()
            {
                Description = description,
                Name = name,
                Nickname = nickname,
                Category = category,
                SubCategory = subCategory
            };

            DA.SetData(0, paramData);
        }

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            for (int i = 0; i < Params.Input.Count; i++)
            {
                //add panels. one for each of the string input params.
                var panelText = string.Empty;
                switch (i)
                {
                    case (0):
                        panelText = "ComponentName";
                        break;
                    case (1):
                        panelText = "ComponentNickName";
                        break;
                    case (2):
                        panelText = "ComponentDescritpion";
                        break;
                    case (3):
                        panelText = "ComponentCategory";
                        break;
                    case (4):
                        panelText = "ComponentSubCategory";
                        break;
                }

                Param_String in0str = Params.Input[i] as Param_String;
                if (in0str == null || in0str.SourceCount > 0 || in0str.PersistentDataCount > 0) return;
                Attributes.PerformLayout();
                int x = (int)in0str.Attributes.Pivot.X - 200;
                int y = (int)in0str.Attributes.Pivot.Y - 10 + (i * 5);
                var panel = new GH_Panel();
                panel.CreateAttributes();
                panel.Attributes.Pivot = new PointF(x, y);
                panel.Attributes.Bounds = new RectangleF(x, y, 150, 20);
                panel.UserText = panelText;
                panel.Attributes.ExpireLayout();

                document.AddObject(panel, false);
                in0str.AddSource(panel);
            }

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