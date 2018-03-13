/* ComputerPlayer.cs
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
    /// A class for computer player
    /// </summary>
    class ComputerPlayer
    {
        /// <summary>
        /// The value of each cell that would complete a win in the computation of heuristic 1 (100).
        /// </summary>
        private const int _heuristicMultiplier = 100;

        /// <summary>
        /// The value of a win (1000000).
        /// </summary>
        private const int _winValue = 1000000;

        /// <summary>
        /// The identifier of the computer player.
        /// </summary>
        private int _playerId;

        /// <summary>
        /// The difficulty level.
        /// </summary>
        private int _level;

        /// <summary>
        /// The Board representing the current game.
        /// </summary>
        private Board _board = new Board();

        /// <summary>
        /// A public constructor
        /// </summary>
        /// <param name="playerId">given player id</param>
        /// <param name="level">given level</param>
        /// <param name="board">given board</param>
        public ComputerPlayer(int playerId, int level, Board board)
        {
            _playerId = playerId;
            _level = level;
            _board = board;
        }

        /// <summary>
        /// A private method to compute the evaluation function
        /// </summary>
        /// <param name="player">given player</param>
        /// <returns>an int giving the value of the evaluation function. </returns>
        private int ComputeEvaluationFunction(int player)
        {
            /*int value = 0;
            int column = Board.Columns;
            int unoccupiedRow = _board.ColumnCount(column) + 1;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < unoccupiedRow; j++)
                {
                    value += _board.Score(player) + _heuristicMultiplier;
                }
            }
            return value;*/

            int value = _board.Score(player);
            for (int i = 0; i < Board.Columns; i++)
            {
                int limit = _board.ColumnCount(i);
                if (i > 0)
                {
                    limit = Math.Max(limit, _board.ColumnCount(i - 1));
                }
                if(i < Board.Columns - 1)
                {
                    limit = Math.Max(limit, _board.ColumnCount(i + 1));
                }
                limit = Math.Min(limit + 1, Board.Rows);
                for (int j = _board.ColumnCount(i); j <= limit; j++)
                {
                    if (_board.IsPotentialWin(i, j, player))
                    {
                        value += _heuristicMultiplier;
                    }
                    else if (_board.IsPotentialWin(i, j, -player))
                    {
                        value -= _heuristicMultiplier;
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// A private method to evaluate the current board position using the negamax algorithm
        /// </summary>
        /// <param name="player">An int giving the player whose turn it is.</param>
        /// <param name="depth">An int giving the depth to search.</param>
        /// <param name="column">An out int through which the column of the best play will be returned.</param>
        /// <returns>an int giving the value of the current configuration represented by the Board field, from the given player's perspective. </returns>
        private int EvaluateCurrentPosition(int player, int depth, out int column)
        {
            int max = Int32.MinValue;
            column = 0;
            for (int i = 0; i < Board.Columns; i++)
            {
                int value;
                if (_board.ColumnCount(i) < Board.Rows)
                {
                    _board.Play(i);
                    if (_board.LastPlayWins)
                    {
                        column = i;
                        _board.Undo();
                        return _winValue;
                    }
                    else if(_board.IsDrawn)
                    {
                        column = i;
                        _board.Undo();
                        return 0;
                    }
                    else if (depth == 1)
                    {
                        value = -ComputeEvaluationFunction(-player);

                    }
                    else
                    {
                        value = -EvaluateCurrentPosition(-player, depth - 1, out column);
                    }
                    if (value > max)
                    {
                        max = value;
                        column = i;
                    }

                    _board.Undo();
                }
            }
            return max;
        }

        /// <summary>
        /// A public method to make a play
        /// </summary>
        /// <returns>the column on which the play is made.</returns>
        public int MakePlay()
        {
            int column;
            EvaluateCurrentPosition(_playerId, _level, out column);
            _board.Play(column);
            return column;
        }
    }
}
