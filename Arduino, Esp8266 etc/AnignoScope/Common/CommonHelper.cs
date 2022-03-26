using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class CommonHelper
    {
        public static float Map(float p_value, float p_fromLow, float p_fromHigh, float p_toLow, float p_toHigh)
        {
            return (p_value - p_fromLow) * (p_toHigh - p_toLow) / (p_fromHigh - p_fromLow) + p_toLow;
        }

        public static float Map(byte p_value, float p_fromLow, float p_fromHigh, float p_toLow, float p_toHigh)
        {
            return Map((float)p_value, p_fromLow, p_fromHigh, p_toLow, p_toHigh);
        }

        public static float[] Map(byte[] p_values, float p_fromLow, float p_fromHigh, float p_toLow, float p_toHigh)
        {
            float[] floats = new float[p_values.Length];
            for (int i = 0; i < p_values.Length; i++)
            {
                floats[i] = Map(p_values[i], p_fromLow, p_fromHigh, p_toLow, p_toHigh);
            }
            return floats;
        }


    }
}
