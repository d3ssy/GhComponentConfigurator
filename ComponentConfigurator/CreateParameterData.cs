using Common.Data;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            ParamUsage paramUsage;

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

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);
            
            for (int i = 0; i < Params.Input.Count; i++)
            {
                //add 3 panels. one for each of the string input params.
                if (i < 3)
                {
                    var panelText = string.Empty;
                    switch (i)
                    {
                        case (0):
                            panelText = "ParameterName";
                            break;
                        case (1):
                            panelText = "ParameterNickName";
                            break;
                        case (2):
                            panelText = "ParameterDescritpion";
                            break;
                    }                    

                    Grasshopper.Kernel.Parameters.Param_String in0str = Params.Input[i] as Grasshopper.Kernel.Parameters.Param_String;
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


                //add 3 value lists. one for each of the enum input params.
                if (i >= 3 && i <= 5)
                {
                    Grasshopper.Kernel.Parameters.Param_String in0str = Params.Input[i] as Grasshopper.Kernel.Parameters.Param_String;
                    if (in0str == null || in0str.SourceCount > 0 || in0str.PersistentDataCount > 0) return;
                    Attributes.PerformLayout();
                    int x = (int)in0str.Attributes.Pivot.X - 200;
                    int y = (int)in0str.Attributes.Pivot.Y - 10 + (i * 5);
                    GH_ValueList valList = new GH_ValueList();
                    valList.CreateAttributes();
                    valList.Attributes.Pivot = new PointF(x, y);
                    valList.Attributes.ExpireLayout();
                    valList.ListItems.Clear();

                    System.Type enumType = null;
                    switch (i)
                    {
                        case (3):
                            enumType = typeof(ParamUsage);
                            break;
                        case (4):
                            enumType = typeof(ParamAccess);
                            break;
                        case (5):
                            enumType = typeof(ParamType);
                            break;
                    }

                    List<GH_ValueListItem> valueListItems = Enum.GetNames(enumType).
                        Select(s => new GH_ValueListItem(s, s)).ToList();

                    valList.ListItems.AddRange(valueListItems);
                    document.AddObject(valList, false);
                    in0str.AddSource(valList);
                }
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
        public override Guid ComponentGuid => new Guid("A1819857-1C60-4413-8E54-8DE0288AA08D");
    }
}