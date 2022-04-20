using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using AnignoLibrary.UI.Misc;
using System.ComponentModel;

namespace AnignoLibrary.UI.Forms
{
    public class AnignoForm : Form
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoForm";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private float _backgroundGradientAngle = 30;
        private int _mouseX;
        private int _mouseY;
        private int _borderWidth = 3;
        private int _headerHeaight = 30;
        private int _controlsWidth = 100;

        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowMaximize;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowMinimize;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowClose;
        private Color _backgroundGradientFirst = SystemColors.Control;
        private Color _backgroundGradientSecond = SystemColors.ControlDark;
        private Color _headerTextColor = Color.White;
        private Color _borderColor = Color.Black;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoForm()
        {
            InitializeComponent();
        }

		#endregion (------  Constructors  ------)

		#region (------  Overridden Properties  ------)

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Refresh();
            }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public float BackgroundGradientAngle
        {
            get { return _backgroundGradientAngle; }
            set
            {
                _backgroundGradientAngle = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public int HeaderHeaight
        {
            get { return _headerHeaight; }
            set
            {
                _headerHeaight = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color BackgroundGradientFirst
        {
            get { return _backgroundGradientFirst; }
            set
            {
                _backgroundGradientFirst = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundGradientSecond
        {
            get { return _backgroundGradientSecond; }
            set
            {
                _backgroundGradientSecond = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color HeaderTextColor
        {
            get { return _headerTextColor; }
            set
            {
                _headerTextColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Refresh();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        private void buttonRoundedGlowClose_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Close();
        }

        private void buttonRoundedGlowMaximize_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            
        }

        private void buttonRoundedGlowMinimize_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseX = e.X;
            _mouseY = e.Y;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //Resize cursor set
            if (e.X > Width - 40 && e.Y > Height - 40)
            {
                Cursor = Cursors.SizeNWSE;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (e.X > Width - 40 && e.Y > Height - 40)
                {
                    //Resize
                    Width = e.X;
                    Height = e.Y;
                }
                else if(e.Y<HeaderHeaight+1)
                {
                    //Move
                    Left += e.X - _mouseX;
                    Top += e.Y - _mouseY;
                }
            }
            else
            {
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Pen penBorder = new Pen(BorderColor);
            LinearGradientBrush brushBackGround = new LinearGradientBrush(ClientRectangle, BackgroundGradientFirst, BackgroundGradientSecond, BackgroundGradientAngle);
            DrawBackGround(e.Graphics, brushBackGround);
            DrawBorder(e.Graphics, penBorder);
            DrawHeader(e.Graphics);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
            DrawControls();
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void DrawBackGround(Graphics g, Brush brush)
        {
            g.FillRectangle(brush, ClientRectangle);
        }

        private void DrawBorder(Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            g.DrawRectangle(pen, BorderWidth, BorderWidth, Width - BorderWidth * 2 - 1, Height - BorderWidth * 2 - 1);
        }

        private void DrawControls()
        {
            buttonRoundedGlowClose.BackgroundColorFirst = buttonRoundedGlowMaximize.BackgroundColorFirst = buttonRoundedGlowMinimize.BackgroundColorFirst = BackgroundGradientFirst;
            buttonRoundedGlowClose.BackgroundColorSecond = buttonRoundedGlowMaximize.BackgroundColorSecond = buttonRoundedGlowMinimize.BackgroundColorSecond = BackgroundGradientSecond;
            buttonRoundedGlowClose.Top = buttonRoundedGlowMaximize.Top = buttonRoundedGlowMinimize.Top = BorderWidth + 1;
            buttonRoundedGlowClose.Left = Width - BorderWidth - 1 - buttonRoundedGlowClose.Width;
            buttonRoundedGlowMaximize.Left = buttonRoundedGlowClose.Left - buttonRoundedGlowMaximize.Width - 1;
            buttonRoundedGlowMinimize.Left = buttonRoundedGlowMaximize.Left - buttonRoundedGlowMinimize.Width - 1;
        }

        private void DrawHeader(Graphics g)
        {
            int headerWidth = Width - BorderWidth - _controlsWidth;
            UIHelper.FillLinearGradientRoundedRectangle(g, BorderWidth + 1, BorderWidth + 1,BorderWidth + 1+ headerWidth, BorderWidth+1+ HeaderHeaight, BackgroundGradientFirst, BackgroundGradientSecond, 90, HeaderHeaight);
            SolidBrush brushText=new SolidBrush(HeaderTextColor);
            UIHelper.DrawStringCenterPoint(Text,g,Font,brushText,Width/2f-_controlsWidth/2f,_headerHeaight/2f+BorderWidth);
        }

        private void InitializeComponent()
        {
            this.buttonRoundedGlowMaximize = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowMinimize = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowClose = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.SuspendLayout();
            // 
            // buttonRoundedGlowMaximize
            // 
            this.buttonRoundedGlowMaximize.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowMaximize.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRoundedGlowMaximize.BackgroundColorSecond = System.Drawing.Color.Gray;
            this.buttonRoundedGlowMaximize.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowMaximize.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowMaximize.BorderVisible = false;
            this.buttonRoundedGlowMaximize.ButtonText = "[ ]";
            this.buttonRoundedGlowMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowMaximize.GlowAlpha = 200;
            this.buttonRoundedGlowMaximize.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowMaximize.Location = new System.Drawing.Point(509, 1);
            this.buttonRoundedGlowMaximize.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRoundedGlowMaximize.Name = "buttonRoundedGlowMaximize";
            this.buttonRoundedGlowMaximize.RoundedCornersRadious = 10;
            this.buttonRoundedGlowMaximize.Size = new System.Drawing.Size(25, 20);
            this.buttonRoundedGlowMaximize.TabIndex = 5;
            this.buttonRoundedGlowMaximize.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowMaximize_OnButtonRoundedGlowMouseClick);
            // 
            // buttonRoundedGlowMinimize
            // 
            this.buttonRoundedGlowMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowMinimize.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRoundedGlowMinimize.BackgroundColorSecond = System.Drawing.Color.Gray;
            this.buttonRoundedGlowMinimize.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowMinimize.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowMinimize.BorderVisible = false;
            this.buttonRoundedGlowMinimize.ButtonText = "_";
            this.buttonRoundedGlowMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowMinimize.GlowAlpha = 200;
            this.buttonRoundedGlowMinimize.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowMinimize.Location = new System.Drawing.Point(483, 1);
            this.buttonRoundedGlowMinimize.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRoundedGlowMinimize.Name = "buttonRoundedGlowMinimize";
            this.buttonRoundedGlowMinimize.RoundedCornersRadious = 10;
            this.buttonRoundedGlowMinimize.Size = new System.Drawing.Size(25, 20);
            this.buttonRoundedGlowMinimize.TabIndex = 4;
            this.buttonRoundedGlowMinimize.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowMinimize_OnButtonRoundedGlowMouseClick);
            // 
            // buttonRoundedGlowClose
            // 
            this.buttonRoundedGlowClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowClose.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRoundedGlowClose.BackgroundColorSecond = System.Drawing.Color.Gray;
            this.buttonRoundedGlowClose.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowClose.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowClose.BorderVisible = false;
            this.buttonRoundedGlowClose.ButtonText = "X";
            this.buttonRoundedGlowClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowClose.GlowAlpha = 200;
            this.buttonRoundedGlowClose.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowClose.Location = new System.Drawing.Point(535, 1);
            this.buttonRoundedGlowClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRoundedGlowClose.Name = "buttonRoundedGlowClose";
            this.buttonRoundedGlowClose.RoundedCornersRadious = 10;
            this.buttonRoundedGlowClose.Size = new System.Drawing.Size(25, 20);
            this.buttonRoundedGlowClose.TabIndex = 3;
            this.buttonRoundedGlowClose.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowClose_OnButtonRoundedGlowMouseClick);
            // 
            // AnignoForm
            // 
            this.ClientSize = new System.Drawing.Size(564, 317);
            this.Controls.Add(this.buttonRoundedGlowMaximize);
            this.Controls.Add(this.buttonRoundedGlowMinimize);
            this.Controls.Add(this.buttonRoundedGlowClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "AnignoForm";
            this.ResumeLayout(false);

        }

		#endregion (------  Private Methods  ------)

    }
}