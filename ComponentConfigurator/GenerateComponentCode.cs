using Common.Data;
using Grasshopper.Kernel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using ComponentConfigurator.Templates;
using Grasshopper.Kernel.Types;
using Grasshopper.Kernel.Special;
using System.Drawing;

namespace ComponentConfigurator
{
    public class GenerateComponentCode : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GenerateComponentCode()
          : base("Generate Component Code", "GC",
            "Generates boilerplate custom component code in user defined directory.",
            "Component Configurator", "")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Output Directory", "D", "Filepath to output directory.", GH_ParamAccess.item);
            pManager.AddGenericParameter("Component Definition", "CD", "ComponentDefinition for this component.", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Generate", "G", "Generates .cs code files in spefified dir.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Output File Paths", "O", "Filepaths of generated .cs files.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string dir = null;
            bool generate = false;
            var compDefObj = new GH_ObjectWrapper();
            ComponentDefinition componentDefinition = null;

            if (!DA.GetData(0, ref dir)) return;          
            if (!DA.GetData(1, ref compDefObj)) return;
            if (!DA.GetData(2, ref generate)) return;

            if (compDefObj != null)
            {
                componentDefinition = compDefObj.Value as ComponentDefinition;
            }

            if (componentDefinition == null) return;

            var template = new GrasshopperComponent(componentDefinition);
            var templateString = template.TransformText();
            var path = $"{dir}/{componentDefinition.ComponentData.Name}.cs";

            //check if dir exists, else create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //generate template
            if (generate)
            {
                WriteTemplateToFile(templateString, path);             
            }

            //TODO This should only output if successful.
            DA.SetData(0, path);
        }

        private void WriteTemplateToFile(string templateString, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllText(filePath, templateString);
        }

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);
            
            Grasshopper.Kernel.Parameters.Param_String in0str = Params.Input[Params.Input.Count -1] as Grasshopper.Kernel.Parameters.Param_String;
            if (in0str == null || in0str.SourceCount > 0 || in0str.PersistentDataCount > 0) return;
            Attributes.PerformLayout();
            int x = (int)in0str.Attributes.Pivot.X - 200;
            int y = (int)in0str.Attributes.Pivot.Y - 5;
            var panel = new GH_ButtonObject();
            panel.CreateAttributes();
            panel.Attributes.Pivot = new PointF(x, y);
            panel.Attributes.Bounds = new RectangleF(x, y, 150, 20);
            panel.Attributes.ExpireLayout();

            document.AddObject(panel, false);
            in0str.AddSource(panel);
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
        public override Guid ComponentGuid => new Guid("F519CFF0-4827-4A08-9DA3-3F363A19FFDB");
    }
}