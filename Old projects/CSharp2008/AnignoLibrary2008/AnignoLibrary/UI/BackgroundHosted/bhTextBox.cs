using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace AnignoLibrary.UI.BackgroundHosted
{
    public class bhTextBox : bhBaseControl
    {
        private TextBox _textBox = new TextBox();

        public bhTextBox()
        {
            HostedControl = _textBox;
            _textBox.BorderStyle = BorderStyle.None;
        }

        [Category(" bhTextBox")]
        public override string Text
        {
            get { return _textBox.Text; }
            set
            {
                _textBox.Text = value;
            }
        }
    }
}