using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace AnignoLibrary.UI.Buttons.VistaButtons
{
    /// <summary>
    /// A replacement for the Windows Button Control.
    /// </summary>
    [DefaultEvent("Click")]
    public class VistaButton : System.Windows.Forms.UserControl
    {
        private const string CATEGORY_STRING = " VistaButton";
		#region (------  Enums  ------)

        /// <summary>
        /// A private enumeration that determines 
        /// the mouse state in relation to the 
        /// current instance of the control.
        /// </summary>
        enum State {None, Hover, Pressed};
        /// <summary>
        /// A public enumeration that determines whether
        /// the button background is painted when the 
        /// mouse is not inside the ClientArea.
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// Draw the button as normal
            /// </summary>
            Default, 
            /// <summary>
            /// Only draw the background on mouse over.
            /// </summary>
            Flat
        };

		#endregion (------  Enums  ------)

		#region (------  Fields  ------)


        private string mText;

        private bool calledbykey = false;
        private int mGlowAlpha = 0;
        private int mCornerRadius = 8;

        private Color mForeColor = Color.White;
        private Color mHighlightColor = Color.White;
        private Color mButtonColor = Color.Black;
        private Color mGlowColor = Color.FromArgb(141,189,255);
        private Color mBaseColor = Color.Black;
        private ContentAlignment mTextAlign = ContentAlignment.MiddleCenter;
        private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;
        private Image mImage;
        private Image mBackImage;
        private Size mImageSize = new Size(24,24);
        private State mButtonState = State.None;
        private Style mButtonStyle = Style.Default;
        private System.ComponentModel.Container components = null;
        private Timer mFadeIn = new Timer();
        private Timer mFadeOut = new Timer();

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        /// <summary>
        /// Initialize the component with it's
        /// default settings.
        /// </summary>
        public VistaButton()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            base.BackColor = Color.Transparent;
            mFadeIn.Interval = 30;
            mFadeOut.Interval = 30;
        }

		#endregion (------  Constructors  ------)

		#region (------  Overridden Properties  ------)

        /// <summary>
        /// The color with which the text is drawn.
        /// </summary>
        [Category("Text"), 
         Browsable(true),
         DefaultValue(typeof(Color),"White"),
         Description("The color with which the text is drawn.")]
        public override Color ForeColor
        {
            get { return mForeColor; }
            set { mForeColor = value; this.Invalidate(); }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Properties  ------)


        /// <summary>
        /// The text that is displayed on the button.
        /// </summary>
        [Category(CATEGORY_STRING),
         Description("The text that is displayed on the button.")]
        public string ButtonText
        {
            get { return mText; }
            set { mText = value; this.Invalidate(); }
        }


        /// <summary>
        /// The radius for the button corners. The 
        /// greater this value is, the more 'smooth' 
        /// the corners are. This property should
        ///  not be greater than half of the 
        ///  controls height.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(8),
         Description("The radius for the button corners. The " +
                     "greater this value is, the more 'smooth' " +
                     "the corners are. This property should " +
                     "not be greater than half of the " +
                     "controls height.")]
        public int CornerRadius
        {
            get { return mCornerRadius; }
            set { mCornerRadius = value; this.Invalidate(); }
        }


        /// <summary>
        /// The colour of the highlight on the top of the button.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(Color), "White"),
         Description("The colour of the highlight on the top of the button.")]
        public Color HighlightColor
        {
            get { return mHighlightColor; }
            set { mHighlightColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// The bottom color of the button that 
        /// will be drawn over the base color.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(Color), "Black"), 
         Description("The bottom color of the button that " + 
                     "will be drawn over the base color.")]
        public Color ButtonColor
        {
            get { return mButtonColor; }
            set { mButtonColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// The colour that the button glows when
        /// the mouse is inside the client area.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(Color), "141,189,255"), 
         Description("The colour that the button glows when " + 
                     "the mouse is inside the client area.")]
        public Color GlowColor
        {
            get { return mGlowColor; }
            set { mGlowColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// The backing color that the rest of 
        /// the button is drawn. For a glassier 
        /// effect set this property to Transparent.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(Color), "Black"), 
         Description("The backing color that the rest of" + 
                     "the button is drawn. For a glassier " + 
                     "effect set this property to Transparent.")]
        public Color BaseColor
        {
            get { return mBaseColor; }
            set { mBaseColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// The alignment of the button text
        /// that is displayed on the control.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(ContentAlignment),"MiddleCenter"),
         Description("The alignment of the button text " + 
                     "that is displayed on the control.")]
        public ContentAlignment TextAlign
        {
            get { return mTextAlign; }
            set { mTextAlign = value; this.Invalidate(); }
        }

        /// <summary>
        /// The alignment of the image 
        /// in relation to the button.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(ContentAlignment),"MiddleLeft"),
         Description("The alignment of the image " + 
                     "in relation to the button.")]
        public ContentAlignment ImageAlign
        {
            get { return mImageAlign; }
            set { mImageAlign = value; this.Invalidate(); }
        }

        /// <summary>
        /// The image displayed on the button that 
        /// is used to help the user identify
        /// it's function if the text is ambiguous.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(null),
         Description("The image displayed on the button that " +
                     "is used to help the user identify" + 
                     "it's function if the text is ambiguous.")]
        public Image Image
        {
            get { return mImage; }
            set { mImage = value; this.Invalidate(); }
        }

        /// <summary>
        /// The background image for the button, 
        /// this image is drawn over the base 
        /// color of the button.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(null), 
         Description("The background image for the button, " + 
                     "this image is drawn over the base " + 
                     "color of the button.")]
        public Image BackImage
        {
            get { return mBackImage; }
            set { mBackImage = value; this.Invalidate(); }
        }

        /// <summary>
        /// The size of the image to be displayed on the
        /// button. This property defaults to 24x24.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(Size),"24, 24"),
         Description("The size of the image to be displayed on the" + 
                     "button. This property defaults to 24x24.")]
        public Size ImageSize
        {
            get { return mImageSize; }
            set { mImageSize = value; this.Invalidate(); }
        }

        /// <summary>
        /// Sets whether the button background is drawn 
        /// while the mouse is outside of the client area.
        /// </summary>
        [Category(CATEGORY_STRING), 
         DefaultValue(typeof(Style),"Default"),
         Description("Sets whether the button background is drawn " +
                     "while the mouse is outside of the client area.")]
        public Style ButtonStyle
        {
            get { return mButtonStyle; }
            set { mButtonStyle = value; this.Invalidate(); }
        }


		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        private void mFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.ButtonStyle == Style.Flat) {mGlowAlpha = 0;}
            if (mGlowAlpha + 30 >= 255)
            {
                mGlowAlpha = 255;
                mFadeIn.Stop();
            }
            else
            {
                mGlowAlpha += 30;
            }
            this.Invalidate();
        }

        private void mFadeOut_Tick(object sender, EventArgs e)
        {
            if (this.ButtonStyle == Style.Flat) {mGlowAlpha = 0;}
            if (mGlowAlpha - 30 <= 0)
            {
                mGlowAlpha = 0;
                mFadeOut.Stop();
            }
            else
            {
                mGlowAlpha -= 30;
            }
            this.Invalidate();
        }

        private void VistaButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MouseEventArgs m = new MouseEventArgs(MouseButtons.Left,0,0,0,0);
                VistaButton_MouseDown(sender, m);
            }
        }

        private void VistaButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                MouseEventArgs m = new MouseEventArgs(MouseButtons.Left,0,0,0,0);
                calledbykey = true;
                VistaButton_MouseUp(sender, m);
            }
        }

        private void VistaButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mButtonState = State.Pressed;
                if (this.mButtonStyle != Style.Flat) { mGlowAlpha = 255; }
                mFadeIn.Stop();
                mFadeOut.Stop();
                this.Invalidate();
            }
        }

        private void VistaButton_MouseEnter(object sender, EventArgs e)
        {
            mButtonState = State.Hover;
            mFadeOut.Stop();
            mFadeIn.Start();
        }

        private void VistaButton_MouseLeave(object sender, EventArgs e)
        {
            mButtonState = State.None;
            if (this.mButtonStyle == Style.Flat) { mGlowAlpha = 0; }
            mFadeIn.Stop();
            mFadeOut.Start();
        }

        private void VistaButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                mButtonState = State.Hover;
                mFadeIn.Stop();
                mFadeOut.Stop();
                this.Invalidate();
                if (calledbykey == true) {this.OnClick(EventArgs.Empty); calledbykey = false;}
            }
        }

        private void VistaButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(e.Graphics);
            DrawHighlight(e.Graphics);
            DrawImage(e.Graphics);
            DrawText(e.Graphics);
            DrawGlow(e.Graphics);
            DrawOuterStroke(e.Graphics);
            DrawInnerStroke(e.Graphics);
        }

        private void VistaButton_Resize(object sender, EventArgs e)
        {
            Rectangle r = this.ClientRectangle;
            r.X -= 1; r.Y -= 1;
            r.Width += 2; r.Height += 2;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                this.Region = new Region(rr);
            }
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        /// <summary>
        /// Release resources used by the control.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        /// <summary>
        /// Draws the background for the control
        /// using the background image and the 
        /// BaseColor.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawBackground(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None){return;}
            int alpha = (mButtonState == State.Pressed) ? 204 : 127;
            Rectangle r = this.ClientRectangle;
            r.Width--; r.Height--;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (SolidBrush sb = new SolidBrush(this.BaseColor))
                {
                    g.FillPath(sb, rr);
                }
                SetClip(g);
                if (this.BackImage != null){g.DrawImage(this.BackImage, this.ClientRectangle);}
                g.ResetClip();
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(alpha, this.ButtonColor)))
                {
                    g.FillPath(sb, rr);
                }
            }
        }

        /// <summary>
        /// Draws the glow for the button when the
        /// mouse is inside the client area using
        /// the GlowColor property.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawGlow(Graphics g)
        {
            if (this.mButtonState == State.Pressed){return;}
            SetClip(g);
            using (GraphicsPath glow = new GraphicsPath())
            {
                glow.AddEllipse(-5,this.Height / 2 - 10, this.Width + 11, this.Height + 11);
                using (PathGradientBrush gl = new PathGradientBrush(glow))
                {
                    gl.CenterColor = Color.FromArgb(mGlowAlpha, this.GlowColor);
                    gl.SurroundColors = new Color[] {Color.FromArgb(0, this.GlowColor)};
                    g.FillPath(gl, glow);
                }
            }
            g.ResetClip();
        }

        /// <summary>
        /// Draws the Highlight over the top of the
        /// control using the HightlightColor.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawHighlight(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None){return;}
            int alpha = (mButtonState == State.Pressed) ? 60 : 150;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height / 2);
            using (GraphicsPath r = RoundRect(rect, CornerRadius, CornerRadius, 0, 0))
            {
                using (LinearGradientBrush lg = new LinearGradientBrush(r.GetBounds(), 
                                                                        Color.FromArgb(alpha, this.HighlightColor),
                                                                        Color.FromArgb(alpha / 3, this.HighlightColor), 
                                                                        LinearGradientMode.Vertical))
                {
                    g.FillPath(lg, r);
                }
            }
        }

	        /// <summary>
        /// Draws the image for the button
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawImage(Graphics g)
        {
            if (this.Image == null) {return;}
            Rectangle r = new Rectangle(8,8,this.ImageSize.Width,this.ImageSize.Height);
            switch (this.ImageAlign)
            {
                case ContentAlignment.TopCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2,8,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.TopRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width,8,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    r = new Rectangle(8,this.Height / 2 - this.ImageSize.Height / 2,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2,this.Height / 2 - this.ImageSize.Height / 2,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width,this.Height / 2 - this.ImageSize.Height / 2,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    r = new Rectangle(8,this.Height - 8 - this.ImageSize.Height,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    r = new Rectangle(this.Width / 2 - this.ImageSize.Width / 2,this.Height - 8 - this.ImageSize.Height,this.ImageSize.Width,this.ImageSize.Height);
                    break;
                case ContentAlignment.BottomRight:
                    r = new Rectangle(this.Width - 8 - this.ImageSize.Width,this.Height - 8 - this.ImageSize.Height,this.ImageSize.Width,this.ImageSize.Height);
                    break;
            }
            g.DrawImage(this.Image,r);
        }

        /// <summary>
        /// Draws the inner border for the control
        /// using the HighlightColor property.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawInnerStroke(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None){return;}
            Rectangle r = this.ClientRectangle;
            r.X++; r.Y++;
            r.Width -= 3; r.Height -= 3;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (Pen p = new Pen(this.HighlightColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }

        /// <summary>
        /// Draws the outer border for the control
        /// using the ButtonColor property.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawOuterStroke(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None){return;}
            Rectangle r = this.ClientRectangle;
            r.Width -= 1; r.Height -= 1;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (Pen p = new Pen(this.ButtonColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }

        /// <summary>
        /// Draws the text for the button.
        /// </summary>
        /// <param name="g">The graphics object used in the paint event.</param>
        private void DrawText(Graphics g)
        {
            StringFormat sf = StringFormatAlignment(this.TextAlign);
            Rectangle r = new Rectangle(8,8,this.Width - 17,this.Height - 17);
            g.DrawString(this.ButtonText,this.Font,new SolidBrush(this.ForeColor),r,sf);
        }

        private void InitializeComponent()
        {
            // 
            // VistaButton
            // 
            this.Name = "VistaButton";
            this.Size = new System.Drawing.Size(100, 32);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VistaButton_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.VistaButton_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VistaButton_KeyDown);
            this.MouseEnter += new System.EventHandler(this.VistaButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.VistaButton_MouseLeave);
            this.MouseUp +=new MouseEventHandler(VistaButton_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VistaButton_MouseDown);
            this.GotFocus +=new EventHandler(VistaButton_MouseEnter);
            this.LostFocus +=new EventHandler(VistaButton_MouseLeave);
            this.mFadeIn.Tick += new EventHandler(mFadeIn_Tick);
            this.mFadeOut.Tick += new EventHandler(mFadeOut_Tick);
            this.Resize +=new EventHandler(VistaButton_Resize);
        }

        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            GraphicsPath rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }

        private void SetClip(Graphics g)
        {
            Rectangle r = this.ClientRectangle;
            r.X++; r.Y++; r.Width-=3; r.Height-=3;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                g.SetClip(rr);
            }		
        }

        private StringFormat StringFormatAlignment(ContentAlignment textalign)
        {
            StringFormat sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }

		#endregion (------  Private Methods  ------)

    }
}