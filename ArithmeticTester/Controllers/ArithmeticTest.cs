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
        private Random rd = new Random();
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
        public ArithmeticTest()
        {
            
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
        /// Picks a new value for the factors for the next question.
        /// </summary>
        public void SetNextFactors()
        {
            factor2 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);

            factor1 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);
            if (arithmeticOperator == ArithmeticOperator.Divide) factor1 = (byte)Arithmetic.Multiply(factor2, factor1);
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
        /// Returns the results of the arithmetic operation defined by the current factors and operator.
        /// </summary>
        /// <returns>Integer - the result of the arithmetic operation.</returns>
        public void SetRealAnswer()
        {
            switch (arithmeticOperator)
            {
                case ArithmeticOperator.Add:
                    realAnswer = Arithmetic.Add(factor1, factor2);
                    break;
                case ArithmeticOperator.Divide:
                    realAnswer = Arithmetic.Divide(factor1, factor2);
                    break;
                case ArithmeticOperator.Multiply:
                    realAnswer = Arithmetic.Multiply(factor1, factor2);
                    break;
                case ArithmeticOperator.Subtract:
                    realAnswer = Arithmetic.Subtract(factor1, factor2);
                    break;
                default:
                    throw new ArithmeticException(Properties.Resources.UnknownOperatorException);
            }
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
        /// Reset count of correct answers back to zero.
        /// </summary>
        public void ResetCorrectCount()
        {
            correct = 0;
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
        /// Reset count of total guesses back to zero.
        /// </summary>
        public void ResetTotalGuessCount()
        {
            totguess = 0;
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
        /// Increment count of guesses for current question.
        /// </summary>
        public void IncrementGuessCount()
        {
            guess++;
        }

        /// <summary>
        /// Reset count of guesses for current question back to zero.
        /// </summary>
        public void ResetGuessCount()
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
        public void IncrementQuestionCount()
        {
            qcount++;
        }

        /// <summary>
        /// Reset count of number of questions asked so far back to zero.
        /// </summary>
        public void ResetQuestionCount()
        {
            qcount = 0;
        }
    }
}
