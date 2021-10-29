using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    // Expected exception of all game methods
    public class GameException : ApplicationException
    {
        public GameException(string message)
            : base(message)
        {
        }
    }

    public class Game
    {
        public string[,] _board = new string[,] 
        { 
                { "", "", "" }, 
                { "", "", "" }, 
                { "", "", "" } 
        };

        private bool IsGameOver
        {
            get { return IsRowAlignment() || IsColumnAlignment() || IsDiagonalAlignment(); }
        }

        private bool IsRowAlignment()
        {
            bool result = false;
            for (int i = 0; i < 3; i++)
            {
                string m = this._board[0, i];
                if ((m != String.Empty) && (this._board[1, i] == m) && (this._board[2, i] == m))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private bool IsColumnAlignment()
        {
            bool result = false;
            for (int i = 0; i < 3; i++)
            {
                string m = this._board[i, 0];
                if ((m != String.Empty) && (this._board[i, 1] == m) && (this._board[i, 2] == m))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private bool IsDiagonalAlignment()
        {
            string m = this._board[0, 0];
            if ((m != String.Empty) && (this._board[1, 1] == m) && (this._board[2, 2] == m))
                return true;

            string n = this._board[2, 0];
            if ((n != String.Empty) && (this._board[1, 1] == n) && (this._board[0, 2] == n))
                return true;

            return false;
        }

        private void ValidateRange(int row, int col)
        {
            if ((row < 0) || (row > 2))
                throw new GameException("Row out of range");

            if ((col < 0) || (col > 2))
                throw new GameException("Column out of range");
        }

        private void PlaceMarkAtPosition(string mark, int row, int col)
        {
            ValidateRange(row, col);

            if (this._board[row, col] != String.Empty)
                throw new GameException("Position " + row + ", " + col + " is not empty");

            this._board[row, col] = mark;
        }

        public void PlaceXMarkAtPosition(int row, int col)
        {
           PlaceMarkAtPosition("X", row, col);
        }

        public void PlaceOMarkAtPosition(int row, int col)
        {
            this.PlaceMarkAtPosition("O", row, col);
        }

        public bool IsXMarkAtPosition(int row, int col)
        {
            ValidateRange(row, col);

            return this._board[row, col] == "X";
        }

        public bool IsOMarkAtPosition(int row, int col)
        {
            ValidateRange(row, col);

            return this._board[row, col] == "O";
        }
    }
}
