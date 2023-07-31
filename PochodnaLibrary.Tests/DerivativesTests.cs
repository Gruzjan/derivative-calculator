using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Derivative;

namespace Derivative.Tests
{
    public class DerivativeCalculatorTests
    {
        public void Calc_ShortDerivativesShouldCalculate()
        {
            string expected = "15x^2";

            string actual = Calculator.calc("5x^3");
        }
    }
}
