/* SetupDialog.cs
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
    /// a class for forming set up dialog
    /// </summary>
    public partial class SetupDialog : Form
    {
        /// <summary>
        ///  Constructs the setup dialog
        /// </summary>
        public SetupDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A property that gets a bool indicating whether the user checked the "Computer plays first" radio button.
        /// </summary>
        public bool ComputerPlaysFirst
        {
            get
            {
                if (uxComputerFirst.Checked)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// A property that gets an int giving the level that the user chose.
        /// </summary>
        public int Level
        {
            get
            {
                return Convert.ToInt32(uxLevel.Value);
            }
        }

        /// <summary>
        /// no use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetupDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
