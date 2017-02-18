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
            this.grdAnswersTable.AllowUserToResizeColumns = false;
            this.grdAnswersTable.AllowUserToResizeRows = false;
            this.grdAnswersTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdAnswersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAnswersTable.Enabled = false;
            this.grdAnswersTable.GridColor = System.Drawing.SystemColors.Control;
            this.grdAnswersTable.Location = new System.Drawing.Point(0, 0);
            this.grdAnswersTable.MultiSelect = false;
            this.grdAnswersTable.Name = "grdAnswersTable";
            this.grdAnswersTable.ReadOnly = true;
            this.grdAnswersTable.RowHeadersWidth = 50;
            this.grdAnswersTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAnswersTable.Size = new System.Drawing.Size(412, 287);
            this.grdAnswersTable.TabIndex = 0;
            // 
            // frmAnswersTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 287);
            this.Controls.Add(this.grdAnswersTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnswersTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Answers Table";
            this.Load += new System.EventHandler(this.frmAnswersTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAnswersTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAnswersTable;
    }
}