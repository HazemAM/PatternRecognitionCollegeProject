﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PatternRecognition
{
    class Class
    {
       public double[] mu;
       public double[] sigma;
       public Color color;
       public int maxW;
       public Class(double[] mu, double[] sigma,Color color,int maxW)
        {
            this.mu = mu;
            this.sigma = sigma;
            this.color = color;
            this.maxW = maxW;
        }
    }
}
