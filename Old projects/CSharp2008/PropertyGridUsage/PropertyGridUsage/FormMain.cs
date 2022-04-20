using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertyGridUsage
{
    public partial class FormMain : Form
    {
        private Car myCar=new Car();
        public FormMain()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = myCar;
        }
    }
}
