using System;
using System.Windows.Forms;
using ArithmeticTester.Classes;
using ArithmeticTester.Views;

namespace ArithmeticTester
{
    /// <summary>
    /// Arithmetic test form.
    /// </summary>
    public partial class frmArithmeticTest : Form
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        Random rd;
        /// <summary>
        /// Count of correct answers.
        /// </summary>
        byte correct;
        /// <summary>
        /// Count of total guesses.
        /// </summary>
        byte totguess;
        /// <summary>
        /// Count of guesses for current question.
        /// </summary>
        byte guess;
        /// <summary>
        /// Count of number of questions asked so far.
        /// </summary>
        byte qcount;
        /// <summary>
        /// The arithmetic operator to use for questions.
        /// </summary>
        ArithmeticOperator arithmeticOperator = ArithmeticOperator.Multiply;
        /// <summary>
        /// The correct answer for current question.
        /// </summary>
        int answer;
        /// <summary>
        /// The minimum factor to use in arithmetic operations.
        /// </summary>
        const int minFactorValue = 1;
        /// <summary>
        /// The maximum factor to use in arithmetic operations.
        /// </summary>
        const int maxFactorValue = 12;

        /// <summary>
        /// Form Constructor.
        /// </summary>
        public frmArithmeticTest()
        {
            InitializeComponent();

            rd = new Random();
            Initialise();
        }

       /// <summary>
        /// Event Handler for the start button Click event. Start a new set of test questions.
        /// </summary>
        /// <param name="sender">The sender objects.</param>
        /// <param name="e">The Event Arguments.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Initialise();
            btnStart.Enabled = false;
            GenerateQuestion();
        }

        /// <summary>
        /// Event Handler for the answer textbox KeyDown event. Checks if the answer is correct.
        /// </summary>
        /// <param name="sender">The sender objects.</param>
        /// <param name="e">The Event Arguments.</param>
        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totguess++;
                lblGuesses.Text = "Guesses: " + totguess;
                if (FormatCheck(txtAnswer.Text))
                {
                    if (txtAnswer.Text == answer.ToString())
                    {
                        if (guess == 0)
                        {
                            correct++;
                            lblCorrect.Text = "Correct :" + correct;
                        }
                        MessageBox.Show("Correct!", "Arithmetic Tester", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GenerateQuestion();
                        guess = 0;
                        qcount++;
                    }
                    else
                    {
                        Wrong(true, Int32.Parse(txtAnswer.Text));
                    }
                }
                else
                {
                    MessageBox.Show("That is not a number!", "Arithmetic Tester", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Wrong(false);
                }

                if (qcount == 10)
                {
                     Finished();
                }

                txtAnswer.Text = "";
            }
        }

        /// <summary>
        /// Initialise the form.
        /// </summary>
        private void Initialise()
        {
            lblGuesses.Text = "Guesses: 0";
            lblCorrect.Text = "Correct: 0";
            lblGrade.Text = "";
            correct = 0;
            totguess = 0;
            guess = 0;
            qcount = 0;
            answer = 0;
        }

        /// <summary>
        /// Reset the form after test is completed.
        /// </summary>
        private void ResetForm()
        {
            lblFactor1.Text = "";
            lblFactor2.Text = "";
            txtAnswer.Text = "";
            btnStart.Enabled = true;
        }

        /// <summary>
        /// Generates the next question.
        /// </summary>
        private void GenerateQuestion()
        {
            byte x = (byte)rd.Next(minFactorValue, maxFactorValue);
            byte y = (byte)rd.Next(minFactorValue, maxFactorValue);
            lblFactor1.Text = x.ToString();
            lblFactor2.Text = y.ToString();
            answer = RealAnswer(x, y, arithmeticOperator);
        }

        /// <summary>
        /// Returns the results of the arithmetic operation defined by the given factors and operator.
        /// </summary>
        /// <param name="x">The first factor in the arithmetic operation.</param>
        /// <param name="y">The second factor in the arithmetic operation.</param>
        /// <param name="op">The operator for the arithmetic operation.</param>
        /// <returns>Integer - the result of the arithmetic operation.</returns>
        private int RealAnswer(byte x, byte y, ArithmeticOperator op)
        {
            int result = 0;
            switch (op)
            {
                case ArithmeticOperator.Add:
                    result = Arithmetic.Add(x, y);
                    break;
                case ArithmeticOperator.Divide:
                    result = Arithmetic.Divide(x, y);
                    break;
                case ArithmeticOperator.Multiply:
                    result = Arithmetic.Multiply(x, y);
                    break;
                case ArithmeticOperator.Subtract:
                    result = Arithmetic.Subtract(x, y);
                    break;
                default:
                    throw new ArithmeticException("Unknown Arithmetic Operator.");
            }

            return result;
        }

        /// <summary>
        /// Checks that the given string is a a valid (positive or negative) integer.
        /// </summary>
        /// <param name="answer">The string to check.</param>
        /// <returns>Boolean - true if the answer is valid.</returns>
        private bool FormatCheck(string answer)
        {
            int answerNum;
            bool validAnswer = false;

            if (answer.Length > 0 && Int32.TryParse(answer, out answerNum))
            {
                validAnswer = true;
            }

            return validAnswer;
        }

        /// <summary>
        /// Determines the actions to take if a user makes an incorrect guess.
        /// </summary>
        /// <param name="number">Boolean - true if the </param>
        /// <param name="givenAnswer">Integer - the answer given by user. Defaults to 0 if an integer was not provided.</param>
        private void Wrong(bool number, int givenAnswer = 0)
        {
            guess++;
            if (guess == 1 && number == true)
            {
                if (givenAnswer > answer)
                {
                    MessageBox.Show("Incorrect, you are " + (givenAnswer - answer).ToString() + " away!", "Arithmetic Tester", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Incorrect, you are " + (answer - givenAnswer).ToString() + " away!", "Arithmetic Tester", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (guess == 2)
            {
                frmAnswersTable AnswersTableForm = new frmAnswersTable();
                switch (arithmeticOperator)
                {
                    case ArithmeticOperator.Add:
                        AnswersTableForm.ShowDialog();
                        break;
                    case ArithmeticOperator.Divide:
                        AnswersTableForm.ShowDialog();
                        break;
                    case ArithmeticOperator.Multiply:
                        AnswersTableForm.ShowDialog();
                        break;
                    case ArithmeticOperator.Subtract:
                        AnswersTableForm.ShowDialog();
                        break;
                }
            }
            else if (guess == 3)
            {
                MessageBox.Show("Incorrect, it was " + answer, "Arithmetic Tester", MessageBoxButtons.OK, MessageBoxIcon.Information);
                guess = 0;
                qcount++;
                GenerateQuestion();
            }
        }

        /// <summary>
        /// Calculates the score and prints the grade based on the test results.
        /// </summary>
        private void Finished()
        {
            float score = (float)correct / (float)totguess;
            MessageBox.Show("You have completed the test", "Arithmetic Tester", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();

            if (score == 1)
            {
                lblGrade.Text = "Outstanding";
            }
            else if (0.55 < score && score < 1)
            {
                lblGrade.Text = "Excellent";
            }
            else if (0.3 < score && score <= 0.55)
            {
                lblGrade.Text = "Good";
            }
            else if (0.1 < score && score <= 0.3)
            {
                lblGrade.Text = "Satisfactory";
            }
            else
            {
                lblGrade.Text = "Please see your teacher";
            }
        }
    }
}
