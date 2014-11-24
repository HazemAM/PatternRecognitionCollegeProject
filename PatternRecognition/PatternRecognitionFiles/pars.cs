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
        public Pars(Class [] classes,Bitmap img,int win,bool gen)
        {
            this.classes = classes;
            this.img = img;
            this.win = win;
            this.gen = gen;
            table = new DataTable("Confusion Matrix");
            accuracy = new double[4];
            overallAcc = 0;
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
            Color temp;
            res=new Bitmap(img);
            int length=classes.Length;
            double[,] pxw = new double[3,length];
            double[] pxsw = new double[length];
            double[] pwx = new double[length];
            double len = img.Width / 4;
            double [,] mat = new double[length, length];
            DataRow dr;
            double Px = 0;
            for(int i=0;i<img.Width;i++)
                for(int j=0;j<img.Height;j++)
                {
                    temp=img.GetPixel(i,j);
                    for (int k = 0; k < length; k++)
                    {
                        pxw[0,k] = getPest(0,k);
                        pxw[1, k] = getPest(1, k);
                        pxw[2, k] = getPest(2, k);
                    }
                    for (int k = 0; k < length; k++)
                        pxsw[k] =pxw[0,k]*pxw[1,k]*pxw[2,k] ;
                    for (int k = 0; k < length; k++)
                    {
                        if (gen)
                            pwx[k] = pxsw[k] * (1.0 / length);
                        else
                            pwx[k] = pxsw[k];
                        Px += pxsw[k];
                    }
                    for (int k = 0; k < length; k++)
                        pwx[k] = pwx[k] / Px;
                    index = Array.IndexOf(pwx,Min(pwx));
                    if (i < len)
                        mat[0, index]++;
                    else if (i < 2 * len)
                        mat[1, index]++;
                    else if (i < 3 * len)
                        mat[2, index]++;
                    else
                        mat[3, index]++;
                    res.SetPixel(i, j, classes[index].color);
                }
            for (int i = 0; i < 4; i++)
            {
                dr = table.NewRow();
                dr[0] = "Class "+(i+1).ToString();
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

        private double getPest(int p, int k)
        {
            throw new NotImplementedException();
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
