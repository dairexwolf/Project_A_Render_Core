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
        public float Divide(float a, float b, float epsilon = 0.0001f)
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

        /// <summary>
        /// Строгая точность сравнения float
        /// </summary>
        public const float EpsilonStrict = 0.000001f;


        /// <summary>
        /// Solves ax² + bx + c = 0
        /// </summary>
        /// <returns>
        /// Array of roots: 
        /// - {NaN, NaN} if no real roots or degenerate case with no solution
        /// - {x, NaN} if one root (linear or D=0)
        /// - {x1, x2} if two distinct roots
        /// </returns>
        public static float[] Quadratic(float a, float b, float c)
        {

            float[] res = { float.NaN, float.NaN };

            // Проверка на вырожденный случай (a ≈ 0)
            if (MathF.Abs(a) < Epsilon)
            {
                if (MathF.Abs(b) > Epsilon)
                {
                    // Линейное уравнение bx = -c
                    res[0] = -c / b;
                }
                // Если a=0 и b=0, уравнение не имеет решений или имеет бесконечное множество.
                // Возвращаем {NaN, NaN}.
                return res;
            }

            // Вычисление дискриминанта
            float d = Square(b) - 4f * a * c;

            if (d < -Epsilon)   // Небольшой допуск на отрицательное значение из-за погрешности
            {
                // Корней в действительных числах нет.
                return res;
            }

            // Для D == 0
            if (MathF.Abs(d) < Epsilon)
            {
                res[0] = -b / (2f * a);
                return res;
            }

            // Вычисляем корень дискриминанта
            float sqrtD = Sqrt(d);
            // Вычисляем то, что под знаком деления (2 * a)
            float denominator = 2f * a;

            // Формулы корней
            res[0] = (-b + sqrtD) / denominator;
            res[1] = (-b - sqrtD) / denominator;

            return res;
        }

        /// <summary>
        /// Evaluating Quadratic Function by type - f(x) = ax^2 + bx + c
        /// </summary>
        public static float EvaluateQuadratic(float x, float a, float b, float c)
        {
            float res = a * Square(x) + b * x + c;
            return res;
        }

        /// <summary>
        /// Evaluating linear function by type - f(x) = kx + b
        /// </summary>
        /// <returns></returns>
        public static float EvaluateLinear(float x, float slope, float intercept)
        {
            float res = x * slope + intercept;
            return res;
        }

        /// <summary>
        /// Evaluating linear function though Two point on coods x1, y1, x2, y2
        /// </summary>
        public static float EvaluateLinearThroughPoints(float x, float x1, float y1, float x2, float y2)
        {
            // Checking the vertical line (dividing by zero)
            if (MathF.Abs(x2 - x1) < Epsilon)
                return float.NaN;
            float slope = (y2 - y1) / (x2 - x1);
            float intercept = y1 - slope * x1;
            float res = slope * x + intercept;
            return res;
        }

        /// <summary>
        /// Retuns the square of a value
        /// </summary>
        public static float Square(float value)
        {
            return value * value;
        }

        /// <summary>
        /// Raises baseValue to the power of exponent
        /// </summary>
        public static float Power(float baseValue, float exponent)
        {
            return MathF.Pow(baseValue, exponent);
        }

        /// <summary>
        /// Returns the root of a number using the MathF library
        /// </summary>
        public static float Sqrt(float value)
        {
            if (value < 0f) return float.NaN;
            return MathF.Sqrt(value);
        }

        /// <summary>
        /// Метод Ньютона (Newton-Raphson). Итеративный алгоритм, который сходится к корню.
        /// Алгоритм решает уравнение x^2 - value = 0 через итерации:
        /// x_{n+1} = 0.5 * (x_n + value / x_n)
        /// </summary>
        public static float SqrtNR(float value)
        {
            if (value < 0f) return float.NaN;
            if (value == 0f || value == 1f) return value;

            // Начальное приближение: половина от value
            float x = value * 0.5f;

            // Итерации метода Ньютона: x_new = 0.5 * (x + value/x)
            for (int i = 0; i < 20; i++) // 20 итераций достаточно для сходимости float
            {
                float nextX = 0.5f * (x + value / x);

                // Проверка сходимости
                if (MathF.Abs(nextX - x) < EpsilonStrict)
                    return nextX;

                x = nextX;
            }

            return x;
        }

        /// <summary>
        /// Raising to a root using the power property
        /// </summary>
        public static float NthRoot(float value, float n)
        {
            // n^sqrt(a) ≡ a^(1/n)
            return Power(value, 1f / n);
        }

        /// <summary>
        /// Вычисляет логарифм числа по произвольному основаниюю. Все методы делигируют все библиотеке MathF
        /// </summary>
        /// <param name="value">Число > 0</param>
        /// <param name="baseValue">Основание логарифма (> 0, != 1)</param>
        /// <returns>log_baseValue(value)</returns>
        public static float Log(float value, float baseValue)
        {
            // log_a(b), a - основание, b - аргумент
            // Проверка аргумента
            if (value <= 0f || float.IsNaN(value)) return float.NaN;
            // Проверка основания
            if (baseValue <= 0f || MathF.Abs(baseValue - 1f) < Epsilon || float.IsNaN(baseValue)) return float.NaN;

            // Смена основания
            /// Стандартная библиотека .NET предоставляет только MathF.Log (натуральный) и MathF.Log10. Для произвольного основания используем формулу смены основания — это математически корректно и соответствует учебным целям.
            /// Смена основания: log_b(a) = ln(a) / ln(b)
            return MathF.Log(value) / MathF.Log(baseValue);
        }

        /// <summary>
        /// Вычисляет десятичный логарифм по основанию 10. 
        /// </summary>
        public static float Log10(float value)
        {
            if (value <= 0f || float.IsNaN(value)) return float.NaN;
            return MathF.Log10(value);
        }

        /// <summary>
        /// Вычисляет десятичный логарифм по основанию e
        /// </summary>
        public static float Ln(float value)
        {
            if (value <= 0f || float.IsNaN(value)) return float.NaN;
            return MathF.Log(value);    // MathF.Log - натуральный логарифм
        }
    }
}
