using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

/// <summary>
/// Anthony Savitt
/// 818054985
/// 12/10/17
/// Space Invaders Game. Enemy Class 
/// </summary>
namespace SpaceInvaders
{
    /// <summary>
    /// Child of abstract Sprite class. 
    /// </summary>
    public class Enemy : Sprite
    {
        WindowsMediaPlayer enemysound = new WindowsMediaPlayer();
        new Form maingame;
        PictureBox _tank;
        System.Windows.Forms.Timer newTimer;
        Label scoreboard;
        Label roundboard;
        int newScore;
        //bool GameDone = false;
        GameFunctions mechanisms;


        /// <summary>
        /// Takes in a large majority of these in order to create an instance of GameFunctions called mechanisms, which is called
        /// numerous times throughout this and the Player class 
        /// </summary>
        public Enemy(PictureBox Tank, Form maingame, System.Windows.Forms.Timer timer1, Label scoreboard, Label roundboard, int score) : base(Tank, maingame, timer1, scoreboard)
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
        /// Controls Enemy Movement of going left to right and then down. 
        /// </summary>
        public override void Movement()
        {
            for (int i = 0; i < 12; i++) //Allows for the left and right movement. 
            {
                MainGame.enemies[i].Left += MainGame.enemyspeed; //change enemyspeed and adjust on a per round basis

            }
            //invader on the right hits the the wall of the form, changes enemyspeed to negative sign to switch direciton and has enemies move down a little bit
            //Got the idea for the negative sign and the development of this movement system from a youtube series I found on building 
            //a space invaders game. 
            //https://www.youtube.com/watch?v=SsI2GVO1Hxs&t=12s
            if (MainGame.enemies[5].Left > maingame.Width - MainGame.enemies[5].Width - 18)
            {
                MainGame.enemyspeed *= -1;
                for (int i = 0; i < 12; i++)
                {
                    MainGame.enemies[i].Top += 10;
                }

            }
            //If the enemy on the left hits the left side of the form, switches difecion with an eegative sign and has enemies move down.
            if (MainGame.enemies[0].Left <= 0)
            {
                MainGame.enemyspeed *= -1;
                for (int i = 0; i < 12; i++)
                {
                    MainGame.enemies[i].Top += 10;
                }
            }
             
            
        }

        /// <summary>
        /// Simply shoots the enemy bullet forward towards the player. Was also supposed to implement the GroundCollision() function 
        /// found in the MainGame.cs but for some reason was not working here. HOnestly I have no idea why but I moved it to the main
        /// and it began working. Talked about it in the log more. 
        /// </summary>
        public override void bulletMovement()
        {
            foreach (Control b in maingame.Controls)
            {
                if (b is PictureBox && b.Tag == "enemybullet")
                {
                   b.Top += MainGame.enemyBSpeed;  

                }
                

            }
        }



        /// <summary>
        /// Creates the enemy bullets using a random number to be generated for each enemy. If the number is generated
        /// the assocaited enemy will create a bullet which is then managed by the above function to be moved forward.
        /// Took this idea from the youtube series referenced above. Not sure which video in that playlist but it is one of them.
        /// </summary>
        public override void bulletCreation()
        {
            
            Random rnd = new Random();
            if (MainGame.shotPercentage == 0) //Was used to account if round was over 7 in order to not have a confliction of shot
                                              //percentage smaller than 0. Will keep just cause game currently ends at 7 rounds...
            {

                MainGame.shotPercentage = 100;
            }
            int testShot = rnd.Next(1, MainGame.shotPercentage + 1); ///Gets a number between 1, and whateer testpercentage is 
            


            /*Each of the if's checks if testshot is equal to the generated number and if the flag for the enemy is false.
             * If conditions are met and number is generated the shot fires off.  Each if has the shotpercentage-1,2,3, etc.. in order
             * for each to have a different number to be generated. due to how fast the timer is running, this triggers relatively frequently
             * The decrease in number of shotPercentage increases frequency of the triggering of the bullet creation
             * Functions also plays the bullet sounds for the enemy using the Windows Media Player instance 'enemysound'
             * */
            if (testShot == MainGame.shotPercentage && MainGame.flags[0] == false) 
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[0].Left + MainGame.enemies[0].Width / 2; 
                bullet.Top = MainGame.enemies[0].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 1 && MainGame.flags[1] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[1].Left + MainGame.enemies[1].Width / 2;
                bullet.Top = MainGame.enemies[1].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 2 && MainGame.flags[2] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[2].Left + MainGame.enemies[2].Width / 2;
                bullet.Top = MainGame.enemies[2].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 3 && MainGame.flags[3] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[3].Left + MainGame.enemies[3].Width / 2;
                bullet.Top = MainGame.enemies[3].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 4 && MainGame.flags[4] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[4].Left + MainGame.enemies[4].Width / 2;
                bullet.Top = MainGame.enemies[4].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 5 && MainGame.flags[5] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[5].Left + MainGame.enemies[5].Width / 2;
                bullet.Top = MainGame.enemies[5].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 6 && MainGame.flags[6] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[6].Left + MainGame.enemies[6].Width / 2;
                bullet.Top = MainGame.enemies[6].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 7 && MainGame.flags[7] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[7].Left + MainGame.enemies[7].Width / 2;
                bullet.Top = MainGame.enemies[7].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 8 && MainGame.flags[8] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[8].Left + MainGame.enemies[8].Width / 2;
                bullet.Top = MainGame.enemies[8].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 9 && MainGame.flags[9] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[9].Left + MainGame.enemies[9].Width / 2;
                bullet.Top = MainGame.enemies[9].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 10 && MainGame.flags[10] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[10].Left + MainGame.enemies[10].Width / 2;
                bullet.Top = MainGame.enemies[10].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            else if (testShot == MainGame.shotPercentage - 11 && MainGame.flags[11] == false)
            {
                PictureBox bullet = new PictureBox();
                bullet.Image = Properties.Resources.Bullet;
                bullet.Size = new Size(5, 20);
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                bullet.Tag = "enemybullet";
                bullet.Left = MainGame.enemies[11].Left + MainGame.enemies[11].Width / 2;
                bullet.Top = MainGame.enemies[11].Top + 20;
                maingame.Controls.Add(bullet);
                enemysound.URL = "enemyshoot.wav";
                enemysound.controls.play();
            }
            
        }

        /// <summary>
        /// Controls collision between enemy and the player bullet using foreach loops and tags. Also plays sound effects and calls
        /// explosion function from this class
        /// </summary>
        public override void Collision()
        {
            foreach (Control i in maingame.Controls)
            {
                foreach (Control j in maingame.Controls)
                {
                    if (i is PictureBox && i.Tag == "invader")
                    {
                        if (j is PictureBox && j.Tag == "bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds)) //if the pictureboxes with those tags intersect, removes them and plays the sound file
                            {
                               // mechanisms = new GameFunctions(_tank, maingame, newTimer, scoreboard, newScore);
                                enemysound.URL = "invaderkilled.wav";
                                enemysound.controls.play();
                                maingame.Controls.Remove(i);
                                maingame.Controls.Remove(j);


                                /*The following if's check which Picturebox was intersected. SEts its respective flag to true, increment enemydeath count, and calls
                                 * explosion function to show an explosion for their death. Also calls scoreboard to update it.
                                 * 
                                 * */
                                if (i is PictureBox && i == MainGame.enemies[0])
                                {
                                    MainGame.flags[0] = true;
                                    MainGame.enemydeaths++;
          
                                    Explosion();
                                
                                   mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[1])
                                {
                                    MainGame.flags[1] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                    
                                    
                                  
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[2])
                                {
                                    MainGame.flags[2] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                               
                                    
                                   
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[3])
                                {
                                    MainGame.flags[3] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                 
                                  
                                 
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[4])
                                {
                                    MainGame.flags[4] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                             
                                   
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[5])
                                {
                                    MainGame.flags[5] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                    
                                  
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[6])
                                {
                                    MainGame.flags[6] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                  
                                   
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[7])
                                {
                                    MainGame.flags[7] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                   
                                    
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[8])
                                {
                                    MainGame.flags[8] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                 
                                  
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[9])
                                {
                                    MainGame.flags[9] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                  
                                  
                                    
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[10])
                                {
                                    MainGame.flags[10] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                 
                                   
                                    
                                    mechanisms.ScoreBoard();
                                }
                                if (i is PictureBox && i == MainGame.enemies[11])
                                {
                                    MainGame.flags[11] = true;
                                    Explosion();
                                    MainGame.enemydeaths++;
                                  
                                    
                                    
                                    mechanisms.ScoreBoard();
                                }
                                
                               


                            }
                        }
                    }
                }

            }
        }
        // https://stackoverflow.com/questions/23304173/how-to-make-a-picture-box-appear-after-5-seconds 
        //Above link is how I discovered the use of 'async' and 'await' in order to delay a task. 
        /// <summary>
        /// Creates explosion picturebox in place of enemy that was removed. Has it appear for 150ms and disapeers. 
        /// Checks both the flags created of flags and exploded in order to know which enemy to place the explosion at
        /// </summary>
        public override async void Explosion()
        {
          
            PictureBox explosion = new PictureBox();
            explosion.Image = Properties.Resources.Explosion;
            if (MainGame.flags[0] == true && MainGame.exploded[0] == false)
            {
                MainGame.exploded[0] = true;
                explosion.Location = MainGame.enemies[0].Location;
                explosion.Size = MainGame.enemies[0].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[1] == true && MainGame.exploded[1] == false)
            {
                MainGame.exploded[1] = true;
                explosion.Location = MainGame.enemies[1].Location;
                explosion.Size = MainGame.enemies[1].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[2] == true && MainGame.exploded[2] == false)
            {
                MainGame.exploded[2] = true;
                explosion.Location = MainGame.enemies[2].Location;
                explosion.Size = MainGame.enemies[2].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[3] == true && MainGame.exploded[3] == false)
            {
                MainGame.exploded[3] = true;
                explosion.Location = MainGame.enemies[3].Location;
                explosion.Size = MainGame.enemies[3].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[4] == true && MainGame.exploded[4] == false)
            {
                MainGame.exploded[4] = true;
                explosion.Location = MainGame.enemies[4].Location;
                explosion.Size = MainGame.enemies[4].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);
                

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[5] == true && MainGame.exploded[5] == false)
            {
                MainGame.exploded[5] = true;
                explosion.Location = MainGame.enemies[5].Location;
                explosion.Size = MainGame.enemies[5].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[6] == true && MainGame.exploded[6] == false)
            {
                MainGame.exploded[6] = true;
                explosion.Location = MainGame.enemies[6].Location;
                explosion.Size = MainGame.enemies[6].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[7] == true && MainGame.exploded[7] == false)
            {
                MainGame.exploded[7] = true;
                explosion.Location = MainGame.enemies[7].Location;
                explosion.Size = MainGame.enemies[7].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[8] == true && MainGame.exploded[8] == false)
            {
                MainGame.exploded[8] = true;
                explosion.Location = MainGame.enemies[8].Location;
                explosion.Size = MainGame.enemies[8].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);

            }
            if (MainGame.flags[9] == true && MainGame.exploded[9] == false)
            {
                MainGame.exploded[9] = true;
                explosion.Location = MainGame.enemies[9].Location;
                explosion.Size = MainGame.enemies[9].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[10] == true && MainGame.exploded[10] == false)
            {
                MainGame.exploded[10] = true;
                explosion.Location = MainGame.enemies[10].Location;
                explosion.Size = MainGame.enemies[10].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }
            if (MainGame.flags[11] == true && MainGame.exploded[11] == false)
            {
                MainGame.exploded[11] = true;
                explosion.Location = MainGame.enemies[11].Location;
                explosion.Size = MainGame.enemies[11].Size;
                explosion.SizeMode = PictureBoxSizeMode.StretchImage;
                maingame.Controls.Add(explosion);
                explosion.Visible = true;

                await Task.Delay(150);

                explosion.Visible = false;
                maingame.Controls.Remove(explosion);
            }


        }
    }
}
