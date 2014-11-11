using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PatternRecognition
{
    public partial class TableForm : Form
    {
        public TableForm(DataTable inputTable, double[] accuracyArray, double accuracyOverall)
        {
            InitializeComponent();
            confusionTable.DataSource = inputTable;

            lblAccClass1.Text = Math.Round(accuracyArray[0],3).ToString();
            lblAccClass2.Text = Math.Round(accuracyArray[1],3).ToString();
            lblAccClass3.Text = Math.Round(accuracyArray[2],3).ToString();
            lblAccClass4.Text = Math.Round(accuracyArray[3],3).ToString();

            lblAccOverall.Text = Math.Round(accuracyOverall,3).ToString();
        }
    }
}
