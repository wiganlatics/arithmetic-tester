using System;
using System.Windows.Forms;
using ArithmeticTester.Controllers;
using ArithmeticTester.Models;

namespace ArithmeticTester.Views
{
    /// <summary>
    /// Arithmetic test form.
    /// </summary>
    public partial class frmArithmeticTest : Form
    {
        /// <summary>
        /// The Arithmetic Test object controls state of current test.
        /// </summary>
        private ArithmeticTest test;
        /// <summary>
        /// The number of questions per test.
        /// </summary>
        private const byte totalQuestions = 10;

        /// <summary>
        /// Form Constructor.
        /// </summary>
        public frmArithmeticTest()
        {
            try
            {
                InitializeComponent();

                this.test = new ArithmeticTest(new Random(), totalQuestions);

                Initialise();

                cmbOperation.Items.Add("Add");
                cmbOperation.Items.Add("Divide");
                cmbOperation.Items.Add("Multiply");
                cmbOperation.Items.Add("Subtract");
                cmbOperation.SelectedItem = "Multiply";
            }
            catch (Exception ex)
            {
                ErrorHandler(ex);
            }
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
                if (test.SubmitAnswer(txtAnswer.Text))
                {
                    SetCorrectAnswersLabel(test.GetCorrectCount());
                    MessageBox.Show(Properties.Resources.CorrectAnswerMessage, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GenerateQuestion();
                }
                else
                {
                    Wrong();
                }

                SetTotalGuessesLabel(test.GetTotalGuessCount());
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
                    test.arithmeticOperator = ArithmeticOperator.Add;
                    break;
                case "Divide":
                    lblOperator.Text = "/";
                    test.arithmeticOperator = ArithmeticOperator.Divide;
                    break;
                case "Multiply":
                    lblOperator.Text = "x";
                    test.arithmeticOperator = ArithmeticOperator.Multiply;
                    break;
                case "Subtract":
                    lblOperator.Text = "-";
                    test.arithmeticOperator = ArithmeticOperator.Subtract;
                    break;
            }
        }

        /// <summary>
        /// Initialise the form.
        /// </summary>
        private void Initialise()
        {
            test.InitialiseCounts();
            SetQuestionNumberLabel(1);
            SetTotalGuessesLabel(test.GetTotalGuessCount());
            SetCorrectAnswersLabel(test.GetCorrectCount());
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
        /// Updates the grade label.
        /// </summary>
        /// <param name="grade">The string value that the label should show.</param>
        private void SetGradeLabel(string grade)
        {
            lblGrade.Text = grade;
        }

        /// <summary>
        /// Updates the first factor label.
        /// </summary>
        /// <param name="factor">The string value that the label should show.</param>
        private void SetFactor1Label(string factor)
        {
            lblFactor1.Text = factor;
        }

        /// <summary>
        /// Updates the second factor label.
        /// </summary>
        /// <param name="factor">The string value that the label should show.</param>
        private void SetFactor2Label(string factor)
        {
            lblFactor2.Text = factor;
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
            SetFactor1Label("");
            SetFactor2Label("");
            ResetAnswerTextBox();
            btnStart.Enabled = true;
            cmbOperation.Enabled = true;
        }

        /// <summary>
        /// Generates the next question. Unless the last question is reached, in which case the results are displayed.
        /// </summary>
        private void GenerateQuestion()
        {
            if (test.GetQuestionCount() == test.GetTotalQuestionsCount())
            {
                Finished();
            }
            else
            {
                try
                {
                    test.SetNextQuestion();
                    SetQuestionNumberLabel(test.GetQuestionCount());
                    SetFactor1Label(test.GetFactor1().ToString());
                    SetFactor2Label(test.GetFactor2().ToString());
                }
                catch (Exception ex)
                {
                    ErrorHandler(ex);
                }
            }
        }

        /// <summary>
        /// Determines the actions to take if a user makes an incorrect guess.
        /// </summary>
        private void Wrong()
        {
            int givenAnswer;
            bool isNum = Int32.TryParse(txtAnswer.Text, out givenAnswer);
            if (!isNum) MessageBox.Show(Properties.Resources.AnswerNotANumberMessage, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            switch (test.GetGuessCount())
            {
                case 1:
                    if (isNum)
                    {
                        if (givenAnswer > test.GetRealAnswer())
                        {
                            MessageBox.Show(string.Format(Properties.Resources.IncorrectGuessMessage, (givenAnswer - test.GetRealAnswer())), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(string.Format(Properties.Resources.IncorrectGuessMessage, (test.GetRealAnswer() - givenAnswer)), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    break;
                case 2:
                    try
                    {
                        frmAnswersTable AnswersTableForm;
                        if (test.arithmeticOperator == ArithmeticOperator.Divide)
                        {
                            AnswersTableForm = new frmAnswersTable(test.arithmeticOperator, test.GetFactor2());
                        }
                        else
                        {
                            AnswersTableForm = new frmAnswersTable(test.arithmeticOperator);
                        }

                        AnswersTableForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format(Properties.Resources.ErrorLoadingAnswersTable, ex.Message), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 3:
                    MessageBox.Show(string.Format(Properties.Resources.IncorrectThirdGuessMessage, test.GetRealAnswer()), Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GenerateQuestion();
                    break;
                default:
                    throw new Exception(string.Format(Properties.Resources.InvalidNumberOfGuesses, test.GetGuessCount()));
            }
        }

        /// <summary>
        /// Calculates the score and prints the grade based on the test results.
        /// </summary>
        private void Finished()
        {
            MessageBox.Show(Properties.Resources.TestCompleteMessage, Properties.Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();

            float score = (float)test.GetCorrectCount() / (float)test.GetTotalGuessCount();
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

        private void ErrorHandler(Exception ex)
        {
            MessageBox.Show(string.Format(Properties.Resources.ErrorLoadingForm, ex.Message));
            btnStart.Enabled = false;
            cmbOperation.Enabled = false;
            txtAnswer.Enabled = false;
        }
    }
}
