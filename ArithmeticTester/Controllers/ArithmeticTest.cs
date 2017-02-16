using System;
using ArithmeticTester.Models;

namespace ArithmeticTester.Controllers
{
    /// <summary>
    /// Maintains the state of the arithmetic test.
    /// </summary>
    public class ArithmeticTest
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        private Random rd;
        /// <summary>
        /// The first factor of question.
        /// </summary>
        private byte factor1 = Arithmetic.maxFactorValue;
        /// <summary>
        /// The second factor of question.
        /// </summary>
        private byte factor2 = Arithmetic.maxFactorValue;
        /// <summary>
        /// The real answer for the current question.
        /// </summary>
        private int realAnswer;
        /// <summary>
        /// The count of correct answers.
        /// </summary>
        private byte correct;
        /// <summary>
        /// The count of total number of guesses.
        /// </summary>
        private byte totguess;
        /// <summary>
        /// The count of guesses for current question.
        /// </summary>
        private byte guess;
        /// <summary>
        /// The count of questions asked.
        /// </summary>
        private byte qcount;
        /// <summary>
        /// The number of questions to ask.
        /// </summary>
        public readonly byte totalQuestions = 10;

        /// <summary>
        /// The arithmetic operator to use for questions.
        /// </summary>
        public ArithmeticOperator arithmeticOperator = ArithmeticOperator.Multiply;

        /// <summary>
        /// Constructor for the Arithmetic Test controller object.
        /// </summary>
        /// <param name="rand">The random number generator to use.</param>
        public ArithmeticTest(Random rand)
        {
            this.rd = rand;
            InitialiseCounts();
        }

        /// <summary>
        /// Initialise the counts for the test object.
        /// Set the counts for questions, guesses and correct answers to 0.
        /// </summary>
        public void InitialiseCounts()
        {
            correct = 0;
            totguess = 0;
            guess = 0;
            qcount = 0;
        }

        /// <summary>
        /// Handles setting the next question.
        /// Moves to the next question and gets new factors.
        /// </summary>
        public void SetNextQuestion()
        {
            IncrementQuestionCount();
            ResetGuessCount();
            SetNextFactors();
            SetRealAnswer();
        }

        /// <summary>
        /// Public accessor method for the first factor for the current question.
        /// </summary>
        /// <returns>Byte - the first factor.</returns>
        public byte GetFactor1()
        {
            return factor1;
        }

        /// <summary>
        /// Public accessor method for the second factor for the current question.
        /// </summary>
        /// <returns>Byte - the second factor.</returns>
        public byte GetFactor2()
        {
            return factor2;
        }

        /// <summary>
        /// Public accessor method for the correct answer to the current question.
        /// </summary>
        /// <returns>Integer - the real answer.</returns>
        public int GetRealAnswer()
        {
            return realAnswer;
        }

        /// <summary>
        /// Get count of correct answers.
        /// </summary>
        /// <returns>Byte - the number of correct answers.</returns>
        public byte GetCorrectCount()
        {
            return correct;
        }

        /// <summary>
        /// Increment count of correct answers.
        /// </summary>
        public void IncrementCorrectCount()
        {
            correct++;
        }

        /// <summary>
        /// Get count of total guesses.
        /// </summary>
        /// <returns>Byte - the total number of guesses.</returns>
        public byte GetTotalGuessCount()
        {
            return totguess;
        }

        /// <summary>
        /// Increment count of total guesses.
        /// </summary>
        public void IncrementTotalGuessCount()
        {
            totguess++;
        }

        /// <summary>
        /// Get count of guesses for current question.
        /// </summary>
        /// <returns>Byte - the number of correct answers.</returns>
        public byte GetGuessCount()
        {
            return guess;
        }

        /// <summary>
        /// Get count of number of questions asked.
        /// </summary>
        /// <returns>Byte - the number of questions asked.</returns>
        public byte GetQuestionCount()
        {
            return qcount;
        }

        /// <summary>
        /// Increment count of guesses for current question.
        /// </summary>
        public void IncrementGuessCount()
        {
            guess++;
        }

        /// <summary>
        /// Reset count of guesses for current question back to zero.
        /// </summary>
        private void ResetGuessCount()
        {
            guess = 0;
        }

        /// <summary>
        /// Get count of number of questions asked.
        /// </summary>
        /// <returns>Byte - the number of questions asked.</returns>
        public byte GetQuestionCount()
        {
            return qcount;
        }

        /// <summary>
        /// Increment count of number of questions asked.
        /// </summary>
        private void IncrementQuestionCount()
        {
            qcount++;
        }
    }
}
