using System;
using CUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
    [TestClass]
    public class GameTest

    {





        // tutaj umieścić rozwiązanie dla zadania 6. (Kółko i Krzyżyk)
        [DataRow("O", "O", "O", "", "", "", "", "", "", false)]
        [DataRow("O", "", "", "O", "", "", "O", "", "", true)]
        [DataRow("", "", "", "", "", "", "", "", "", false)]
        [DataRow("", "O", "", "", "O", "", "", "O", "", true)]
        [DataTestMethod]
        public void IsRowAlignment_Test(string a, string b, string c, string d, string e, string f, string g, string h, string i, bool expected)
        {
            // arrange



            Game game = new Game();
            game._board = new string[,]
                {
                { a, b, c },
                { d, e, f },
                { g, h, i }
            };

            PrivateObject po = new PrivateObject(game);

            // act
            bool actual = (bool)po.Invoke("IsRowAlignment");

            // assert
            Assert.AreEqual(expected, actual);
        }
        [DataRow("O", "O", "O", "", "", "", "", "", "", true)]
        [DataRow("O", "", "", "O", "", "", "O", "", "", false)]
        [DataRow("", "", "", "", "", "", "", "", "", false)]
        [DataRow("", "O", "", "", "O", "", "", "O", "", false)]
        [DataRow("", "", "", "O", "O", "O", "", "", "", true)]
        [DataRow(4, "", "", "O", "O", "O", "", "", "", false)]
        [DataTestMethod]
        public void IsColumnAlignment(string a, string b, string c, string d, string e, string f, string g, string h, string i, bool expected)
        {
            // arrange



            Game game = new Game();
            game._board = new string[,]
                {
                { a, b, c },
                { d, e, f },
                { g, h, i }
            };

            PrivateObject po = new PrivateObject(game);

            // act
            bool actual = (bool)po.Invoke("IsColumnAlignment");

            // assert
            Assert.AreEqual(expected, actual);
        }
        [DataRow("O", "", "", "", "O", "", "", "", "O", true)]
        [DataRow("O", "", "", "O", "", "", "O", "", "", false)]
        [DataRow("", "", "", "", "", "", "", "", "", false)]
        [DataRow("", "O", "", "", "O", "", "", "O", "", false)]
        [DataRow("", "", "", "O", "O", "O", "", "", "", false)]
        [DataRow("", "", "O", "", "O", "", "O", "", "", true)]
        [DataTestMethod]
        public void IsDiagonalAlignment(string a, string b, string c, string d, string e, string f, string g, string h, string i, bool expected)
        {
            // arrange



            Game game = new Game();
            game._board = new string[,]
                {
                { a, b, c },
                { d, e, f },
                { g, h, i }
            };

            PrivateObject po = new PrivateObject(game);

            // act
            bool actual = (bool)po.Invoke("IsDiagonalAlignment");

            // assert
            Assert.AreEqual(expected, actual);
        }


        [DataRow(0, 0)]
        [DataRow(2, 2)]
        [DataRow(1, 1)]
        [DataRow(2, 0)]
        [DataRow(0, 2)]
        [DataRow(-1, 0)]
        [DataRow(3, 0)]
        [DataRow(0, 0)]
        [DataRow("1", 0)]
        [DataTestMethod]
        public void ValidateRangeTest(int row, int col)
        {
            Game game = new Game();
            PrivateObject po = new PrivateObject(game);

            try
            {
                po.Invoke("ValidateRange", row, col);
            }
            catch (Exception)
            {
                return;
            }
            

        }
        [DataRow("", "", "", "", "", "", "", "", "", "X", 0, 0)]
        [DataRow("", "", "", "", "", "", "", "", "", "X", 1, 0)]
        [DataRow("", "", "", "", "", "", "", "", "", "X", 3, 0)]
        [DataRow("X", "", "", "", "", "", "", "", "", "X", 0, 0)]
        [DataTestMethod]
        public void PlaceMarkAtPositionTest(string a, string b, string c, string d, string e, string f, string g, string h, string i, string mark, int row, int col)
        {
            Game game = new Game();
            game._board = new string[,]
    {
                { a, b, c },
                { d, e, f },
                { g, h, i }
                    };
            PrivateObject po = new PrivateObject(game);

            try
            {
                po.Invoke("PlaceMarkAtPosition", mark, row, col);
            }
            catch (Exception)
            {
                return;
            }


        }
    }
}


//// arrange


//bool expected = true;
//PrivateObject po = new PrivateObject(game);

//// act
//bool actual = (bool)po.Invoke("IsRowAlignment");

//// assert
//Assert.AreEqual(expected, actual);