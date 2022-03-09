using System;

namespace WorkingWithExcel
{
    public class BlackAndScholes1
    {
        public double GetCallPrice(float p_spot, float p_strike, float p_interestRate, float p_income, float p_volatility, float p_expiry)
        {
            double a = Math.Log(p_spot / p_strike);
            double bCall = (p_interestRate - p_income + 0.5 * Math.Pow(p_volatility, 2)) * p_expiry;
            double bPut = (p_interestRate - p_income - 0.5 * Math.Pow(p_volatility, 2)) * p_expiry;
            double c = p_volatility * Math.Sqrt(p_expiry);
            double d1 = (a + bCall) / c;
            double d2 = (a + bPut) / c;
            double price = p_spot * NormsDist(d1) - p_strike * Math.Exp(-p_interestRate * p_expiry) * NormsDist(d2);
            return price;
        }
        public double GetPutPrice(float p_spot, float p_strike, float p_interestRate, float p_income, float p_volatility, float p_expiry)
        {
            double a = Math.Log(p_spot / p_strike);
            double bCall = (p_interestRate - p_income + 0.5 * Math.Pow(p_volatility, 2)) * p_expiry;
            double bPut = (p_interestRate - p_income - 0.5 * Math.Pow(p_volatility, 2)) * p_expiry;
            double c = p_volatility * Math.Sqrt(p_expiry);
            double d1 = (a + bCall) / c;
            double d2 = (a + bPut) / c;
            double price = p_strike * Math.Exp(-p_interestRate * p_expiry) * NormsDist(-d2) - p_spot * NormsDist(-d1);
            return price;
        }


        public double Norm(double p_z) //normal probability density function
        {
            double normsdistval = 1 / (Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(p_z, 2) / 2);
            return normsdistval;
        }
        public double NormsDist(double p_x) //normal cumulative density function
        {
            const double B0 = 0.2316419;
            const double B1 = 0.319381530;
            const double B2 = -0.356563782;
            const double B3 = 1.781477937;
            const double B4 = -1.821255978;
            const double B5 = 1.330274429;
            double t = 1 / (1 + B0 * p_x);
            double sigma = 1 - Norm(p_x) * (B1 * t + B2 * Math.Pow(t, 2) + B3 * Math.Pow(t, 3)
            + B4 * Math.Pow(t, 4) + B5 * Math.Pow(t, 5));
            return sigma;
        }
    }
}
