using System;
using ArithmeticTester.Models;

namespace ArithmeticTester.Controllers
{
    /// <summary>
    /// Maintains the state of the arithmetic test.
    /// </summary>
    public static class ArithmeticTest
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        private static Random rd = new Random();
        /// <summary>
        /// The first factor of question.
        /// </summary>
        private static byte factor1 = Arithmetic.maxFactorValue;
        /// <summary>
        /// The second factor of question.
        /// </summary>
        private static byte factor2 = Arithmetic.maxFactorValue;
        /// <summary>
        /// The real answer for the current question.
        /// </summary>
        private static int realAnswer;
        /// <summary>
        /// The count of correct answers.
        /// </summary>
        private static byte correct;
        /// <summary>
        /// The count of total number of guesses.
        /// </summary>
        private static byte totguess;
        /// <summary>
        /// The count of guesses for current question.
        /// </summary>
        private static byte guess;
        /// <summary>
        /// The count of questions asked.
        /// </summary>
        private static byte qcount;
        /// <summary>
        /// The number of questions to ask.
        /// </summary>
        public const byte totalQuestions = 10;

        /// <summary>
        /// The arithmetic operator to use for questions.
        /// </summary>
        public static ArithmeticOperator arithmeticOperator = ArithmeticOperator.Multiply;

        /// <summary>
        /// Public accessor method for the first factor for the current question.
        /// </summary>
        /// <returns>Byte - the first factor.</returns>
        public static byte GetFactor1()
        {
            return factor1;
        }

        /// <summary>
        /// Public accessor method for the second factor for the current question.
        /// </summary>
        /// <returns>Byte - the second factor.</returns>
        public static byte GetFactor2()
        {
            return factor2;
        }

        /// <summary>
        /// Picks a new value for the factors for the next question.
        /// </summary>
        public static void SetNextFactors()
        {
            factor2 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);

            factor1 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);
            if (ArithmeticTest.arithmeticOperator == ArithmeticOperator.Divide) factor1 = (byte)Arithmetic.Multiply(factor2, factor1);
        }

        /// <summary>
        /// Public accessor method for the correct answer to the current question.
        /// </summary>
        /// <returns>Integer - the real answer.</returns>
        public static int GetRealAnswer()
        {
            return realAnswer;
        }

        /// <summary>
        /// Returns the results of the arithmetic operation defined by the current factors and operator.
        /// </summary>
        /// <returns>Integer - the result of the arithmetic operation.</returns>
        public static void SetRealAnswer()
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
        public static byte GetCorrectCount()
        {
            return correct;
        }

        /// <summary>
        /// Increment count of correct answers.
        /// </summary>
        public static void IncrementCorrectCount()
        {
            correct++;
        }

        /// <summary>
        /// Reset count of correct answers back to zero.
        /// </summary>
        public static void ResetCorrectCount()
        {
            correct = 0;
        }

        /// <summary>
        /// Get count of total guesses.
        /// </summary>
        /// <returns>Byte - the total number of guesses.</returns>
        public static byte GetTotalGuessCount()
        {
            return totguess;
        }

        /// <summary>
        /// Increment count of total guesses.
        /// </summary>
        public static void IncrementTotalGuessCount()
        {
            totguess++;
        }

        /// <summary>
        /// Reset count of total guesses back to zero.
        /// </summary>
        public static void ResetTotalGuessCount()
        {
            totguess = 0;
        }

        /// <summary>
        /// Get count of guesses for current question.
        /// </summary>
        /// <returns>Byte - the number of correct answers.</returns>
        public static byte GetGuessCount()
        {
            return guess;
        }

        /// <summary>
        /// Increment count of guesses for current question.
        /// </summary>
        public static void IncrementGuessCount()
        {
            guess++;
        }

        /// <summary>
        /// Reset count of guesses for current question back to zero.
        /// </summary>
        public static void ResetGuessCount()
        {
            guess = 0;
        }

        /// <summary>
        /// Get count of number of questions asked.
        /// </summary>
        /// <returns>Byte - the number of questions asked.</returns>
        public static byte GetQuestionCount()
        {
            return qcount;
        }

        /// <summary>
        /// Increment count of number of questions asked.
        /// </summary>
        public static void IncrementQuestionCount()
        {
            qcount++;
        }

        /// <summary>
        /// Reset count of number of questions asked so far back to zero.
        /// </summary>
        public static void ResetQuestionCount()
        {
            qcount = 0;
        }
    }
}
