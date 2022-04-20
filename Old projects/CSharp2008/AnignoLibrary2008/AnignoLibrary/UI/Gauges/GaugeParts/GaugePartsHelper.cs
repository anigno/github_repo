using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.UI.Gauges.GaugeParts
{
    public static class GaugePartsHelper
    {
        public static float Radian(float degree)
        {
            return degree / 57.29578f;
        }

    }
}
