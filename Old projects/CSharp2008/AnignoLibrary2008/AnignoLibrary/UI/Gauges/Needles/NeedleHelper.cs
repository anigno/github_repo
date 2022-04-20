using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.UI.Gauges.Needles
{
    public static class NeedleHelper
    {
        public static float PI
        {
            get { return (float)Math.PI; }
        }

        public static float Cos(float radian)
        {
            return (float)Math.Cos(radian);
        }

        public static float Sin(float radian)
        {
            return (float)Math.Sin(radian);
        }

        public static float Angle(float radian)
        {
            return radian * 57.29578f;
        }

        public static float Radian(float angle)
        {
            return angle / 57.29578f;
        }
    }
}