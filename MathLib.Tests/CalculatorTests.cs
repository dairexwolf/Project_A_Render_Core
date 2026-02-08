using Xunit;
using MathLib;

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
    }
}
