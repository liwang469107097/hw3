/* UserInterface.cs
 * Author: Li Wang
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.ConnectFour
{
    /// <summary>
    /// A GUI for a program to play the connect 4
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A Board giving an internal represenation of the current board position.
        /// </summary>
        private Board _board = new Board();

        /// <summary>
        /// A ComputerPlayer representing the computer player.
        /// </summary>
        private ComputerPlayer _computerPlayer;

        /// <summary>
        /// A method to finish the game
        /// </summary>
        /// <param name="message">given message to show in the TextBox</param>
        private void FinishGame(string message)
        {
            uxColumn0.Enabled = false;
            uxColumn1.Enabled = false;
            uxColumn2.Enabled = false;
            uxColumn3.Enabled = false;
            uxColumn4.Enabled = false;
            uxColumn5.Enabled = false;
            uxColumn6.Enabled = false;
            uxStatus.Text = message;
        }

        /// <summary>
        /// A method to determine whether the game is over
        /// </summary>
        /// <param name="message">given message</param>
        /// <returns>a bool indicating whether the game is over.</returns>
        private bool GameIsOver(string message)
        {
            bool over = _board.LastPlayWins;
            if (over)
            {
                FinishGame(message);
            }
            return over;
        }
        /// <summary>
        /// A method to show a play on the form
        /// </summary>
        /// <param name="column">given column</param>
        /// <param name="symbol"> the symbol to add to the column</param>
        private void ShowPlay(int column, string symbol)
        {
            Label label = new Label();
            label.Text = symbol;
            label.AutoSize = true;
            int num = _board.ColumnCount(column);
            Button b = new Button();
            FlowLayoutPanel f = new FlowLayoutPanel();
            if (num >= 0 && num <= 6)
            {
                b.Enabled = true;
                f.Controls.Add(label);
            }
            else
            {
                b.Enabled = false;
            }
        }

        /// <summary>
        /// A method to make the computer's play
        /// </summary>
        private void MakeComputerPlay()
        {
            uxStatus.Text = "My move.";
            Update();
            ShowPlay(_computerPlayer.MakePlay(), uxStatus.Text);
        }

        /// <summary>
        /// An event handler for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            SetupDialog set = new SetupDialog();
            if (set.ShowDialog() == DialogResult.OK)
            {
                if (set.ComputerPlaysFirst)
                {
                    _computerPlayer = new ComputerPlayer(1, set.Level, _board);
                    set.Visible = true;
                    MakeComputerPlay();
                    uxStatus.Text = "Your move.";
                }
                else
                {
                    _computerPlayer = new ComputerPlayer(-1, set.Level, _board);
                }
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// An event handler for a button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxColumn0_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int column = Convert.ToInt32(b.Text);
            _board.Play(column);
            ShowPlay(column, "O");
            if (!GameIsOver(uxStatus.Text))
            {
                MakeComputerPlay();
                uxStatus.Text = "Your move.";
            }
            else
            {
                ShowPlay(column, "X");
                uxStatus.Text = "I move.";
            }
        }
    }
}
