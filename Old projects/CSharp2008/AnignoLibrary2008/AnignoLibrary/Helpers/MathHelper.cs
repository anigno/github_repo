using System;

namespace AnignoLibrary.Helpers
{
    public class MathHelper
    {
        /// <summary>
        /// Fix the problem of inaccurate float numbers (E.G. 5.999995 changed to 6)
        /// </summary>
        public static float FixFloat(float f)
        {
            long l = (long)(f * 10000000);
            f = l / 10000000f;
            return f;
        }

        /// <summary>
        /// Gets the Cosine value from a degree angle
        /// </summary>
        public static float CosA(float angle)
        {
            return (float)Math.Cos(angle / 57.295779);
        }

        /// <summary>
        /// Gets the Sine value from a degree angle
        /// </summary>
        public static float SinA(float angle)
        {
            return (float)Math.Sin(angle / 57.295779);
        }

    }
}
