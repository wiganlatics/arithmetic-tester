using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArithmeticTester
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmArithmeticTest : Form
    {
        /// <summary>
        /// 
        /// </summary>
        Random rd;
        /// <summary>
        /// 
        /// </summary>
        byte correct;
        /// <summary>
        /// 
        /// </summary>
        byte totguess;
        /// <summary>
        /// 
        /// </summary>
        byte guess;
        /// <summary>
        /// 
        /// </summary>
        byte qcount;
        /// <summary>
        /// 
        /// </summary>
        const char arithmeticOperator = 'x';
        /// <summary>
        /// 
        /// </summary>
        int answer;

        /// <summary>
        /// 
        /// </summary>
        public frmArithmeticTest()
        {
            InitializeComponent();

            rd = new Random();
            Initialise();
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Initialise();
            btnStart.Enabled = false;
            GenerateQuestion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void GenerateQuestion()
        {
            lblFactor1.Text = rd.Next(1, 12).ToString();
            lblFactor2.Text = rd.Next(1, 12).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            bool correctformat;
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
                        MessageBox.Show("Correct!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        guess = 0;
                        qcount++;
                    }
                    else
                    {
                        correctformat = true;
                        Wrong(correctformat);
                    }
                }
                else
                {
                    MessageBox.Show("That is not a number!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    correctformat = false;
                    Wrong(correctformat);
                }
                if (qcount == 10)
                {
                     Finished();
                }
                else
                {
                    answer = RealAnswer();
                }
                txtAnswer.Text = "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int RealAnswer()
        {
            return Int32.Parse(lblFactor1.Text) * Int32.Parse(lblFactor2.Text);
        }

        /// <summary>
        /// Checks that the given string is a a valid (positive or negative) integer
        /// </summary>
        /// <param name="answer">The string to check</param>
        /// <returns>Boolean - true if the answer is valid</returns>
        public bool FormatCheck(string answer)
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
        /// 
        /// </summary>
        /// <param name="number"></param>
        private void Wrong(bool number)
        {
            guess++;
            if (guess == 1)
            {
                if (number == true)
                {
                    if (Int32.Parse(txtAnswer.Text) > answer)
                    {
                        MessageBox.Show("Incorrect, you are " + (Int32.Parse(txtAnswer.Text) - answer).ToString() + " away!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect, you are " + (answer - Int32.Parse(txtAnswer.Text)).ToString() + " away!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (guess == 2)
            {
                //frmArithmeticTest.Hide;
                switch (arithmeticOperator)
                {
                    case 'x':
                        //frmtimestables.Show;
                        break;
                    case '/':
                        //frmdivisiontables.Show;
                        break;
                    case '+':
                        //frmadditiontables.Show;
                        break;
                    case '-':
                        //frmsubtractiontables.Show;
                        break;
                }
            }
            else if (guess == 3)
            {
                MessageBox.Show("Incorrect, it was " + answer, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                guess = 0;
                qcount++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Reinitialise()
        {
            lblFactor1.Text = "";
            lblFactor2.Text = "";
            txtAnswer.Text = "";
            btnStart.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Finished()
        {
            float score = correct / totguess;
            MessageBox.Show("You have completed the test","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Reinitialise();

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
