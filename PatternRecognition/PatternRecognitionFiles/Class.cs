using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PatternRecognition
{
    class Class
    {
        public double [] mu;
        public double [] sigma;
        public double [,] samples;
        public Color color;
        public Class(double [] mu, double [] sigma, Color color,double [,] samples)//sample is 3*2 matrix where 0 ,1,2 color other arr for position
        {
            this.mu = mu;
            this.samples = samples;
            this.sigma = sigma;
            this.color = color;
        }
    }
}
