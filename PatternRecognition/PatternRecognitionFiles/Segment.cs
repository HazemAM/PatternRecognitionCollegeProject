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
            int actions = 5;
            int index;
            Color temp;
            res=new Bitmap(img);
            int length=classes.Length;
            double[,] pxw = new double[3,length];
            double[] pxsw = new double[length];
            double[] pwx = new double[length];
            double[] risk = new double[actions];
            double[,] lamda = new double[,] { { 1, 2, 2, 2 }, { 2, 1, 2, 2 }, { 2, 2, 1, 2 }, { 2, 2, 2, 1 }, { 2, 2, 2, 2 } };
            double Px = 0;
            for(int i=0;i<img.Width;i++)
                for(int j=0;j<img.Height;j++)
                {
                    temp=img.GetPixel(i,j);
                    for (int k = 0; k < length; k++)
                    {
                        pxw[0,k] = Distributions.Normal((double)temp.R, classes[k].mu[0], classes[k].sigma[0]);
                        pxw[1, k] = Distributions.Normal((double)temp.G, classes[k].mu[1], classes[k].sigma[1]);
                        pxw[2, k] = Distributions.Normal((double)temp.B, classes[k].mu[2], classes[k].sigma[2]);
                    }
                    for (int k = 0; k < length; k++)
                    {
                        pxsw[k] =pxw[0,k]*pxw[1,k]*pxw[2,k] ;
                    }
                    for (int k = 0; k < length; k++)
                        Px += pxsw[k];
                    for (int k = 0; k < length; k++)
                        pwx[k] = pxsw[k] / Px;
                    for (int k = 0;k<actions;k++)
                    {
                        double sum = 0;
                        for (int l = 0;l<length;l++)
                            {
                                sum = sum + lamda[k,l] * pwx[l];
                            }
                        risk[k] = sum;
                }   
                    index = Array.IndexOf(risk,Min(risk));
                    if(index==4)
                        res.SetPixel(i, j, Color.Black);
                    else
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
        private double Min(double[] arr)
        {
            double min = 256;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < min)
                    min = arr[i];
            return min;
        }
        public Bitmap getResult()
        {
            return res;
        }
    }
}
