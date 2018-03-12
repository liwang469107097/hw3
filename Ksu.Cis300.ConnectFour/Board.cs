/* Board.cs
 * Author: Li Wang
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.ConnectFour
{
    /// <summary>
    /// a class for  represent a board configuration, along with the value of heuristic 2 for this configuration from the perspective of the first player.
    /// </summary>
    class Board
    {
        /// <summary>
        /// The value used for the first player (1).
        /// </summary>
        public const int FirstPlayer = 1;

        /// <summary>
        /// The number of rows on the board (6).
        /// </summary>
        public const int Rows = 6;

        /// <summary>
        /// The number of columns on the board (7).
        /// </summary>
        public const int Columns = 7;

        /// <summary>
        /// the number of cells on the board.
        /// </summary>
        private const int _numberOfCells = Rows * Columns;

        /// <summary>
        /// store the pieces played on the board.
        /// </summary>
        private List<int>[] _cells = new List<int>[Columns];

        /// <summary>
        /// record the player whose turn it is to play.
        /// </summary>
        private int _currentPlayer;

        /// <summary>
        /// store the history of plays 
        /// </summary>
        private Stack<int> _history = new Stack<int>();

        /// <summary>
        /// keep track of the heuristic 2 score from the perspective of the first player.
        /// </summary>
        private int _score;

        /// <summary>
        /// storing the value used by heuristic 2 for each cell. 
        /// </summary>
        private int[,] _cellValues =
        {
            {3, 4, 5, 7, 5, 4, 3},
            {4, 6, 8, 10, 8, 6, 4},
            {5, 8, 11, 13, 11, 8, 5},
            {5, 8, 11, 13, 11, 8, 5},
            {4, 6, 8, 10, 8, 6, 4},
            {3, 4, 5, 7, 5, 4, 3}
        };

        /// <summary>
        /// A public property to get whether the board is full
        /// </summary>
        public bool IsDrawn
        {
            get
            {
                if (_history.Count == _cells.Length)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// A public constructor
        /// </summary>
        public Board()
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = new List<int>();
            }
        }

        /// <summary>
        /// A public method to make a play
        /// </summary>
        /// <param name="column">the column of the play. </param>
        public void Play(int column)
        {
            _score += _cellValues[_cells[column].Count, column] * _currentPlayer;
            _history.Push(column);
            _cells[column].Add(_currentPlayer);
            _currentPlayer = -_currentPlayer;
        }

        /// <summary>
        /// A public method to undo a play
        /// </summary>
        public void Undo()
        {
            int column = _history.Pop();
            _currentPlayer = -_currentPlayer;
            _cells[column].RemoveAt(_currentPlayer);
            _score -= _cellValues[_cells[column].Count, column] * _currentPlayer;
        }

        /// <summary>
        /// A public method to get the heuristic 2 score
        /// </summary>
        /// <param name="player"> a player (i.e., either 1 or -1),</param>
        /// <returns>the heuristic 2 score from that player's perspective.</returns>
        public int Score(int player)
        {
            return _score * player;
        }

        /// <summary>
        /// A public method to get the number of pieces on a column
        /// </summary>
        /// <param name="coulumn">a column,</param>
        /// <returns>the number of pieces on that column.</returns>
        public int ColumnCount(int column)
        {
            return _cells[column].Count;
        }

        //need to fix
        /// <summary>
        /// A private method to determine the length of a path of pieces in a given direction
        /// </summary>
        /// <param name="row">An int giving a row.</param>
        /// <param name="column">An int giving a column.</param>
        /// <param name="vIncrement">An int giving a vertical increment, either -1, 0, or 1.</param>
        /// <param name="hIncrement">An int giving a horizontal increment, either -1, 0, or 1.</param>
        /// <param name="player">An int giving a player, either -1 or 1.</param>
        /// <returns>the number of consecutive pieces in the given direction from the given row and column belong to the given player. </returns>
        private int PathLength(int row, int column, int vIncrement, int hIncrement, int player)
        {
            int num = 0;
            while (row >= 0 && row < Rows && column >= 0 && column < Columns)
            {
                if(_cells[column][row] != 0 && _currentPlayer == player)
                {
                    num++;
                }
                else
                {
                    break;
                }
                row += vIncrement;
                column += hIncrement;
            }
            return num;
        }

        /// <summary>
        /// A public method to determine whether a piece on a given cell would complete a win
        /// </summary>
        /// <param name="row">given row</param>
        /// <param name="column">given column</param>
        /// <param name="player">given player</param>
        /// <returns> a bool indicating whether a piece belonging to the given player would complete four in a row if played on the given cell. </returns>
        public bool IsPotentialWin(int row, int column, int player)
        {
            if (PathLength(row, column, -1, -1, player) == 4)
            {
                return true;
            }
            else if (PathLength(row, column, -1, 1, player) == 4)
            {
                return true;
            }
            else if (PathLength(row, column, 0, 1, player) == 4)
            {
                return true;
            }
            return PathLength(row, column, 1, 0, player) == 4;
        }

        /// <summary>
        /// A public property to get whether the last play completed 4 in a row
        /// </summary>
        public bool LastPlayWins
        {
            get
            {
                int column = _history.Peek();
                if (_currentPlayer == FirstPlayer)
                {
                    return IsPotentialWin(ColumnCount(column) - 1, column, -1);
                }
                return IsPotentialWin(ColumnCount(column) - 1, column, FirstPlayer);
            }
        }
    }
}
