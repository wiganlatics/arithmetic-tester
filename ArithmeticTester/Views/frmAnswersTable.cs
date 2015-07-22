
namespace ArithmeticTester.Views
{
    using System.Windows.Forms;
    using ArithmeticTester.Controllers;
    using ArithmeticTester.Models;

    /// <summary>
    /// Form to display a table of answers 
    /// </summary>
    public partial class frmAnswersTable : Form
    {
        /// <summary>
        /// The width of columns in the data grid.
        /// </summary>
        private const int colWidth = 30;

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
            switch (ArithmeticTest.arithmeticOperator)
            {
                case ArithmeticOperator.Add:
                    AdditionTable();
                    break;
                case ArithmeticOperator.Divide:
                    DivisionTable();
                    break;
                case ArithmeticOperator.Multiply:
                    MultiplicationTable();
                    break;
                case ArithmeticOperator.Subtract:
                    SubtractionTable();
                    break;
            }

            // Don't want any cells highlighted
            grdAnswersTable.ClearSelection();
        }

        /// <summary>
        /// Populates the table with the answers for addition questions.
        /// </summary>
        private void AdditionTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Add(c, b);
                    grdAnswersTable[b - 1, c - 1].Value = grdAnswersTable[c - 1, b - 1].Value;
                }
                grdAnswersTable[b - 1, b - 1].Value = Arithmetic.Add(b, b);
            }
        }

        /// <summary>
        /// Populates the table with the answers for division questions.
        /// </summary>
        private void DivisionTable()
        {

        }

        /// <summary>
        /// Populates the table with the answers for multiplication questions.
        /// </summary>
        private void MultiplicationTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
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
        }

        /// <summary>
        /// Populates the table with the answers for subtraction questions.
        /// </summary>
        private void SubtractionTable()
        {
            for (byte b = Arithmetic.minFactorValue; b <= Arithmetic.maxFactorValue; b++)
            {
                // Create columns and rows
                grdAnswersTable.Columns.Add(b.ToString(), b.ToString());
                grdAnswersTable.Columns[b - 1].Width = colWidth;
                grdAnswersTable.Rows.Add();
                grdAnswersTable.Rows[b - 1].HeaderCell.Value = b.ToString();

                // Populate cells
                for (byte c = Arithmetic.minFactorValue; c < b; c++)
                {
                    grdAnswersTable[c - 1, b - 1].Value = Arithmetic.Subtract(c, b);
                    grdAnswersTable[b - 1, c - 1].Value = Arithmetic.Subtract(b, c);
                }
                grdAnswersTable[b - 1, b - 1].Value = 0;
            }
        }
    }
}
