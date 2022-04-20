using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace PropertyGridUsage
{
    [DefaultPropertyAttribute("PlateNumber")]
    public class Car : Control
    {
        public Driver MyDriver { get; set; }
        [Category(" GeneralData")]
        [DefaultValue("00-0000-00")]
        public string PlateNumber { get; set; }

        [Category(" GeneralData")]
        [Description("The color of the body")]
        public Color BodyColor { get; set; }

        [CategoryAttribute(" GeneralData")]
        [Browsable(true)]
        public Size CarSize { get; set; }

        [CategoryAttribute(" GeneralData")]
        [ReadOnly(true)]
        public int SerialNumber { get; set; }

        [CategoryAttribute(" GeneralData")]
        [Browsable(true)]
        public uint Price { get; set; }

        [CategoryAttribute(" Users")]
        public Driver[] Drivers
        {
            get { return _drivers; }
            set { _drivers = value; }
        }
        private Driver[] _drivers = new Driver[0];

    }

}