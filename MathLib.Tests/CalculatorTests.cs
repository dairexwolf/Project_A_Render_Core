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
    }
}
