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
            this.confusionTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAccOverall = new System.Windows.Forms.Label();
            this.lblAccClass4 = new System.Windows.Forms.Label();
            this.lblAccClass4Title = new System.Windows.Forms.Label();
            this.lblAccClass3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAccClass2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAccClass1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.confusionTable)).BeginInit();
            this.SuspendLayout();
            // 
            // confusionTable
            // 
            this.confusionTable.AllowUserToAddRows = false;
            this.confusionTable.AllowUserToDeleteRows = false;
            this.confusionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.confusionTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.confusionTable.Location = new System.Drawing.Point(0, 0);
            this.confusionTable.Name = "confusionTable";
            this.confusionTable.ReadOnly = true;
            this.confusionTable.Size = new System.Drawing.Size(647, 126);
            this.confusionTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(446, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Overall Accuracy:";
            // 
            // lblAccOverall
            // 
            this.lblAccOverall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAccOverall.AutoSize = true;
            this.lblAccOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccOverall.Location = new System.Drawing.Point(556, 184);
            this.lblAccOverall.Name = "lblAccOverall";
            this.lblAccOverall.Size = new System.Drawing.Size(57, 13);
            this.lblAccOverall.TabIndex = 3;
            this.lblAccOverall.Text = "(accuracy)";
            // 
            // lblAccClass4
            // 
            this.lblAccClass4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccClass4.AutoSize = true;
            this.lblAccClass4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccClass4.Location = new System.Drawing.Point(181, 182);
            this.lblAccClass4.Name = "lblAccClass4";
            this.lblAccClass4.Size = new System.Drawing.Size(57, 13);
            this.lblAccClass4.TabIndex = 5;
            this.lblAccClass4.Text = "(accuracy)";
            // 
            // lblAccClass4Title
            // 
            this.lblAccClass4Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccClass4Title.AutoSize = true;
            this.lblAccClass4Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccClass4Title.Location = new System.Drawing.Point(12, 182);
            this.lblAccClass4Title.Name = "lblAccClass4Title";
            this.lblAccClass4Title.Size = new System.Drawing.Size(161, 13);
            this.lblAccClass4Title.TabIndex = 4;
            this.lblAccClass4Title.Text = "Class Four/Cyan Accuracy:";
            // 
            // lblAccClass3
            // 
            this.lblAccClass3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccClass3.AutoSize = true;
            this.lblAccClass3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccClass3.Location = new System.Drawing.Point(181, 166);
            this.lblAccClass3.Name = "lblAccClass3";
            this.lblAccClass3.Size = new System.Drawing.Size(57, 13);
            this.lblAccClass3.TabIndex = 7;
            this.lblAccClass3.Text = "(accuracy)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Class Three/Blue Accuracy:";
            // 
            // lblAccClass2
            // 
            this.lblAccClass2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccClass2.AutoSize = true;
            this.lblAccClass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccClass2.Location = new System.Drawing.Point(181, 150);
            this.lblAccClass2.Name = "lblAccClass2";
            this.lblAccClass2.Size = new System.Drawing.Size(57, 13);
            this.lblAccClass2.TabIndex = 9;
            this.lblAccClass2.Text = "(accuracy)";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Class Two/Green Accuracy:";
            // 
            // lblAccClass1
            // 
            this.lblAccClass1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccClass1.AutoSize = true;
            this.lblAccClass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccClass1.Location = new System.Drawing.Point(181, 134);
            this.lblAccClass1.Name = "lblAccClass1";
            this.lblAccClass1.Size = new System.Drawing.Size(57, 13);
            this.lblAccClass1.TabIndex = 11;
            this.lblAccClass1.Text = "(accuracy)";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Class One/Red Accuracy:";
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 206);
            this.Controls.Add(this.lblAccClass1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAccClass2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblAccClass3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAccClass4);
            this.Controls.Add(this.lblAccClass4Title);
            this.Controls.Add(this.lblAccOverall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confusionTable);
            this.Name = "TableForm";
            this.Text = "Output Form";
            ((System.ComponentModel.ISupportInitialize)(this.confusionTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView confusionTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAccOverall;
        private System.Windows.Forms.Label lblAccClass4;
        private System.Windows.Forms.Label lblAccClass4Title;
        private System.Windows.Forms.Label lblAccClass3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAccClass2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAccClass1;
        private System.Windows.Forms.Label label9;
    }
}