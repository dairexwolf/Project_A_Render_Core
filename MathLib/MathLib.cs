namespace MathLib
{
    public class Calculator
    {
        /// <summary>
        /// Adds to a b
        /// </summary>
        /// <param name="a">First num</param>
        /// <param name="b">Second num</param>
        /// <returns>a increased by b</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Decreases from a to b
        /// </summary>
        /// <param name="a">First num</param>
        /// <param name="b">Second num</param>
        /// <returns>a reduced by b</returns>
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies a and b
        /// </summary>
        /// <param name="a">First num</param>
        /// <param name="b">Second num</param>
        /// <returns>a multiplied by b</returns>
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides a by b
        /// </summary>
        /// <param name="a">First num</param>
        /// <param name="b">Second num</param>
        /// <returns>a divided by b</returns>
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
