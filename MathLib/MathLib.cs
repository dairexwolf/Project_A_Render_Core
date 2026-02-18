namespace MathLib
{
    /// <summary>
    /// Стандартные математические действия
    /// </summary>
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
        /// <exception cref="DivideByZeroException">When b is 0</exception>
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero value");
            return a / b;
        }

        /// <summary>
        /// Divides a by b with an epsilon precision 
        /// </summary>
        /// <param name="a">First num</param>
        /// <param name="b">Second num</param>
        /// <param name="epsilon">Precision</param>
        /// <returns>a divided by b</returns>
        /// <exception cref="DivideByZeroException">When b is near by 0</exception>
        public float Divide(float a, float b, float epsilon=0.0001f)
        {
            if (Math.Abs(b) < epsilon)
                throw new DivideByZeroException("Division by near-zero value");
            return a / b;
        }
    }
    
    /// <summary>
    /// Утилитарные математические функции для графики и физики
    /// Основно на главах 1-2 "No Bullshit Guide to Math and Physics"
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Точность сравнения float
        /// </summary>
        public const float Epsilon = 0.0001f;

        // Строгая точность сравнения float
        public const float EpsilonStrict = 0.000001f;
    }
}
