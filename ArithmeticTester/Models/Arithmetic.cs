
namespace ArithmeticTester.Classes
{
    using System;

    /// <summary>
    /// The set of arithmetic operations that are being used.
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// The minimum factor to use in arithmetic operations.
        /// </summary>
        public const byte minFactorValue = 1;
        /// <summary>
        /// The maximum factor to use in arithmetic operations.
        /// </summary>
        public const byte maxFactorValue = 12;

        /// <summary>
        /// Performs a multiplication operation on the given the input values.
        /// The input values must be between the minimum and maximum factors (inclusive).
        /// </summary>
        /// <param name="x">First factor for the multiplication operation.</param>
        /// <param name="y">Second factor for the multiplication operation.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the input values are outside the acceptable range of factors.</exception>
        /// <returns>Integer - result of multiplying the two inputs.</returns>
        public static int Multiply(byte x, byte y)
        {
            if (x >= minFactorValue && x <= maxFactorValue && 
                y >= minFactorValue && y <= maxFactorValue)
            {
                return x * y;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.MultiplicationArgumentsOutOfRange, minFactorValue, maxFactorValue));
            }
        }

        /// <summary>
        /// Performs a division operation on the given the input values.
        /// The inputs are checked to ensure that the result is always a whole numbers 
        /// between the minimum and maximum factors.
        /// The first input value (dividend) must be a multiple (between the minimum and maximum factors (inclusive)) 
        /// of the second input value.
        /// The second input value (divisor) must be between the minimum and maximum factors (inclusive).
        /// </summary>
        /// <param name="x">First factor for the division operation (Dividend).</param>
        /// <param name="y">Second factor for the division operation (Divisor).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the input values are outside the acceptable range of factors.</exception>
        /// <returns>Integer - result of dividing the two inputs.</returns>
        public static int Divide(byte x, byte y)
        {
            if (y >= minFactorValue && y <= maxFactorValue)
            {
                if (x % y == 0 &&  x / y >= minFactorValue && x / y <= maxFactorValue)
                {
                    return x / y;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.DividendArgumentsOutOfRange, minFactorValue ^ 2, maxFactorValue ^ 2));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.DivisorArgumentOutOfRange, minFactorValue, maxFactorValue));
            }
        }

        /// <summary>
        /// Performs a addition operation on the given the input values.
        /// The input values must be between the minimum and maximum factors (inclusive).
        /// </summary>
        /// <param name="x">First factor for the addition operation.</param>
        /// <param name="y">Second factor for the addition operation.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the input values are outside the acceptable range of factors.</exception>
        /// <returns>Integer - result of adding the two inputs.</returns>
        public static int Add(byte x, byte y)
        {
            if (x >= minFactorValue && x <= maxFactorValue &&
                y >= minFactorValue && y <= maxFactorValue)
            {
                return x + y;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.AdditionArgumentsOutOfRange, minFactorValue, maxFactorValue));
            }
        }

        /// <summary>
        /// Performs a subtraction operation on the given the input values.
        /// The input values must be between the minimum and maximum factors (inclusive).
        /// </summary>
        /// <param name="x">First factor for the subtraction operation.</param>
        /// <param name="y">Second factor for the subtraction operation.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the input values are outside the acceptable range of factors.</exception>
        /// <returns>Integer - result of subtracting the two inputs.</returns>
        public static int Subtract(byte x, byte y)
        {
            if (x >= minFactorValue && x <= maxFactorValue &&
                y >= minFactorValue && y <= maxFactorValue)
            {
                return x - y;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(Properties.Resources.SubtractionArgumentsOutOfRange, minFactorValue, maxFactorValue));
            }
        }
    }
}
