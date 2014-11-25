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
        private int [] K;
        private int n;
        public Pars(Class [] classes,Bitmap img,int win,bool gen)
        {
            this.classes = classes;
            this.img = img;
            this.win = win;
            this.gen = gen;
            table = new DataTable("Confusion Matrix");
            accuracy = new double[4];
            overallAcc = 0;
            n = 0;
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
        }

        private void Calc()
        {
            int index;
            res=new Bitmap(img);
            int length=classes.Length;
            K = new int[length];
            double[] re = new double[length];
            double len = img.Width / 4;
            double [,] mat = new double[length, length];
            DataRow dr;
            for(int i=0;i<img.Width;i++)
                for(int j=0;j<img.Height;j++)
                {
                    re = getPest(i, j);
                    index = Array.IndexOf(re,Max(re));
                    if (gen)
                    {
                        if (i < len)
                            mat[0, index]++;
                        else if (i < 2 * len)
                            mat[1, index]++;
                        else if (i < 3 * len)
                            mat[2, index]++;
                        else
                            mat[3, index]++;
                    }
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
                    accuracy[i] = mat[i, 0] + mat[i, 1] + mat[i, 2] + mat[i, 3];
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
            double[] re = new double[ClassLength];
            for (int i = 0; i < ClassLength; i++)
            {
                for (int j = 0; j < SampleLength; j++)
                {
                    classification[j]=Math.Sqrt((Math.Pow((classes[i].samples[j].X-l),2))+(Math.Pow((classes[i].samples[j].Y-k),2)))/win;
                    if (classification[j] < 0.5)
                    {
                        K[i]++;
                        n++;
                    }
                }
            }
            for (int i = 0; i < ClassLength; i++)
                P[i] = K[i] / Math.Sqrt(n);
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
