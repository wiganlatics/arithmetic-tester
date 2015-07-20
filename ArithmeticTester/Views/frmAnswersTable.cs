
namespace ArithmeticTester.Views
{
    using System.Windows.Forms;
    using ArithmeticTester.Classes;

    /// <summary>
    /// Form to display a table of answers 
    /// </summary>
    public partial class frmAnswersTable : Form
    {
        /// <summary>
        /// Form Constructor.
        /// </summary>
        public frmAnswersTable()
        {
            InitializeComponent();

            Initialise();
        }

        /// <summary>
        /// Initialise the form.
        /// </summary>
        private void Initialise()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = 30;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Multiply(c, b);
                    grdAnswersTable[b - 1, c - 1].Value = grdAnswersTable[c - 1, b - 1].Value;
                }
                grdAnswersTable[b - 1, b - 1].Value = Arithmetic.Multiply(b, b);
            }

            // Don't want any cells highlighted
            grdAnswersTable.ClearSelection();
        }
    }
}
