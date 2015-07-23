
namespace ArithmeticTester.Controllers
{
    using System;
    using ArithmeticTester.Models;

    /// <summary>
    /// Maintains the state of the arithmetic test.
    /// </summary>
    public static class ArithmeticTest
    {
        private static byte _factor1 = Arithmetic.maxFactorValue;
        private static byte _factor2 = Arithmetic.maxFactorValue;

        /// <summary>
        /// The arithmetic operator to use for questions.
        /// </summary>
        public static ArithmeticOperator arithmeticOperator = ArithmeticOperator.Multiply;

        /// <summary>
        /// Public getter and setter for the first factor of arithmetic questions.
        /// </summary>
        /*public static byte Factor1 
        {
            // Setter is complicated - the value could be larger than normal range if division is selected.
            get { return _factor1; }
            set
            {
                if (value >= Arithmetic.minFactorValue && value <= Arithmetic.maxFactorValue)
                {
                    _factor1 = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }*/
        
        /// <summary>
        /// Public getter and setter for the second factor of arithmetic questions.
        /// </summary>
        public static byte Factor2
        { 
            get { return _factor2; }
            set
            {
                if (value >= Arithmetic.minFactorValue && value <= Arithmetic.maxFactorValue)
                {
                    _factor2 = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.FactorTwoArgumentOutOfRange, Arithmetic.minFactorValue, Arithmetic.maxFactorValue));
                }
            }
        }

        /// <summary>
        /// Returns the results of the arithmetic operation defined by the given factors and operator.
        /// </summary>
        /// <param name="x">The first factor in the arithmetic operation.</param>
        /// <param name="y">The second factor in the arithmetic operation.</param>
        /// <param name="op">The operator for the arithmetic operation.</param>
        /// <returns>Integer - the result of the arithmetic operation.</returns>
        public static int RealAnswer(byte x, byte y, ArithmeticOperator op)
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
                    throw new ArithmeticException(Properties.Resources.UnknownOperatorException);
            }

            return result;
        }
    }
}
