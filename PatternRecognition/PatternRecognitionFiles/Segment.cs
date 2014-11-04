using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace PatternRecognition
{
    class Segment
    {
        private Class[] classes;
        private Bitmap img;
        private Bitmap res;
        public Segment(Class [] classes,Bitmap img)
        {
            this.classes = classes;
            this.img = img;
            Calc();
        }

        private void Calc()
        {
            double x;
            int index;
            Color temp;
            res=new Bitmap(img);
            int length=classes.Length;
            double[] pxw = new double[length];
            double[] pwx = new double[length];
            double Px = 0;
            for(int i=0;i<img.Width;i++)
                for(int j=0;j<img.Height;j++)
                {
                    temp=img.GetPixel(i,j);
                    x = (temp.R + temp.G + temp.B) / 3;
                    for (int k = 0; k < length; k++)
                        pxw[k] = Distributions.Normal(x, classes[k].mu, classes[k].sigma);
                    for (int k = 0; k < length; k++)
                        Px += pxw[k];
                    for (int k = 0; k < length; k++)
                        pwx[k] = pxw[k] / Px;
                    index = Array.IndexOf(pwx,Max(pwx));
                    res.SetPixel(i, j, classes[index].color);
                }
        }

        private double Max(double[] arr)
        {
            double max = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];
            return max;
        }
        public Bitmap getResult()
        {
            return res;
        }
    }
}
