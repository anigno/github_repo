using System.ComponentModel;

namespace PropertyGridUsage
{
    public class NameListConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new[] { "Roni", "Ami", "Ronen" });
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;   //This basically changes the drop-down list style to a combo box style
        }
    }

}
