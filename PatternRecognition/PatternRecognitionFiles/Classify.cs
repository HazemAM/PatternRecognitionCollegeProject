using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PatternRecognition
{
    class Classify
    {
        private Irises[] inp;
        private double[,] mu = new double[3,4];
        private double[,] sigma = new double[3,4];
        private DataTable table;
        private double[] accuracy;
        private double overallAcc;
        public void ClassifyIris()
        {
            inp = readInput();
            accuracy = new double[3];
            overallAcc = 0;
            estimateMuSigma();
            Setup();
            classify();
        }

        private void Setup()
        {
            table=new DataTable("Ireses Classification");
            table.Columns.Add("Type/Classfied AS");
            table.Columns.Add("Setosa");
            table.Columns.Add("Versicolor 2");
            table.Columns.Add("Virginica 3");
        }
        private double Min(double[] arr)
        {
            double min = 256;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < min)
                    min = arr[i];
            return min;
        }
        private void classify()
        {
            double[] Gx = new double[3];
            double[,] mat = new double[3, 3];
            int index;
            int start = 20;
            for (int l = 0; l < 3; l++)
            {
                
                for (int i = start; i < start + 30; i++)
                {
                    Gx[0] = Calc(0,i);
                    Gx[1] = Calc(1,i);
                    Gx[2] = Calc(1,i);
                    index=Array.IndexOf(Gx,Min(Gx));
                    if (start < 50)
                        mat[0, index]++;
                    else if (start < 100)
                        mat[1, index]++;
                    else
                        mat[2, index]++;
                }
                
                start += 50;
            }
            DataRow dr;
            
            for (int i = 0; i < 3; i++)
            {
                dr = table.NewRow();
                dr[0] = "Class " + (i + 1).ToString();
                dr[1] = mat[i, 0];
                dr[2] = mat[i, 1];
                accuracy[i] = mat[i, 0] + mat[i, 1] + mat[i, 2];
                accuracy[i] /= mat[i, i];
                overallAcc += accuracy[i];
                table.Rows.Add(dr);
            }
        }

        private double Calc(int type,int index)
        {
            double sum=0;
            double [] x=inp[index].x;
            for(int i=0;i<3;++i)
                sum += Math.Pow(x[i]-mu[type,i],2);
            sum=Math.Sqrt(sum);
                sum/=(2*Math.Pow(sigma[type,0],2));
                sum+=Math.Log(1/3);
                return sum;
        }

        private void estimateMuSigma()
        {
            int start = 0;
            for(int l=0;l<3;l++)
            {
                double[] sum=new double [4];
                for(int i=start;i<start+20;i++)
                {
                    sum[0] += inp[i].x[0];
                    sum[1] += inp[i].x[1];
                    sum[2] += inp[i].x[2];
                    sum[3] += inp[i].x[3];
                }
                mu[l, 0] = sum[0] / 20.0;
                mu[l, 1] = sum[1] / 20.0;
                mu[l, 2] = sum[2] / 20.0;
                mu[l, 3] = sum[3] / 20.0;
                start += 50;
            }
            start = 0;
            for (int l = 0; l < 3; l++)
            {
                double[] sum = new double[4];
                for (int i = start; i < start + 20; i++)
                {
                    sum[0] += Math.Pow((inp[i].x[0] - mu[l, 0]), 2);
                    sum[1] += Math.Pow((inp[i].x[1] - mu[l, 1]), 2);
                    sum[2] += Math.Pow((inp[i].x[2] - mu[l, 2]), 2);
                    sum[3] += Math.Pow((inp[i].x[3] - mu[l, 3]), 2);
                }
                sigma[l, 0] = sum[0] / 20.0;
                sigma[l, 1] = sum[1] / 20.0;
                sigma[l, 2] = sum[2] / 20.0;
                sigma[l, 3] = sum[3] / 20.0;
                start += 50;
            }
        }

        private Irises[] readInput()
        {
            Irises[] res = new Irises[150];
            int count = 0;
            String line;
            System.IO.StreamReader file = new System.IO.StreamReader("Iris Data.txt");
            while ((line = file.ReadLine()) != null)
            {
                if(line.StartsWith("x"))
                    continue;
                String[] values = line.Split(',');
                double[] x = { Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2]), Double.Parse(values[3]) };
                String [] value=values[4].Split('-');
                String name = value[1];
                res[count] = new Irises(x, name);
                count++;
            }
            return res;
        }
    }
}
