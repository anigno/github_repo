using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnignoLibrary.Helpers;

namespace AnignoLibrary.UI.Multimedia.AudioVolumeGraphing
{
    public partial class VolumeGraph : UserControl
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " AudioFileVolumeGraph";

		#endregion Const Fields 

		#region Fields (8) 

        private byte[] mBytesBuffer;

        private string mHeader;

        private float mSkipVolume = 0;
        private float mIntSkip;
        private float mOutSkip;
        private int mBytesPerVerticalLine;

        private Bitmap mBackBuffer;
        private Color mGridColor = Color.LightGray;
        private Color mIntroColor = Color.Yellow;

		#endregion Fields 

		#region Constructors (1) 

        public VolumeGraph()
        {
            InitializeComponent();
            base.MinimumSize=new Size(50,20);
            mBackBuffer=new Bitmap(Width,Height);
        }

		#endregion Constructors 

		#region Read only Properties (2) 

        [Category(CATEGORY_STRING)]
        public float IntSkip
        {
            get { return mIntSkip; }
        }

        [Category(CATEGORY_STRING)]
        public float OutSkip
        {
            get { return mOutSkip; }
        }

		#endregion Read only Properties 

		#region Properties (6) 


        [Category(CATEGORY_STRING)]
        [Browsable(false)]
        public byte[] BytesBuffer
        {
            get { return mBytesBuffer; }
            set
            {
                mBytesBuffer = value;
                DrawBackBuffer();
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public string Header
        {
            get { return mHeader; }
            set
            {
                mHeader = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public float SkipVolume
        {
            get { return mSkipVolume; }
            set { mSkipVolume = value;
                DrawBackBuffer();
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public int BytesPerVerticalLine
        {
            get { return mBytesPerVerticalLine; }
            set
            {
                if (mBytesPerVerticalLine < 0) return;
                mBytesPerVerticalLine = value;
                DrawBackBuffer();
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color GridColor
        {
            get { return mGridColor; }
            set
            {
                mGridColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color GraphColor
        {
            get { return ForeColor; }
            set
            {
                ForeColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color IntroColor
        {
            get { return mIntroColor; }
            set
            {
                mIntroColor = value;
                Refresh();
            }
        }

        #endregion Properties 

		#region Overridden Methods (2) 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            e.Graphics.DrawImageUnscaled(mBackBuffer,0,0);
            e.Graphics.DrawString(Header,Font,new SolidBrush(GridColor),0,0);
        }

        protected override void OnResize(EventArgs e)
        {
            if (mBackBuffer != null) mBackBuffer.Dispose();
            mBackBuffer = new Bitmap(Width, Height);
            DrawBackBuffer();
            Refresh();
            base.OnResize(e);
        }

		#endregion Overridden Methods 

		#region Private Methods (1) 



        private void DrawBackBuffer()
        {
            //Verify that back buffer will exists even if no OnSizeChanged event occured
            if (mBackBuffer == null)
            {
                mBackBuffer = new Bitmap(Width, Height);
            }
            Graphics g = Graphics.FromImage(mBackBuffer);
            g.Clear(BackColor);
            //Will return after clear if null
            if (BytesBuffer == null) return;
            Pen pen = new Pen(GridColor);
            //draw horizontal lines
            const int numberOfLines = 4;
            for (int a = Height / numberOfLines; a < Height - Height / numberOfLines+1; a += Height / numberOfLines)
            {
                g.DrawLine(pen,0,a,Width,a);
            }
            //Draw vertical lines
            if (BytesPerVerticalLine > 0)
            {
                float vLines = (float) BytesBuffer.Length/BytesPerVerticalLine;
                for (float a = 0; a < Width; a += Width / vLines)
                {
                    g.DrawLine(pen, a, 0, a, Height);
                }
            }
            //Draw the graph
            pen = new Pen(GraphColor);
            int bufLenToDrawWidthRatio = BytesBuffer.Length / Width;  //Ratio between the buffer length and the drawing width
            if (bufLenToDrawWidthRatio < 1) bufLenToDrawWidthRatio = 1;
            float xPrev = -1000;
            float yPrev = (float)Height/2;
            Dictionary<float,float> graph=new Dictionary<float, float>();
            float maxValue = 0;
            float[] skipArray = new float[BytesBuffer.Length / bufLenToDrawWidthRatio + 1];
            for (int i = 0; i < BytesBuffer.Length-bufLenToDrawWidthRatio; i += bufLenToDrawWidthRatio)
            {
                int avg = 0;
                for (int a = 0; a < bufLenToDrawWidthRatio; a++)
                {
                    avg += Math.Abs(BytesBuffer[a + i] - 128);
                }
                avg=avg/bufLenToDrawWidthRatio;
                float x = (float)Width / (BytesBuffer.Length-bufLenToDrawWidthRatio) * i;
                float y = (float)Height / 128 * (avg);
                graph.Add(x, y);
                if(y>maxValue)maxValue=y;
            }
            int b = 0;
            foreach (KeyValuePair<float,float> pair in graph)
            {
                float y = pair.Value * (Height / maxValue);
                g.DrawLine(pen, xPrev, Height- yPrev, pair.Key,Height- y);
                xPrev = pair.Key;
                skipArray[b++] = pair.Value/Height*128;
                yPrev = y;
            }
            mIntSkip = 0;
            mOutSkip = (float)BytesBuffer.Length / 8000;
            for (int a = 0; a < skipArray.Length; a++)
            {
                if (skipArray[a] > SkipVolume)
                {
                    mIntSkip=(float)a*bufLenToDrawWidthRatio/8000;
                    break;
                }
            }
            for (int a = skipArray.Length-1; a >= 0; a--)
            {
                if (skipArray[a] > SkipVolume)
                {
                    mOutSkip = (float)a * bufLenToDrawWidthRatio / 8000;
                    break;
                }
            }
            pen=new Pen(IntroColor);
            g.DrawLine(pen, IntSkip * 8000 / bufLenToDrawWidthRatio, 0, IntSkip * 8000 / bufLenToDrawWidthRatio, Height);
            g.DrawLine(pen, OutSkip * 8000 / bufLenToDrawWidthRatio, 0, OutSkip * 8000 / bufLenToDrawWidthRatio, Height);

            g.DrawString("in: " + StringHelper.GetTimeString((int)IntSkip) + " out: " + StringHelper.GetTimeString((int)OutSkip), Font, new SolidBrush(Color.Yellow), IntSkip * 8000 / bufLenToDrawWidthRatio+10, Height - Font.Height);
        }

		#endregion Private Methods 

    }
}
