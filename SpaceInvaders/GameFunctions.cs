using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Drawing;

/// <summary>
/// Anthony Savitt
/// 818054985
/// 12/10/17
/// Space Invaders Game. GameFunctions Class 
/// </summary>
namespace SpaceInvaders
{
    public class GameFunctions
    {

        /// <summary>
        /// The following declared variables are used for the constructor to pass in necessary items from the MainGame.cs
        /// </summary>
        Form maingame; 
        PictureBox _tank;
        System.Windows.Forms.Timer newTimer;
        Label scoreboard;
        Label roundboard;
        int newScore;
        public static int HighScore=0;
        public static int FinalScore = 0;

        /// <summary>
        /// Passes in parts from the MainGame.cs in order to manipulate the necessary items from the form 
        /// </summary>
        public GameFunctions(PictureBox Tank, Form maingame, System.Windows.Forms.Timer timer1, Label scoreboard, Label roundboard, int score)
        {
            _tank = Tank;
            this.maingame = maingame;
            newTimer = timer1;
            this.scoreboard = scoreboard;
            this.roundboard = roundboard;
            newScore = score;

        }

        /// <summary>
        /// Ends the game and sets up the possiblity of another one 
        /// </summary>
        public async void gameOver()
        {
            FinalScore = MainGame.score;
            newTimer.Stop(); //Stops the Timer controlling everything 

            //Honestly I don't know why In need to set these to default because when the button the main menu is pushed 
            //I think it should create a new instance of the Form and not have any issues. But there are so I reset the necessary variables
            //to their initially values here to prevent any issues. 

            MainGame.score = 0; 
            MainGame.round = 1;
            MainGame.GodMode = false;
            MainGame.lifeCounter = 2;
            MainGame.enemyspeed = 10;
             MainGame.enemyBSpeed = 10;
             MainGame.shotPercentage = 700;

              MainGame.enemydeaths = 0;

            await Task.Delay(2000); //Gives a 2 second between timer stopping and and actually showing the Gmae Over Screen

            PictureBox Losing = new PictureBox(); //Creates a picurebox that displays 'Game Over' 
           Losing.Image = Properties.Resources.GameOver;
            Losing.Size = maingame.Size;
            Losing.SizeMode = PictureBoxSizeMode.StretchImage;
            maingame.Controls.Clear();
            maingame.Controls.Add(Losing);

            await Task.Delay(2000); //Shows Game Over for 2 seconds then hides it.

            maingame.Hide();
            MenuScreen backtoscreen = new MenuScreen(); //Creates a new instance of the main menu. Shows it. Repeat cycle. 
            backtoscreen.Show();
          
            

        }

        /// <summary>
        /// Let's player get hte coveted WinScreen and sets up the possibliy of another game after 
        /// </summary>
        public async void Win()
        {
            FinalScore = MainGame.score;
            newTimer.Stop();
            MainGame.score = 0;
            MainGame.round = 1;
            MainGame.GodMode = false;
            MainGame.lifeCounter = 2;
            MainGame.enemyspeed = 10;
            MainGame.enemyBSpeed = 10;
            MainGame.shotPercentage = 700;

            MainGame.enemydeaths = 0;

            await Task.Delay(2000);

            //Functions essentially the same as the 'gameOver()' but instead displays a picture of a 'YOu Win' instead! Wow! 
            PictureBox Winning = new PictureBox();
            Winning.Image = Properties.Resources.Win;
            Winning.Size = maingame.Size;
            Winning.SizeMode = PictureBoxSizeMode.StretchImage;
            maingame.Controls.Clear();
            maingame.Controls.Add(Winning);


            await Task.Delay(2000);
            maingame.Hide();
            MenuScreen backtoscreen = new MenuScreen();
            backtoscreen.Show();

        }
        
        public void ScoreBoard() //Updates the scoreboard and point count after every death
        {
            
                MainGame.score += 10;
                scoreboard.Text = "Score: " + MainGame.score;
            

        }
        public void RoundBoard() //Updates the rounds displayed
        {
            MainGame.round += 1;
            roundboard.Text = "Round: " + MainGame.round;
        }

        /// <summary>
        /// Sets up the new round by resetting enemies and attempting to make difficulty harder .
        /// </summary>
        public void newRound()
        {
         
            if (MainGame.round == 7) //Allows up to 7 rounds. Wins after 7th round is beaten.  
            {
                Win();//Calls the Win function. Ending the game and lets the player feel good about themselves 
            }

            

            Thread.Sleep(2000); //Pause between rounds 


          
            //Meant to increase the difficulty. Normally works but there is sometimes slow down instead. 
            //I asked Amack and he said it was not a me problem but rather visual studio problem. 
            //By round 7 the enemies should be incredibly fast and shooting extremely frequently 

            MainGame.shotPercentage -= 100; //Increase difficulty but increasing amount of shots fired
            MainGame.enemyspeed += 3; //Increase enemy speed
            MainGame.enemyBSpeed += 3; //Increase how fast their bullets are

          
            RoundBoard(); //Updates the Rounds 
            MainGame.enemydeaths = 0; //Resets the enemy death count
            for (int i = 0; i < MainGame.enemies.Length; i++) //Recreates the enemy placement from the original stored locations and resets flags
            {
                MainGame.enemies[i].Location = MainGame.enemyLocation[i];
                maingame.Controls.Add(MainGame.enemies[i]);
                MainGame.flags[i] = false;
                MainGame.exploded[i] = false;  

            }
              
        }

        /// <summary>
        /// Controls the bullet to bullet collision. Produces an explosion in air upon impact. 
        /// </summary>
        public async void bulletcollision() //Again uses the 'async' function in order to produces cool delays in the game.
        {
            foreach (Control i in maingame.Controls)
            {
                foreach (Control j in maingame.Controls)
                {
                    if (i is PictureBox && i.Tag == "enemybullet")
                    {
                        if (j is PictureBox && j.Tag == "bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                
                                PictureBox myexplosion = new PictureBox();
                                myexplosion.Image = Properties.Resources.myexplosion;
                                myexplosion.Location = i.Location;
                                myexplosion.Size = new Size(20, 20);
                                myexplosion.SizeMode = PictureBoxSizeMode.StretchImage;
                                maingame.Controls.Remove(i);
                                maingame.Controls.Remove(j);
                                maingame.Controls.Add(myexplosion);
                                myexplosion.Visible = true; ///Make explosion visible 

                                await Task.Delay(150); //Delay lets explosion show for a bit

                                myexplosion.Visible = false; //Makes it invisible and is then removed. 
                                maingame.Controls.Remove(myexplosion);

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Manages player life count. Removes the Tank picture on the bottom left. After lifecounter is 0, game is over. 
        /// </summary>
        public async void livesChecker()
        {
            if (MainGame.GodMode == false)
            {
                if (MainGame.lifeCounter == 2)
                {


                    maingame.Controls.Remove(MainGame.lives[1]);
                    await Task.Delay(1000); //Gives slight delay after the life representation is removed before adding in the new playable charcter model
                    maingame.Controls.Add(_tank);
                    MainGame.lifeCounter--;

                }
                else if (MainGame.lifeCounter == 1)
                {
                    maingame.Controls.Remove(MainGame.lives[0]);
                    await Task.Delay(1000);
                    maingame.Controls.Add(_tank);
                    //gameOver();
                    MainGame.lifeCounter--;
                }
                else if (MainGame.lifeCounter == 0)
                {
                    gameOver();
                }
            }
            else
            {

            }
          



        }
        /// <summary>
        /// Function that retrieves the HighestScore and displays it as a MessageBox on the main menu
        /// </summary>
        public static void HighestScore()
        {
            if(HighScore==0)
            {
                HighScore = FinalScore;
            }
            else if(HighScore < FinalScore)
            {
                HighScore = FinalScore;
            }
            else if (HighScore > FinalScore )
            {

            }
            string displayed = "High Score: " + HighScore;
            MessageBox.Show(displayed);
        }

    }
}
