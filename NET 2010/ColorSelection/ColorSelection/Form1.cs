using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorSelection
{
    public partial class Form1 : Form
    {
        ColorObject co=new ColorObject();

        public Form1()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = co;
            propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid1_PropertyValueChanged);
        }

        void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            label3.BackColor = co.BackColor;
            label3.ForeColor = co.ForeColor;
            textBox3.Text = "BackColor: " + co.BackColor.ToArgb().ToString();
            textBox4.Text = "ForeColor: " + co.ForeColor.ToArgb().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd=new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = cd.Color.ToArgb().ToString();
                textBox2.Text = cd.Color.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color c = Color.LightSkyBlue;
            int i = c.ToArgb();
        }
    }
}
