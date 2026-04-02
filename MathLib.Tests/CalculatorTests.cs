using Xunit;
using MathLib;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace MathLib.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoNums_ReturnsSum()
        {

            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            var calculator = new Calculator();              // Arrange
            var result = calculator.Subtract(5, 3);         // Act
            Assert.Equal(2, result);                        // Assert
        }

        [Fact]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            var calculator = new Calculator();              // Arrange
            var result = calculator.Multiply(5, 3);         // Act
            Assert.Equal(15, result);                       // Assert
        }

        [Fact]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            var calculator = new Calculator();              // Arrange
            var result = calculator.Divide(30, 3);          // Act
            Assert.Equal(10, result);                       // Assert
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var calc = new Calculator();
            float a = 10, b = 0;
            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(a, b));
        }

        [Fact]
        public void Divide_TwoFloatNumbers_ReturnsQuotient()
        {
            // Arrange
            var calc = new Calculator();
            // Act
            var res = calc.Divide(15f, 5f);
            // Assert
            Assert.Equal(3f, res, precision: 1);
        }

        [Fact]
        public void Divide_ByFloatZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var calc = new Calculator();
            float a = 5f, b = 0f;
            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(a, b));
        }
    }

    public class MathUtilsTests
    {
        [Fact]
        public void MathUtils_Epsilon_IsDefinded()
        {
            // Arrange and Act
            float eps = MathUtils.Epsilon;
            // Assert
            Assert.Equal(0.0001f, eps);
        }

        [Fact]
        public void Power_PositiveExponent_ReturnCorrectResult()
        {
            // Arrange
            float baseValue = 2f;
            float exponent = 3f;
            float expected = 8f;

            //Act
            float result = MathUtils.Power(baseValue, exponent);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        [Fact]
        public void Power_ZeroExponent_ReturnsOne()
        {
            // Arrange
            float baseValue = 2f;
            float exponent = 0f;
            float expected = 1f;

            //Act
            float result = MathUtils.Power(baseValue, exponent);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        [Fact]
        public void Square_PositiveValue_ReturnsCorrectResult()
        {
            // Arrange
            float baseValue = 3f;
            float expected = 9f;

            //Act
            float result = MathUtils.Square(baseValue);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        [Fact]
        public void Square_NegotiveValue_ReturnsCorrectResult()
        {
            // Arrange
            float baseValue = -4f;
            float expected = 16f;

            //Act
            float result = MathUtils.Square(baseValue);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        [Fact]
        public void Quadratic_TwoRealRoots_ReturnsCorrectValues()
        {
            // 2x^2 - x - 3 = 0 -> корни 1.5 и -1
            // Arrange & Act
            var roots = MathUtils.Quadratic(2f, -1f, -3f);

            // Assert
            Assert.Equal(-1f, roots[1], precision: 5);
            Assert.Equal(1.5f, roots[0], precision: 5);
        }

        [Fact]
        public void Quadratic_OneRoot_DiscriminantZero()
        {
            // x^2 - 4x + 4 = 0 -> корень: 2
            // Arrange & Act
            var roots = MathUtils.Quadratic(1f, -4f, 4f);

            // Assert
            Assert.Equal(2f, roots[0], precision: 5);
            Assert.True(float.IsNaN(roots[1]));
        }

        [Fact]
        public void Quadratic_NoRealRoots_ReturnNaNs()
        {
            // x^2 + 1 = 0 -> нет корней
            // Arrange & Act
            var roots = MathUtils.Quadratic(1f, 0f, 1f);

            // Assert
            Assert.True(float.IsNaN(roots[0]));
            Assert.True(float.IsNaN(roots[1]));
        }

        [Fact]
        public void Quadratic_DegenerateToLinearCase_OneRoot()
        {
            // 0x^2 + 2x + 4 = 0 -> линейное: 2x = -4, x = -2
            // Arrange & Act
            var roots = MathUtils.Quadratic(0f, 2f, 4f);

            // Assert
            Assert.Equal(-2f, roots[0], precision: 5);
            Assert.True(float.IsNaN(roots[1]));
        }

        [Fact]
        public void NthRoot_TwoPositiveNums_ReturnSqrt()
        {
            // Arrange
            float value = 9f;
            float n = 2f;

            // Act
            float res = MathUtils.NthRoot(value, n);

            // Assert -> sqrt(9) = 3
            Assert.Equal(3f, res, precision: 5);
        }

        [Fact]
        public void SqrtNR_TwoPositiveNums_ReturnSqrt()
        {
            // Arrange
            float value = 25f;

            // Act
            float res = MathUtils.SqrtNR(value);

            // Assert -> sqrt(25) = 5
            Assert.Equal(5f, res, precision: 5);
        }

        [Fact]
        public void SqrtNR_NegativeValue_ReturnsNaN()
        {
            Assert.True(float.IsNaN(MathUtils.SqrtNR(-4f)));
        }

        [Fact]
        public void Log_Base2of8_Returns3()
        {
            // log_2(8) = 3, 2^3 = 8
            // Arrange
            float x = 8f;
            float y = 2f;
            // Act
            float res = MathUtils.Log(x, y);
            // Assert
            Assert.Equal(3f, res, precision: 5);
        }

        [Fact]
        public void Log10_of10000_Returns4()
        {
            // log_10(10000) = 4
            // Arrange
            float x = 10000f;
            // Act
            float res = MathUtils.Log10(x);
            // Assert
            Assert.Equal(4f, res, precision: 5);
        }

        [Fact]
        public void Log10_ofE_Returns1()
        {
            // ln(e) = 1
            // Arrange & Act
            float res = MathUtils.Ln(MathF.E);
            // Assert
            Assert.Equal(1f, res, precision: 5);
        }

        [Fact]
        public void Log_ZeroValue_ReturnsNaN()
        {
            // Arrange
            float x = 0f;
            float y = 2f;
            // Act
            float res = MathUtils.Log(x, y);
            // Assert
            Assert.True(float.IsNaN(res));
        }

        [Fact]
        public void Log_NegativeValue_ReturnsNaN()
        {
            // Arrange
            float x = -10f;
            float y = 2f;
            // Act
            float res = MathUtils.Log(x, y);
            // Assert
            Assert.True(float.IsNaN(res));
        }

        [Fact]
        public void Log_Base1_ReturnsNaN()
        {
            // Логарифм по основанию 1 не определен
            // log_1(8) = NaN
            // Arrange
            float x = 8f;
            float y = 1f;
            // Act
            float res = MathUtils.Log(x, y);
            // Assert
            Assert.True(float.IsNaN(res));
        }

        [Fact]
        public void Log_PropertyOfProduct()
        {
            // Проверка первого свойства логарифма: log_b(xy) = log_b(x) + log_b(y)
            // Arrange
            float x = 4f;
            float y = 8f;
            float b = 2f;

            // Act
            float left = MathUtils.Log(x * y, b);
            float right = MathUtils.Log(x, b) + MathUtils.Log(y, b);

            // Assert
            Assert.Equal(left, right, precision: 5);
        }

        [Fact]
        public void EvaluateLinear_PositiveXAndTwoPositiveNums_ReturnsCorrectValue()
        {
            // f(x) = 2x+3, x=4, res = 11
            // Arrange
            float a = 2f;
            float b = 3f;
            float x = 4f;
            // Act
            float res = MathUtils.EvaluateLinear(x, a, b);
            // Assert
            Assert.Equal(11f, res, precision: 5);
        }

        [Fact]
        public void EvaluateLinear_NegativeXAndTwoPositiveNums_ReturnsCorrectValue()
        {
            // f(x) = 2x+3, x=-4, res = -5
            // Arrange
            float a = 2f;
            float b = 3f;
            float x = -4f;
            // Act
            float res = MathUtils.EvaluateLinear(x, a, b);
            // Assert
            Assert.Equal(-5f, res, precision: 5);
        }

        [Fact]
        public void EvaluateLinear_ZeroSlope_ReturnsIntercept()
        {
            // f(x) = 0x+3, x=4, res = 3
            // Arrange
            float a = 0f;
            float b = 3f;
            float x = 4f;
            // Act
            float res = MathUtils.EvaluateLinear(x, a, b);
            // Assert
            Assert.Equal(3f, res, precision: 5);
        }

        [Fact]
        public void EvaluateLinearThroughTwoPoints_LinearLine_ReturnsCorrectValue()
        {
            // Point (1, 1) and (3, 3), x = 10, rez = 10
            // Arrange
            float x = 10f;
            float x1 = 1f;
            float y1 = 1f;
            float x2 = 3f;
            float y2 = 3f;
            // Act
            float res = MathUtils.EvaluateLinearThroughPoints(x, x1, y1, x2, y2);
            // Assert
            Assert.Equal(10f, res, precision: 5);
        }

        [Fact]
        public void EvaluateLinearThroughTwoPoints_HorizontalLine_ReturnsConstant()
        {
            // Point (0, 3) and (5, 3), res - horizontal line, where y=3
            // Arrange
            float x = 10f;
            float x1 = 0f;
            float y1 = 3f;
            float x2 = 5f;
            float y2 = 3f;
            // Act
            float res = MathUtils.EvaluateLinearThroughPoints(x, x1, y1, x2, y2);
            // Assert
            Assert.Equal(3f, res, precision: 5);
        }

        [Fact]
        public void EvaluateLinearThroughTwoPoints_VerticalLine_ReturnsNaN()
        {
            // Point (2, 0) and (2, 5), res - vertical line, non function, res = NaN
            // Arrange
            float x = 2f;
            float x1 = 2f;
            float y1 = 0f;
            float x2 = 2f;
            float y2 = 5f;
            // Act
            float res = MathUtils.EvaluateLinearThroughPoints(x, x1, y1, x2, y2);
            // Assert
            Assert.True(float.IsNaN(res));
        }

        [Fact]
        public void EvaluateQuadratic_NegativeX_CorrectValue()
        {
            // f(-1) = 2(-1)^2-(-1)-3 = 3-3=0
            // Arrange & Act
            float res = MathUtils.EvaluateQuadratic(-1f, 2f, -1f, -3f);

            // Assert
            Assert.Equal(0f, res, precision: 5);
        }

        [Fact]
        public void EvaluateQuadratic_AllPositiveNums_CorrectValue()
        {
            // f(x) = 2*x^2+5x+10
            // f(10) = 2*(100)+50+10 = 260
            // Arrange & Act
            float res = MathUtils.EvaluateQuadratic(10f, 2f, 5f, 10f);

            // Assert
            Assert.Equal(260f, res, precision: 5);
        }
    }
}
