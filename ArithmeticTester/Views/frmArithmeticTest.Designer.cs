namespace ArithmeticTester
{
    partial class frmArithmeticTest
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblGuesses = new System.Windows.Forms.Label();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblFactor1 = new System.Windows.Forms.Label();
            this.lblEquals = new System.Windows.Forms.Label();
            this.lblFactor2 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(86, 66);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblGuesses
            // 
            this.lblGuesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuesses.Location = new System.Drawing.Point(32, 9);
            this.lblGuesses.Name = "lblGuesses";
            this.lblGuesses.Size = new System.Drawing.Size(78, 17);
            this.lblGuesses.TabIndex = 1;
            // 
            // lblCorrect
            // 
            this.lblCorrect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCorrect.Location = new System.Drawing.Point(139, 9);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(78, 17);
            this.lblCorrect.TabIndex = 2;
            // 
            // lblGrade
            // 
            this.lblGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGrade.Location = new System.Drawing.Point(32, 36);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(185, 17);
            this.lblGrade.TabIndex = 3;
            this.lblGrade.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(178, 103);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(64, 23);
            this.txtAnswer.TabIndex = 4;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAnswer_KeyDown);
            // 
            // lblFactor1
            // 
            this.lblFactor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFactor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactor1.Location = new System.Drawing.Point(12, 102);
            this.lblFactor1.Name = "lblFactor1";
            this.lblFactor1.Size = new System.Drawing.Size(37, 21);
            this.lblFactor1.TabIndex = 7;
            this.lblFactor1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEquals
            // 
            this.lblEquals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquals.Location = new System.Drawing.Point(139, 102);
            this.lblEquals.Name = "lblEquals";
            this.lblEquals.Size = new System.Drawing.Size(37, 21);
            this.lblEquals.TabIndex = 8;
            this.lblEquals.Text = "=";
            this.lblEquals.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFactor2
            // 
            this.lblFactor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFactor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactor2.Location = new System.Drawing.Point(98, 102);
            this.lblFactor2.Name = "lblFactor2";
            this.lblFactor2.Size = new System.Drawing.Size(37, 21);
            this.lblFactor2.TabIndex = 9;
            this.lblFactor2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOperator
            // 
            this.lblOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(55, 102);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(37, 21);
            this.lblOperator.TabIndex = 10;
            this.lblOperator.Text = "x";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmArithmeticTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 262);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.lblFactor2);
            this.Controls.Add(this.lblEquals);
            this.Controls.Add(this.lblFactor1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblCorrect);
            this.Controls.Add(this.lblGuesses);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArithmeticTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arithmetic Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblGuesses;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lblFactor1;
        private System.Windows.Forms.Label lblEquals;
        private System.Windows.Forms.Label lblFactor2;
        private System.Windows.Forms.Label lblOperator;
    }
}

