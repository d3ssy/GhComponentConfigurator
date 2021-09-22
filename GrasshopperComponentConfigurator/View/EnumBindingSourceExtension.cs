using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Markup;

namespace GrasshopperComponentConfigurator
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; set; }

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
            {
                throw new ArgumentException("EnumType must not be null and must be of type Enum.");
            }

            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
