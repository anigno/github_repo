using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.UI.Misc;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace AnignoLibrary.UI.Forms
{
    public class AnignoFormBaseA_old : Form
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoFormBaseA";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private int _cornerRadious = 15;
        private int _headerHeight = 0;
        private Color _BackColorInner = Color.White;
        private Button buttonClose;
        private Color _BackColorBorder = Color.White;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoFormBaseA_old()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            _headerHeight = base.Font.Height;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public Color BackColorInner
        {
            get { return _BackColorInner; }
            set
            {
                _BackColorInner = value;
                Invalidate();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            _headerHeight = FontHeight;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Draw background
            base.OnPaintBackground(e);
            SolidBrush brushInner = new SolidBrush(BackColorInner);
            Rectangle rectangleInner=new Rectangle(_cornerRadious/2,_cornerRadious/2+_headerHeight,Width-2*_cornerRadious/2,Height-2*_cornerRadious/2-_headerHeight);
            e.Graphics.FillRectangle(brushInner,rectangleInner);
            //Draw header icon
            e.Graphics.DrawImage(Icon.ToBitmap(),_cornerRadious/2,_cornerRadious/2,_headerHeight,_headerHeight);
            //Draw header text
            SolidBrush brushText=new SolidBrush(ForeColor);
            UIHelper.DrawStringCenterPoint(Text, e.Graphics, Font, brushText, Width / 2f,_headerHeight/2f+_cornerRadious/2);
            //Set control buttons
            
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Recreate form's region according to new size
            GraphicsPath pathRegion = UIHelper.GetRoundedRectanglePath(0, 0, Width, Height, _cornerRadious);
            Region = new Region(pathRegion);
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 2;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(279, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // AnignoFormBaseA
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnignoFormBaseA";
            this.ResumeLayout(false);

        }

		#endregion (------  Private Methods  ------)

    }
}
