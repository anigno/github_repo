using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using AnignoLibrary.Misc.Hook;
using Microsoft.Win32;

namespace AnignoLibrary.UI.Forms
{
    /// <summary>
    /// Borderless, Shrinking, Movable
    /// </summary>
    public class FormBorderless : Form
    {

		#region Const Fields (2) 

        private const string CATEGORY_STRING = " FormBorderless";
        const string USER_REGISTRY_ROOT = @"HKEY_CURRENT_USER\AnignoApplicationData\FormBorderLess\";

		#endregion Const Fields 

		#region Fields (12) 


        private string _savedLocationFileName = "FormBorderless.dat";

        private bool _ShrinkHeaderRight;
        private bool _isShrinked;
        private bool _autoShrink=false;
        private int _mouseX;
        private int _mouseY;
        private int _normalWidth;
        private int _normalHeight;

        private IContainer components;
        private Label labelShrinkHeader;
        private readonly MouseHookController _mouseHook = new MouseHookController();
        private Timer timerMouseCheck;

		#endregion Fields 

		#region Constructors (1) 

        public FormBorderless()
        {
            InitializeComponent();
            _normalWidth = Width;
            _normalHeight = Height;
        }

		#endregion Constructors 

		#region Properties (3) 


        [Category(CATEGORY_STRING)]
        public string ShrinkHeader
        {
            get { return labelShrinkHeader.Text; }
            set { labelShrinkHeader.Text = value; }
        }


        [Category(CATEGORY_STRING)]
        public bool AutoShrink
        {
            get { return _autoShrink; }
            set { _autoShrink = value; }
        }

        [Category(CATEGORY_STRING)]
        public bool ShrinkHeaderRight
        {
            get { return _ShrinkHeaderRight; }
            set { _ShrinkHeaderRight = value; }
        }


		#endregion Properties 

		#region Event Handlers (1) 

        private void timerMouseCheck_Tick(object sender, EventArgs e)
        {
            if (AutoShrink && !DesignMode)
            {
                CheckShrinkPossible();
            }
        }

		#endregion Event Handlers 

		#region Overridden Methods (4) 

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!DesignMode)
            {
                string saveName = GetType().ToString();
                UnShrinkIfNeeded();
                Registry.SetValue(USER_REGISTRY_ROOT + saveName, "X", Left.ToString());
                Registry.SetValue(USER_REGISTRY_ROOT + saveName, "Y", Top.ToString());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                string saveName = GetType().ToString();
                string sX = (string) Registry.GetValue(USER_REGISTRY_ROOT + saveName, "X", -1);
                string sY = (string) Registry.GetValue(USER_REGISTRY_ROOT + saveName, "Y", -1);
                if (sX != null) Left = int.Parse(sX);
                if (sY != null) Top = int.Parse(sY);
            }

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseX = e.X;
            _mouseY = e.Y;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _mouseX;
                Top += e.Y - _mouseY;
            }
        }

		#endregion Overridden Methods 

		#region Private Methods (3) 

        private void CheckShrinkPossible()
        {
            Point p = _mouseHook.GetMousePosition();
            if (p.X < Left || p.X > Left + Width || p.Y < Top || p.Y > Top + Height)
            {
                if (!_isShrinked)
                {
                    //Shrink the form
                    labelShrinkHeader.Visible = true;
                    _normalWidth = Width;
                    _normalHeight = Height;
                    _isShrinked = true;
                    if (ShrinkHeaderRight)
                    {
                        Left += _normalWidth - labelShrinkHeader.Width;
                    }
                    Width = labelShrinkHeader.Width;
                    Height = labelShrinkHeader.Height;
                }
            }
            else
            {
                UnShrinkIfNeeded();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelShrinkHeader = new System.Windows.Forms.Label();
            this.timerMouseCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelShrinkHeader
            // 
            this.labelShrinkHeader.AutoSize = true;
            this.labelShrinkHeader.Location = new System.Drawing.Point(0, 0);
            this.labelShrinkHeader.Name = "labelShrinkHeader";
            this.labelShrinkHeader.Size = new System.Drawing.Size(79, 13);
            this.labelShrinkHeader.TabIndex = 0;
            this.labelShrinkHeader.Text = "FormBorderless";
            this.labelShrinkHeader.Visible = false;
            // 
            // timerMouseCheck
            // 
            this.timerMouseCheck.Enabled = true;
            this.timerMouseCheck.Interval = 500;
            this.timerMouseCheck.Tick += new System.EventHandler(this.timerMouseCheck_Tick);
            // 
            // FormBorderless
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.labelShrinkHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBorderless";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void UnShrinkIfNeeded()
        {
            if (_isShrinked)
            {
                //Unshrink the form
                labelShrinkHeader.Visible = false;
                if (ShrinkHeaderRight)
                {
                    Left -= _normalWidth - labelShrinkHeader.Width;
                }
                Width = _normalWidth;
                Height = _normalHeight;
                _isShrinked = false;
            }
        }

		#endregion Private Methods 

    }
}