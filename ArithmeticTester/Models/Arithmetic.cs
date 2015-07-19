
namespace ArithmeticTester.Classes
{
    /// <summary>
    /// The set of arithmetic operations that are being used.
    /// </summary>
    public static class Arithmetic
    {
        /// <summary>
        /// Performs a multiplication operation on the given the input values.
        /// </summary>
        /// <param name="x">First factor for the multiplication operation.</param>
        /// <param name="y">Second factor for the multiplication operation.</param>
        /// <returns></returns>
        public static int Multiply(byte x, byte y)
        {
            return x * y;
        }

        /// <summary>
        /// Performs a division operation on the given the input values.
        /// Note that this is integer division so the results may not be what you expect.
        /// </summary>
        /// <param name="x">First factor for the division operation.</param>
        /// <param name="y">Second factor for the division operation.</param>
        /// <returns></returns>
        public static int Divide(byte x, byte y)
        {
            return x / y;
        }

        /// <summary>
        /// Performs a addition operation on the given the input values.
        /// </summary>
        /// <param name="x">First factor for the addition operation.</param>
        /// <param name="y">Second factor for the addition operation.</param>
        /// <returns></returns>
        public static int Add(byte x, byte y)
        {
            return x + y;
        }

        /// <summary>
        /// Performs a subtraction operation on the given the input values.
        /// </summary>
        /// <param name="x">First factor for the subtraction operation.</param>
        /// <param name="y">Second factor for the subtraction operation.</param>
        /// <returns></returns>
        public static int Subtract(byte x, byte y)
        {
            return x - y;
        }
    }
}
