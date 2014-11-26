using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatternRecognition
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new mainForm());

            /*TASK 3*/
            //Classify iris = new Classify();
            //iris.ClassifyIris();
            //TableForm irisForm = new TableForm(iris.getTable(), iris.getAccuracyArray(), iris.getOverallAccuracy());
            //Application.Run(irisForm);
        }
    }
}