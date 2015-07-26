
namespace ArithmeticTester
{
    using System;
    using System.Windows.Forms;
    using ArithmeticTester.Controllers;
    using ArithmeticTester.Models;
    using ArithmeticTester.Views;

    /// <summary>
    /// Arithmetic test form.
    /// </summary>
    public partial class frmArithmeticTest : Form
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        private Random rd;
        /// <summary>
        /// Count of correct answers.
        /// </summary>
        private byte correct;
        /// <summary>
        /// Count of total guesses.
        /// </summary>
        private byte totguess;
        /// <summary>
        /// Count of guesses for current question.
        /// </summary>
        private byte guess;
        /// <summary>
        /// Count of number of questions asked so far.
        /// </summary>
        private byte qcount;
        /// <summary>
        /// The correct answer for current question.
        /// </summary>
        private int answer;
        /// <summary>
        /// The number of questions to ask.
        /// </summary>
        private const byte totalQuestions = 10;

        /// <summary>
        /// Form Constructor.
        /// </summary>
        public frmArithmeticTest()
        {
            InitializeComponent();

            rd = new Random();
            Initialise();

            cmbOperation.Items.Add("Add");
            cmbOperation.Items.Add("Divide");
            cmbOperation.Items.Add("Multiply");
            cmbOperation.Items.Add("Subtract");
            cmbOperation.SelectedItem = "Multiply";
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
            cmbOperation.Enabled = false;
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
                SetTotalGuessesLabel(totguess);
                if (FormatCheck(txtAnswer.Text))
                {
                    if (txtAnswer.Text == answer.ToString())
                    {
                        if (guess == 0)
                        {
                            correct++;
                            SetCorrectAnswersLabel(correct);
                        }
                        MessageBox.Show(Properties.Resources.CorrectAnswerMessage, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GenerateQuestion();
                    }
                    else
                    {
                        Wrong(true, Int32.Parse(txtAnswer.Text));
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.AnswerNotANumberMessage, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Wrong(false);
                }

                ResetAnswerTextBox();
            }
        }

        /// <summary>
        /// Event Handler for the operation combo box SelectedIndexChanged event. Switches the arithmetic operator to the new selection.
        /// </summary>
        /// <param name="sender">The sender objects.</param>
        /// <param name="e">The Event Arguments.</param>
        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOperation.SelectedItem.ToString())
            {
                case "Add":
                    lblOperator.Text = "+";
                    ArithmeticTest.arithmeticOperator = ArithmeticOperator.Add;
                    break;
                case "Divide":
                    lblOperator.Text = "/";
                    ArithmeticTest.arithmeticOperator = ArithmeticOperator.Divide;
                    break;
                case "Multiply":
                    lblOperator.Text = "x";
                    ArithmeticTest.arithmeticOperator = ArithmeticOperator.Multiply;
                    break;
                case "Subtract":
                    lblOperator.Text = "-";
                    ArithmeticTest.arithmeticOperator = ArithmeticOperator.Subtract;
                    break;
            }
        }

        /// <summary>
        /// Initialise the form.
        /// </summary>
        private void Initialise()
        {
            correct = 0;
            totguess = 0;
            guess = 0;
            qcount = 0;
            answer = 0;
            SetQuestionNumberLabel(1);
            SetTotalGuessesLabel(totguess);
            SetCorrectAnswersLabel(correct);
            SetGradeLabel("");
        }

        /// <summary>
        /// Updates the question number label.
        /// </summary>
        /// <param name="questionNumber">The number of questions completed.</param>
        private void SetQuestionNumberLabel(byte questionNumber)
        {
            lblQuestion.Text = string.Format("{0}: {1}", Properties.Resources.QuestionLabel, questionNumber);
        }

        /// <summary>
        /// Updates the correct answers label.
        /// </summary>
        /// <param name="correctAnswers">The number of correct answers.</param>
        private void SetCorrectAnswersLabel(byte correctAnswers)
        {
            lblCorrect.Text = string.Format("{0}: {1}", Properties.Resources.CorrectLabel, correctAnswers);
        }

        /// <summary>
        /// Updates the total guesses label.
        /// </summary>
        /// <param name="totalGuesses">The number of total guesses.</param>
        private void SetTotalGuessesLabel(byte totalGuesses)
        {
            lblGuesses.Text = string.Format("{0}: {1}", Properties.Resources.GuessesLabel, totalGuesses);
        }

        /// <summary>
        /// Updates that grade label.
        /// </summary>
        /// <param name="grade">The string value that the label should show.</param>
        private void SetGradeLabel(string grade)
        {
            lblGrade.Text = grade;
        }

        /// <summary>
        /// Reset the answer textbox to be blank.
        /// </summary>
        private void ResetAnswerTextBox()
        {
            txtAnswer.Text = "";
        }

        /// <summary>
        /// Reset the form after test is completed.
        /// </summary>
        private void ResetForm()
        {
            lblFactor1.Text = "";
            lblFactor2.Text = "";
            ResetAnswerTextBox();
            btnStart.Enabled = true;
            cmbOperation.Enabled = true;
        }

        /// <summary>
        /// Generates the next question. Unless the last question is reached, in which case the results are displayed.
        /// </summary>
        private void GenerateQuestion()
        {
            qcount++;
            SetQuestionNumberLabel(qcount);

            if (qcount == totalQuestions)
            {
                Finished();
            }
            else
            {
                ArithmeticTest.Factor2 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);
                byte x = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);
                if (ArithmeticTest.arithmeticOperator == ArithmeticOperator.Divide) x = (byte)Arithmetic.Multiply(ArithmeticTest.Factor2, x);
                lblFactor1.Text = x.ToString();
                lblFactor2.Text = ArithmeticTest.Factor2.ToString();
                answer = ArithmeticTest.RealAnswer(x, ArithmeticTest.Factor2, ArithmeticTest.arithmeticOperator);
                guess = 0;
            }
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
                    MessageBox.Show(string.Format(Properties.Resources.IncorrectGuessMessage, (givenAnswer - answer)), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format(Properties.Resources.IncorrectGuessMessage, (answer - givenAnswer)), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (guess == 2)
            {
                try
                {
                    frmAnswersTable AnswersTableForm = new frmAnswersTable();
                    switch (ArithmeticTest.arithmeticOperator)
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
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.Resources.ErrorLoadingAnswersTable, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (guess == 3)
            {
                MessageBox.Show(string.Format(Properties.Resources.IncorrectThirdGuessMessage, answer), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                GenerateQuestion();
            }
        }

        /// <summary>
        /// Calculates the score and prints the grade based on the test results.
        /// </summary>
        private void Finished()
        {
            MessageBox.Show(Properties.Resources.TestCompleteMessage, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();

            float score = (float)correct / (float)totguess;
            if (score == 1)
            {
                SetGradeLabel(Properties.Resources.OutstandingGrade);
            }
            else if (0.55 < score && score < 1)
            {
                SetGradeLabel(Properties.Resources.ExcellentGrade);
            }
            else if (0.3 < score && score <= 0.55)
            {
                SetGradeLabel(Properties.Resources.GoodGrade);
            }
            else if (0.1 < score && score <= 0.3)
            {
                SetGradeLabel(Properties.Resources.SatisfactoryGrade);
            }
            else
            {
                SetGradeLabel(Properties.Resources.UnsatisfactoryGrade);
            }
        }
    }
}
