using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Derivative;
using Xunit;

namespace Derivative.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("x", "1")]
        [InlineData("5", "0")]
        [InlineData("x^10", "10x^9")]
        [InlineData("5/0x^2", "Error division by 0")]
        [InlineData("5x^2", "10x")]
        public void Calc_ShortDerivativesShouldCalculate(string expression, string expected)
        {
            string actual = Calculator.calc(expression);
            Assert.Equal(expected, actual);
        }

    }
}
