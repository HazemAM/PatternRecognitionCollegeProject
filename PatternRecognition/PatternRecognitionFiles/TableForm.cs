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

            if(accuracyArray.Length>0) lblAccClass1.Text = Math.Round(accuracyArray[0],3).ToString();
            if(accuracyArray.Length>1) lblAccClass2.Text = Math.Round(accuracyArray[1],3).ToString();
            if(accuracyArray.Length>2) lblAccClass3.Text = Math.Round(accuracyArray[2],3).ToString();
            if(accuracyArray.Length>3) lblAccClass4.Text = Math.Round(accuracyArray[3],3).ToString();
            else{ lblAccClass4Title.Visible=false; lblAccClass4.Visible=false; }

            lblAccOverall.Text = Math.Round(accuracyOverall,3).ToString();
        }
    }
}
