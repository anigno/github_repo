using System;

namespace AnignoraFinanceAnalyzer5.Systems.SystemOptions
{
    public class BlackAndScholes
    {
        #region (------  Enums  ------)
        public enum CallPutEnum
        {
            Call,
            Put
        }
        #endregion (------  Enums  ------)

        #region (------  Public Methods  ------)
        public double Calculate(
                    CallPutEnum p_callPutFlag,
                    double p_stockPrice,
                    double p_strikePrice,
                    double p_yearsToMaturity,
                    double p_riskFree,
                    double p_volatility)
        {
            double dBlackScholes = 0.0;
            double d1 = (Math.Log(p_stockPrice / p_strikePrice) + (p_riskFree + p_volatility *
                p_volatility / 2.0) * p_yearsToMaturity) / (p_volatility * Math.Sqrt(p_yearsToMaturity));
            double d2 = d1 - p_volatility * Math.Sqrt(p_yearsToMaturity);
            switch (p_callPutFlag)
            {
                case CallPutEnum.Call:
                    dBlackScholes = p_stockPrice * cnd(d1) - p_strikePrice * Math.Exp(-p_riskFree *
                        p_yearsToMaturity) * cnd(d2);
                    break;
                case CallPutEnum.Put:
                    dBlackScholes = p_strikePrice * Math.Exp(-p_riskFree * p_yearsToMaturity) *
                        cnd(-d2) - p_stockPrice * cnd(-d1);
                    break;
            }
            return dBlackScholes;
        }
        #endregion (------  Public Methods  ------)

        #region (------  Private Methods  ------)
        private double cnd(double p_x)
        {
            const double A1 = 0.31938153;
            const double A2 = -0.356563782;
            const double A3 = 1.781477937;
            const double A4 = -1.821255978;
            const double A5 = 1.330274429;
            double l = Math.Abs(p_x);
            double k = 1.0 / (1.0 + 0.2316419 * l);
            double dCnd = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) *
                          Math.Exp(-l * l / 2.0) * (A1 * k + A2 * k * k + A3 * Math.Pow(k, 3.0) +
                                                    A4 * Math.Pow(k, 4.0) + A5 * Math.Pow(k, 5.0));
            if (p_x < 0)
            {
                return 1.0 - dCnd;
            }
            return dCnd;
        }
        #endregion (------  Private Methods  ------)
    }
}