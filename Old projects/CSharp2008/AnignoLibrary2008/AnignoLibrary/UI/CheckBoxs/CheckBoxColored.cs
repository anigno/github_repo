using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace AnignoLibrary.UI.CheckBoxs
{
    public class CheckBoxColored : CheckBox
    {
        private const string CATEGORY_STRING = " CheckBoxColored";
        private Color _colorChecked = SystemColors.Control;
        private Color _colorUnChecked = SystemColors.Control;

        [Category(CATEGORY_STRING)]
        public Color ColorChecked
        {
            get { return _colorChecked; }
            set
            {
                _colorChecked = value;
                SetCheckColor();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color ColorUnChecked
        {
            get { return _colorUnChecked; }
            set
            {
                _colorUnChecked = value;
                SetCheckColor();
            }
        }
        public CheckBoxColored()
        {
            SetCheckColor();
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            SetCheckColor();
        }

        private void SetCheckColor()
        {
            if (Checked)
            {
                BackColor = ColorChecked;
            }
            else
            {
                BackColor = ColorUnChecked;
            }
        }
    }
}