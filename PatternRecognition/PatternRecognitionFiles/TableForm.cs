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
        public TableForm(DataTable inputTable)
        {
            InitializeComponent();
            theTable.DataSource = inputTable;
        }
    }
}
