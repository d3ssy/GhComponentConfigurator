using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace ComponentConfigurator
{
    public class ComponentConfiguratorInfo : GH_AssemblyInfo
    {
        public override string Name => "Component Parameter";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("1BD4FA8E-4A22-4D0B-A437-33853E4D25A4");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}