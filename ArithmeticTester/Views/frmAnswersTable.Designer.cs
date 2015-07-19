namespace ArithmeticTester.Views
{
    partial class frmAnswersTable
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
            this.grdAnswersTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdAnswersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAnswersTable
            // 
            this.grdAnswersTable.AllowUserToAddRows = false;
            this.grdAnswersTable.AllowUserToDeleteRows = false;
            this.grdAnswersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAnswersTable.Location = new System.Drawing.Point(0, 0);
            this.grdAnswersTable.Name = "grdAnswersTable";
            this.grdAnswersTable.ReadOnly = true;
            this.grdAnswersTable.Size = new System.Drawing.Size(240, 150);
            this.grdAnswersTable.TabIndex = 0;
            // 
            // frmAnswersTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.grdAnswersTable);
            this.Name = "frmAnswersTable";
            this.Text = "AnswersTable";
            this.Load += new System.EventHandler(this.frmAnswersTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnswersTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAnswersTable;
    }
}