using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib; //used to create the WindowsMediaPlayer object


/// <summary>
/// Anthony Savitt
/// 818054985
/// 12/10/17
/// Space Invaders Game. Player Class 
/// </summary>
namespace SpaceInvaders
{
    /// <summary>
    /// Child of abstract SPrite class
    /// </summary>
    public class Player : Sprite 
    {
        WindowsMediaPlayer playersound = new WindowsMediaPlayer(); //Used to play the player sounds like the death and shots
        new Form maingame;
        PictureBox _tank;
        System.Windows.Forms.Timer newTimer;
        Label scoreboard;
        Label roundboard;
        int newScore;
        GameFunctions mechanisms;

        public Player(PictureBox Tank, Form maingame, System.Windows.Forms.Timer timer1, Label scoreboard, Label roundboard, int score) : base(Tank, maingame, timer1, scoreboard)
        {
            _tank = Tank;
            this.maingame = maingame;
            newTimer = timer1;
            this.scoreboard = scoreboard;
            this.roundboard = roundboard;
            newScore = score;
            mechanisms = new GameFunctions(_tank, maingame, newTimer, scoreboard, roundboard, newScore);
        }
        /// <summary>
        /// Controls the player movement using the moveLeft and moveRight bools set in the MainGame.cs keydown and keyup functions
        /// </summary>
        public override void Movement()
        {
            //Player Movement
            if ((MainGame.moveLeft == true) && _tank.Location.X > 0)
            {
                _tank.Left -= 10;
            }
            else if ((MainGame.moveRight == true) && (_tank.Location.X + _tank.Width < maingame.Width - 18)) //Prevents tank moving too far far. THe -18 is in order to not go too far. For some reason goes too far without it.
            {
                _tank.Left += 10;
            } 

        }


        /// <summary>
        /// Controls player bullet. Works the same as the enemy bullet but instead of going down, goes up towards the enemkes.
        /// removes the bullet if it goes past the height of the screen
        /// </summary>
        public override void bulletMovement()
        {
            
            foreach (Control x in maingame.Controls) //citing mooict.com for this Control x and control y concept
            {
                if (x is PictureBox && x.Tag == "bullet")
                {
                    x.Top -= 10;
                    if (((PictureBox)x).Top > maingame.Height)
                    {
                        maingame.Controls.Remove(x);
                    }
                }
            }
            
        }


        /// <summary>
        /// Creates player bullet. Is called from the keyDown spacebar function if GodMode is NOT activated. 
        /// </summary>
        public override void bulletCreation()
        {

              PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.mybullet;
            bullet.Size = new Size(5, 20);
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.Tag = "bullet";

            //tried this original but couldn't get it to work.
            //bullet.Location = pictureBox1.Location;

            bullet.Left = _tank.Left + _tank.Width/2; //Creates a bullet center of the tank 
            bullet.Top = _tank.Top - 20; //puts it right above the player tank 

            playersound.URL = "playershoot.wav"; //gets the playershooting.wav to have audible player shots
            playersound.controls.play(); //plays the sounds
            maingame.Controls.Add(bullet); //Add the bullet to the screen
        }

        /// <summary>
        /// Tests for collison of player and the invader ,and player and the invader bullets
        /// </summary>
        public override void Collision()
        {
            foreach (Control y in maingame.Controls)
            {
                if (y is PictureBox && y.Tag == "invader")
                {
                    //If player and tank intersect, ends the game entirely. 
                    if (((PictureBox)y).Bounds.IntersectsWith(_tank.Bounds))
                    {
                        //Player explodes and soudn is played. 
                        Explosion();
                        playersound.URL = "playerexplosion.wav";
                        playersound.controls.play();
                        if(MainGame.GodMode == false) //Implemented to prevent death if GodMode is on.
                        {
                            mechanisms.gameOver();
                        }
                       
                    }
                }
                
                if (y is PictureBox && y.Tag == "enemybullet") //if tag is a enemy bullet 
                {
                    if (((PictureBox)y).Bounds.IntersectsWith(_tank.Bounds)) //if enemybullet and tank intersect
                    {
                        
                        maingame.Controls.Remove(y); //removed the bullet 
                        playersound.URL = "playerexplosion.wav"; //explodes the player 
                        playersound.controls.play();
                        Explosion();
                        mechanisms.livesChecker(); //Manages the players lives with livesChecker() 
                       
                    }
                }
            }
        }

        /// <summary>
        /// Controls player explpsion
        /// </summary>
        public override async void Explosion()
        {
            //Does not create an explosion if player is in GodeMode because player will not die. Hence GodMode.
            if (MainGame.GodMode == false)
            {
                PictureBox explosion = new PictureBox();
                explosion.Image = Properties.Resources.Explosion;

                // MainGame.exploded1 = true;
                explosion.Location = _tank.Location;
                explosion.Size = _tank.Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Remove(_tank);
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);

            }
            else
            {

            }
            
        }
    }
}
