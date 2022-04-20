using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using AnignoLibrary.UI.Controls;
using AnignoLibrary.UI.Misc;

namespace AnignoLibrary.UI.CheckBoxs
{
    public class AnignoCheckBox : ControlRoundedCorners
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " AnignoCheckBox";

		#endregion Const Fields 

		#region Fields (2) 


        private bool _checked;

        private Color _checkColor = SystemColors.ControlDarkDark;

		#endregion Fields 

		#region Properties (2) 


        [Category(CATEGORY_STRING)]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color CheckColor
        {
            get { return _checkColor; }
            set
            {
                _checkColor = value;
                Refresh();
            }
        }


		#endregion Properties 

		#region Events (1) 

        [Category(CATEGORY_STRING)]
        public event AfterCheckChanged OnAfterCheckedChanged;

		#endregion Events 

		#region Delegates (1) 

        public delegate void AfterCheckChanged(AnignoCheckBox checkBox, bool checkState);

		#endregion Delegates 

		#region Overridden Methods (2) 

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Checked = !Checked;
            if (OnAfterCheckedChanged!=null) OnAfterCheckedChanged(this, Checked);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            DrawCheckBox(pevent.Graphics);
        }

		#endregion Overridden Methods 

		#region Public Methods (1) 

        public void DrawCheckBox(Graphics g)
        {
            GraphicsPath CheckPath = UIHelper.GetRoundedRectanglePath(CornerRadious/4, CornerRadious/8, Height - CornerRadious/8-CornerRadious/8, Height - CornerRadious/8-CornerRadious/8-1, CornerRadious/2);
            Pen pen = new Pen(CheckColor);
            g.DrawPath(pen, CheckPath);

            Brush checkBrush = new SolidBrush(CheckColor);
            if (Checked)
            {
                g.FillPath(checkBrush, CheckPath);
            }
            g.DrawString(Text, Font, checkBrush, CornerRadious / 4 + Height - CornerRadious / 8 - CornerRadious / 8+2, Height / 2 - Font.Height / 2);
        }

		#endregion Public Methods 

    }
}