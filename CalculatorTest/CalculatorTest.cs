using System;
using CUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    // Przykłady z wykładu
    [TestClass]
    public class CalculatorTest
    {
        //[ClassInitialize()]
        //public static void Init(TestContext t)
        //{
        //    int s = 2;
        //}

        [TestMethod]
        public void SimpleAdd()
        {
            // arrange
            int arg1 = 10;
            int arg2 = 2;
            int expected = 12;
            var testClass = new Calculator();

            // act
            int actual = testClass.Add(arg1, arg2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimpleIntegerDivide()
        {
            // arrange
            int arg1 = 10;
            int arg2 = 2;
            int expected = 5;
            var testClass = new Calculator();

            // act
            int actual = testClass.Divide(arg1, arg2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimpleDoubleDivide()
        {
            // arrange
            double arg1 = 10;
            double arg2 = 2;
            double expected = 5;
            var testClass = new Calculator();

            // act
            double actual = testClass.Divide(arg1, arg2);

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// How to test irrational number with finite precision
        /// </summary>
        [TestMethod]
        public void IrrationalDoubleDivide()
        {
            // arrange
            double arg1 = 10;
            double arg2 = 3;
            double expected = 3.3333;
            var testClass = new Calculator();

            // act
            double actual = testClass.Divide(arg1, arg2);

            // assert
            Assert.AreEqual(expected, actual, 0.0001);
        }

        /// <summary>
        ///  How to test with expected exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void IntDivideByZero()
        {
            // arrange
            int arg1 = 10;
            int arg2 = 0;
            var testClass = new Calculator();

            // act
            int actual = testClass.Divide(arg1, arg2);
        }


        /// <summary>
        /// How to test exceptions without ExpectedException attribiute
        /// </summary>
        [TestMethod]
        public void IntDivideByZeroWithTry()
        {
            // arrange
            int arg1 = 10;
            int arg2 = 0;
            var testClass = new Calculator();

            // act
            try
            {
                int actual = testClass.Divide(arg1, arg2);
            }
            catch (DivideByZeroException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.Fail("Incorrect exception during dividing by zero");
                return;
            }
            Assert.Fail("The lack of DivideByZero exception");
        }


        // double definie ininity --> divide by 0 = infinity (no exception)
        // int does not have infinity --> divide by 0 thorw exception
        [TestMethod]
        public void DoubleDivideByZero()
        {
            // arrange
            double arg1 = 10;
            double arg2 = 0;
            var testClass = new Calculator();

            // act
            double actual = testClass.Divide(arg1, arg2);

            Assert.AreEqual(actual, double.PositiveInfinity);
        }

        /// <summary>
        /// How to access to private field
        /// </summary>
        [TestMethod]
        public void PrivateFieldAccess()
        {
            // arrange
            var testClass = new Calculator();
            int? expected = -2;
            PrivateObject po = new PrivateObject(testClass);

            // act
            int actual = (int)po.GetFieldOrProperty("_privateField");

            // assert
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// How to access to private method
        /// </summary>
        [TestMethod]
        public void PrivateMethodAccess()
        {
            // arrange
            var testClass = new Calculator();
            int arg = 1;
            int expected = -2;
            PrivateObject po = new PrivateObject(testClass);

            // act
            int actual = (int)po.Invoke("PrivateMethod", arg);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [DataRow(2, 1, 3)]
        [DataRow(3, 2, 5)]
        [DataTestMethod]
        public void AddFromDataRow_Test(int a1, int a2, int expected)
        {
            Calculator cut = new Calculator();
            int actual = cut.Add(a1, a2);

            Assert.AreEqual<int>(expected, actual);
        }

        #region Test Driven Development
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(101)]
        [DataTestMethod]
        public void Number_is_prime(int number)
        {
            var sut = new Calculator();
            var actual = sut.IsPrime(number);
            Assert.IsTrue(actual);
        }


        [DataRow(1)]
        [DataRow(-4)]
        [DataRow(4)]
        [DataRow(100)]
        [DataTestMethod]
        public void Number_is_not_prime(int number)
        {
            var sut = new Calculator();
            var actual = sut.IsPrime(number);
            Assert.IsFalse(actual);
        }
        #endregion
    }
}
