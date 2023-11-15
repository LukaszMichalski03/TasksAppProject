using System;
using System.Windows.Markup;

namespace TasksProject.Models
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingSourceExtension(Type enumType) 
        {

            if (enumType is null || !enumType.IsEnum)
                throw new Exception("EnumType cant be null and must be type of Enum");

            EnumType = enumType;
        }

       

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
