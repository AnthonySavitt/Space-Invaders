using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Anthony Savitt
/// 818054985
/// 12/10/17
/// Space Invaders Game. MenuScreen Form Class 
/// </summary>
namespace SpaceInvaders
{
    public partial class MenuScreen : Form
    {
        
        public MenuScreen()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch; //Stretchedo out the background image
        }

        /// <summary>
        /// Creates new instance of MainGame and starts it after this button is clicked. Hides the menu
        /// </summary>
        private void NewGame_Click(object sender, EventArgs e) 
        {
            MainGame game = new MainGame();
            game.Show();
            this.Hide();
            
        }

        /// <summary>
        /// Enables GodMode. Starts game as normal but sets GOdMode bool as true  to change the game for this option.
        /// </summary>
        private void GodMode_Click(object sender, EventArgs e)
        {
            MainGame game = new MainGame();
            MainGame.GodMode = true;
            game.Show();
            this.Hide();
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        private void QuitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Calls static method from GameFunctions to display message box with the highest score of the current game ssince game's opening
        /// </summary>
        private void DisplayHighSCore_Click(object sender, EventArgs e)
        {
            GameFunctions.HighestScore();
        }
    }
}
