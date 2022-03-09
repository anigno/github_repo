using System;

namespace SymbolAnalysis.Creatures
{
    public static class RandomGenerator
    {
        #region Public Methods

        /// <summary>
        /// Returns randomized -1 or +1
        /// </summary>
        public static sbyte NextPlusMinus()
        {
            sbyte si = (sbyte) (s_random.Next(0, 2)*2 - 1);
            return si;
        }

        /// <summary>
        /// Returns randomized value between p_minValue and p_maxValue-1
        /// </summary>
        public static int Next(int p_minValue, int p_maxValue)
        {
            return s_random.Next(p_minValue, p_maxValue);
        }

        #endregion

        #region Fields

        private static readonly int s_seed = (int) (DateTime.Now.Ticks%1000000000);
        private static readonly Random s_random = new Random(s_seed);

        #endregion
    }
}