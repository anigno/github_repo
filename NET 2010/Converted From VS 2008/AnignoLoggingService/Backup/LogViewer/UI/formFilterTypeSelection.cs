using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoggingProvider;

namespace LogViewer
{
    public partial class formFilterAddEdit : Form
    {
        public FilterTypeEnum FilterType
        {
            get { return (FilterTypeEnum)comboBoxFilterType.SelectedItem; }
        }

        public string FilterWildCard
        {
            get { return textBoxFilterWildCard.Text; }
        }

        public formFilterAddEdit()
        {
            InitializeComponent();
            foreach (FilterTypeEnum e in Enum.GetValues(typeof(FilterTypeEnum)))
            {
                comboBoxFilterType.Items.Add(e);
            }
            comboBoxFilterType.SelectedIndex = 0;

        }


    }
}