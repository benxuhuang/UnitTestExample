using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void Add_Input_First_1_Second_2_Return_3()
        {
            //arrange
            Calculator target = new Calculator();
            int firstNumber = 1;
            int secondNumber = 2;
            int expected = 3;

            //act
            int actual;
            actual = target.Add(firstNumber, secondNumber);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Minus_Input_First_3_Second_2_Return_1()
        {
            //arrange
            Calculator target = new Calculator();
            int firstNumber = 3;
            int secondNumber = 2;
            int expected = 1;

            //act
            int actual;
            actual = target.Minus(firstNumber, secondNumber);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}