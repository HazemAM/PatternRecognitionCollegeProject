namespace PatternRecognition
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.theTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.theTable)).BeginInit();
            this.SuspendLayout();
            // 
            // theTable
            // 
            this.theTable.AllowUserToAddRows = false;
            this.theTable.AllowUserToDeleteRows = false;
            this.theTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.theTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theTable.Location = new System.Drawing.Point(0, 0);
            this.theTable.Name = "theTable";
            this.theTable.ReadOnly = true;
            this.theTable.Size = new System.Drawing.Size(693, 145);
            this.theTable.TabIndex = 0;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 145);
            this.Controls.Add(this.theTable);
            this.Name = "TableForm";
            this.Text = "Confusion Matrix";
            ((System.ComponentModel.ISupportInitialize)(this.theTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView theTable;
    }
}