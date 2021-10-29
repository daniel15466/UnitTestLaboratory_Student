using System;
using CUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZajeciaTest
{
    [TestClass]
    public class ZajeciaTest
    {
        // tutaj należy umieścić rozwiązania zadań 1, 2, 3, 5, 6 i 7
        // każdy test powinien posiadać atrybut [TestMethod]

        //IsEven_Test - klasy równoważności
        //liczby parzyste
        //liczby nieparzyste
        //0
        //argumenty niedozwolone
        [TestMethod]
        public void IsEven_Test()
        {
            int arg = 9;
            bool expected = false;

            var cut = new Zajecia();
            bool actual = cut.IsEven(arg);
            Assert.AreEqual<bool>(expected, actual);
            

        }
        [TestMethod]
        public void IsEven_Test_0()
        {
            int arg = 0;
            bool expected = true;

            var cut = new Zajecia();
            bool actual = cut.IsEven(arg);
            Assert.AreEqual<bool>(expected, actual);

        }

        [DataRow("dom", "mod")] //
        [DataRow("dodo", "odod")] //
        [DataRow("moje auto", "otua ejom")] //
        [DataRow("akakakakaka", "akakakakaka")] //

        [DataTestMethod]
        public void ReverseString_Test(string arg, string expected)
        {
            Zajecia cut = new Zajecia();
            string actual = cut.ReverseString(arg);
            Assert.AreEqual<string>(expected, actual);
        }
        [TestMethod]
        public void ReverseStringEmpty_Test()
        {
            string s = "";
            string expected = "";
 

            var cut = new Zajecia();
            string actual = cut.ReverseString(s);
            Assert.AreEqual<string>(expected, actual);
        }
        [TestMethod]
        public void ReverseStringNull_Test()
        {
            string s = null;
            string expected = null;
            var cut = new Zajecia();


            try
            {
                string actual = cut.ReverseString(s);
                Assert.AreEqual<string>(expected, actual);
            }
            catch(ArgumentNullException)
            {
                return;
            }
        }
        [TestMethod]
        public void ReverseStringNumbers_Test()
        {
            string s = "hej123";
            string expected = "321jeh";
            var cut = new Zajecia();


            try
            {
                string actual = cut.ReverseString(s);
                Assert.AreEqual<string>(expected, actual);
            }
            catch (ArgumentNullException)
            {
                return;
            }
        }

        [TestMethod]
        public void GetSumSucces_Test()
        {

            int[] x = { 1, 1, 1, 1 };
            int expected = 1;
            

            var cut = new Zajecia();
            int actual = cut.GetSum(x);
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void GetSumFail_Test()
        {
            
            int[] x = { 1, 2, 3, 4 };
            int expected = 10;
            

            var cut = new Zajecia();
            int actual = cut.GetSum(x);
            Assert.AreEqual<int>(expected, actual);
        }


    }
}
