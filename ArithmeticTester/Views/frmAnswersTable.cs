using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArithmeticTester.Views
{
    /// <summary>
    /// Form to display a table of answers 
    /// </summary>
    public partial class frmAnswersTable : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private const byte minFactorValue = 1;
        /// <summary>
        /// 
        /// </summary>
        private const byte maxFactorValue = 12;

        /// <summary>
        /// 
        /// </summary>
        public frmAnswersTable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAnswersTable_Load(object sender, EventArgs e)
        {
            for (byte b = 1; b <= 12; b++)
            {
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Columns.Add(b.ToString(),b.ToString());
                grdAnswersTable[b, 0].Value = b;
            }
        }
    }
}
