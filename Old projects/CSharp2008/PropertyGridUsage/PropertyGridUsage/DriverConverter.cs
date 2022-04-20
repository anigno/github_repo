using System;
using System.ComponentModel;

namespace PropertyGridUsage
{
    public class DriverConverter : ExpandableObjectConverter
    {
        //Optional, can use ToString() of Driver type (which works well in designer
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Driver)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        //Optional, can use ToString() of Driver type
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Driver)
            {
                return ((Driver)value).Name + "," + ((Driver)value).Role;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        //Optional for editing the text in the PropertyGrid
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        //Optional for editing the text in the PropertyGrid
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    string[] parts = ((string)value).Split(',');
                    Driver editedDriver = new Driver();
                    editedDriver.Name = parts[0];
                    editedDriver.Role = (Driver.RoleEnum)Enum.Parse(typeof(Driver.RoleEnum), parts[1]);
                    return editedDriver;
                }
                catch
                {
                    throw new ArgumentException("Can not convert given string to Driver");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }

}
