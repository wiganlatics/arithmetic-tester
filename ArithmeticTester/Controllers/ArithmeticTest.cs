/*
 * Copyright (c) 2017 Matthew Wright.
 * Licensed under MIT License. See LICENSE.txt for further details.
 * 
 * This software should be distributed with a LICENSE.TXT file in the solution root.
 * Alternatively  you can find a copy of the license in the github repository:
 * https://github.com/wiganlatics/temperature-converter.
 * The MIT License text is also available at: https://choosealicense.com/licenses/mit/.
 */

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
        private byte factor1;
        /// <summary>
        /// The second factor of question.
        /// </summary>
        private byte factor2;
        /// <summary>
        /// The real answer for the current question.
        /// </summary>
        private int realAnswer;
        /// <summary>
        /// The count of correct answers.
        /// </summary>
        private byte correct;
        /// <summary>
        /// The count of total number of guesses. Is a short integer since there may be multiple guesses per question.
        /// i.e. guesses (byte) * qcount (byte) may be larger than max byte value.
        /// </summary>
        private short totguess;
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
        private readonly byte totalQuestions;

        /// <summary>
        /// The arithmetic operator to use for questions.
        /// </summary>
        public ArithmeticOperator arithmeticOperator = ArithmeticOperator.Multiply;

        /// <summary>
        /// Constructor for the Arithmetic Test controller object.
        /// </summary>
        /// <param name="rand">The random number generator to use.</param>
        /// <param name="totalQuestions">Total number of questions in a test.</param>
        /// <exception cref="System.ArgumentException">Thrown if the number of questions is not greater than zero.</exception>
        public ArithmeticTest(Random rand, byte totalQuestions)
        {
            if (totalQuestions > 0)
            {
                this.rd = rand;
                this.totalQuestions = totalQuestions;
                InitialiseCounts();
            }
            else
            {
                throw new ArgumentException(Properties.Resources.ArgumentMustBeAboveZero);
            }
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
        /// Converts the given answer string to a number and checks if the answer is correct.
        /// </summary>
        /// <param name="answer">The answer in string form.</param>
        /// <returns>Bool - true if answer is correct, false otherwise.</returns>
        public bool SubmitAnswer(string answer)
        {
            bool isCorrect = false;

            IncrementTotalGuessCount();

            int answerNum;
            if (answer.Length > 0 && Int32.TryParse(answer, out answerNum))
            {
                if (answerNum == realAnswer)
                {
                    isCorrect = true;
                    if (guess == 0) IncrementCorrectCount();
                }
                else
                {
                    IncrementGuessCount();
                }
            }
            else
            {
                IncrementGuessCount();
            }

            return isCorrect;
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
        /// Get count of total guesses.
        /// </summary>
        /// <returns>Short - the total number of guesses.</returns>
        public short GetTotalGuessCount()
        {
            return totguess;
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
        /// Get the total number of questions in a test.
        /// </summary>
        /// <returns>Byte - the number of questions to ask.</returns>
        public byte GetTotalQuestionsCount()
        {
            return totalQuestions;
        }

        /// <summary>
        /// Increment count of correct answers.
        /// </summary>
        /// <exception cref="System.Exception">Thrown if the type of correct instance variable is not a byte.</exception>
        /// <exception cref="System.OverflowException">Thrown if incrementing correct count would take it above max byte value.</exception>
        private void IncrementCorrectCount()
        {
            if (correct.GetType().Equals(typeof(byte)))
            {
                if (correct < byte.MaxValue)
                {
                    correct++;
                }
                else
                {
                    throw new OverflowException(string.Format(Properties.Resources.OverflowError, Properties.Resources.CorrectAnswersCount));
                }
            }
            else
            {
                throw new Exception(string.Format(Properties.Resources.WrongTypeError, Properties.Resources.CorrectAnswersCount, typeof(byte).Name, correct.GetType().Name));
            }
        }

        /// <summary>
        /// Increment count of total guesses.
        /// </summary>
        /// <exception cref="System.Exception">Thrown if the type of total guesses instance variable is not a short.</exception>
        /// <exception cref="System.OverflowException">Thrown if incrementing total guess count would take it above max short value.</exception>
        private void IncrementTotalGuessCount()
        {
            if (totguess.GetType().Equals(typeof(short)))
            {
                if (totguess < short.MaxValue)
                {
                    totguess++;
                }
                else
                {
                    throw new OverflowException(string.Format(Properties.Resources.OverflowError, Properties.Resources.TotalGuessesCount));
                }
            }
            else
            {
                throw new Exception(string.Format(Properties.Resources.WrongTypeError, Properties.Resources.TotalGuessesCount, typeof(short).Name, totguess.GetType().Name));
            }
        }

        /// <summary>
        /// Increment count of guesses for current question.
        /// </summary>
        /// <exception cref="System.Exception">Thrown if the type of guess instance variable is not a byte.</exception>
        /// <exception cref="System.OverflowException">Thrown if incrementing guess count would take it above max byte value.</exception>
        private void IncrementGuessCount()
        {
            if (guess.GetType().Equals(typeof(byte)))
            {
                if (guess < byte.MaxValue)
                {
                    guess++;
                }
                else
                {
                    throw new OverflowException(string.Format(Properties.Resources.OverflowError, Properties.Resources.GuessesCount));
                }
            }
            else
            {
                throw new Exception(string.Format(Properties.Resources.WrongTypeError, Properties.Resources.GuessesCount, typeof(byte).Name, guess.GetType().Name));
            }
        }

        /// <summary>
        /// Reset count of guesses for current question back to zero.
        /// </summary>
        private void ResetGuessCount()
        {
            guess = 0;
        }

        /// <summary>
        /// Increment count of number of questions asked.
        /// </summary>
        /// <exception cref="System.Exception">Thrown if the question count has reached maximum number of questions.</exception>
        private void IncrementQuestionCount()
        {
            if (qcount <= totalQuestions)
            {
                qcount++;
            }
            else
            {
                throw new Exception(string.Format(Properties.Resources.CannotIncrementQuestionCountAboveTotal, qcount));
            }
        }

        /// <summary>
        /// Picks a new value for the factors for the next question.
        /// </summary>
        private void SetNextFactors()
        {
            factor2 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);
            factor1 = (byte)rd.Next(Arithmetic.minFactorValue, Arithmetic.maxFactorValue);
            if (arithmeticOperator == ArithmeticOperator.Divide) factor1 = (byte)Arithmetic.Multiply(factor2, factor1);
        }

        /// <summary>
        /// Returns the results of the arithmetic operation defined by the current factors and operator.
        /// </summary>
        /// <returns>Integer - the result of the arithmetic operation.</returns>
        /// <exception cref="System.ArithmeticException">Throws an exception if an unknown operator is specified.</exception>
        private void SetRealAnswer()
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
    }
}
