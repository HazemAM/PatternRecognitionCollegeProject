using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;

namespace PatternRecognition
{
    class Pars
    {
        private Class[] classes;
        private Bitmap img;
        private Bitmap res;
        private DataTable table;
        private double[] accuracy;
        private double overallAcc;
        private int win;
        private bool gen;
        private double V;
        public Pars(Class [] classes,Bitmap img,int win,bool gen)
        {
            this.classes = classes;
            this.img = img;
            this.win = win;
            this.gen = gen;
            table = new DataTable("Confusion Matrix");
            accuracy = new double[4];
            overallAcc = 0;
            V = Math.Pow(win, 3);
            Setup();
            Calc();
        }

        private void Setup()
        {
            table.Columns.Add("Class vs. Action");
            table.Columns.Add("Class 1");
            table.Columns.Add("Class 2");
            table.Columns.Add("Class 3");
            table.Columns.Add("Class 4");
            table.Columns.Add("rejected");
        }

        private void Calc()
        {
            int index;
            res=new Bitmap(img);
            int length=classes.Length;
            double[] re = new double[length];
            double Px = 0;
            double[] pwx = new double[length];
            double len = img.Width / 4;
            double [,] mat = new double[length, length+1];
            DataRow dr;
            for(int i=0;i<img.Width;i++)
                for(int j=0;j<img.Height;j++)
                {
                    re = getPest(i, j);
                    if (gen)
                         for (int k = 0; k < length; k++)
                              re[k] *= 1 / 4;
                    for (int k = 0; k < length; k++)
                         Px += re[k];
                    for (int k = 0; k < length; k++)
                         pwx[k] = re[k] / Px;
                    index = Array.IndexOf(pwx,Max(pwx));
                    if (gen)
                    {
                         if (index == -1)
                              index = 4;
                        if (i < len)
                            mat[0, index]++;
                        else if (i < 2 * len)
                            mat[1, index]++;
                        else if (i < 3 * len)
                            mat[2, index]++;
                        else
                            mat[3, index]++;
                    }
                     if(index==-1)
                          res.SetPixel(i, j, Color.Black);
                     else
                         res.SetPixel(i, j, classes[index].color);
                }
            if (gen)
            {
                for (int i = 0; i < 4; i++)
                {
                    dr = table.NewRow();
                    dr[0] = "Class " + (i + 1).ToString();
                    dr[1] = mat[i, 0];
                    dr[2] = mat[i, 1];
                    dr[3] = mat[i, 2];
                    dr[4] = mat[i, 3];
                    dr[5] = mat[i, 4];
                    accuracy[i] = mat[i, 0] + mat[i, 1] + mat[i, 2] + mat[i, 3] + mat[i, 4];
                    accuracy[i] = mat[i, i] / accuracy[i];
                    overallAcc += accuracy[i];
                    table.Rows.Add(dr);
                }
            }
        }

        private double[] getPest(int l, int k)
        {
            int ClassLength = classes.Length;
            int SampleLength = classes[0].samples.Length;
            double [] P= new double[ClassLength];
            double[] classification = new double[SampleLength];
             int [] K=new int[ClassLength];
             int n=0;
             Color c=img.GetPixel(l,k);
             double temp=c.R+c.G+c.B;
             temp/=3.0;
            for (int i = 0; i < ClassLength; i++)
            {
                for (int j = 0; j < SampleLength; j++)
                {

                     
                    classification[j]=Math.Abs(temp-classes[i].samples[j])/win;
                    if (classification[j] < 1.0/2.0)
                    {
                        K[i]++;
                        n++;
                    }
                }
            }
            for (int i = 0; i < ClassLength; i++)
                 if( n!=0)
                P[i] = K[i]/n /V;
            return P;
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
        public DataTable getTable()
        {
            return table;
        }
        public double[] getAccuracy()
        {
            return accuracy;
        }
        public double getOverallAccuracy()
        {
            return overallAcc;
        }
    }
}
