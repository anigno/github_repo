using System.ComponentModel;

namespace PropertyGridUsage
{
    [TypeConverter(typeof(DriverConverter))]
    public class Driver
    {
        public override string ToString()
        {
            return Name;
        }

        public enum RoleEnum
        {
            Manager,
            Worker,
        }
        
        [TypeConverter(typeof(NameListConverter))]
        public string Name { get; set; }

        public RoleEnum Role { get; set; }
    }




}
