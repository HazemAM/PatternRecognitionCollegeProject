using System;
using System.Collections.Generic;
using System.Text;

namespace PatternRecognition
{
    class Distributions
    {
        public static double Normal(double x, double mu, double sigma)
        {
            return (1 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Exp(-Math.Pow((x - mu), 2) / (2 * (Math.Pow(sigma,2))));
        }
    }
}
