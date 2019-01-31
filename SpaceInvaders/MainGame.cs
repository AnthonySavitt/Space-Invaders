using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics;
using WMPLib; //used for background music of the game 

/// <summary>
/// Anthony Savitt
/// 818054985
/// 12/10/17
/// Space Invaders Game. Main Windows Form class
/// </summary>
/// <summary>
/// The following serves as my 'main' of the game. Containing my Timer that runs everything at I believe 20ms.
/// The timer has several functions that make sure the player can move, shoot, enemey detection, and everything eles inbetween.
/// There are variables declared here as public static <type> in order to be easily accesible by other classes.
/// 
/// This form contains the timer, the key functions, as well as one bullet detection function in order to account for ground collision.
/// </summary>
namespace SpaceInvaders
{
    public partial class MainGame : Form
    {

        WindowsMediaPlayer player = new WindowsMediaPlayer(); //created to play the main theme song of the game 
        public static bool moveRight; //is turned true or false whether or not 'right' arrow key is pushed
        public static bool moveLeft; //is turned true or false whether or not the 'left' arrow key is upshed 

        private bool GameDone = false; 
        /* Variable above used in attempt to stop a 'glitch' where after a death from the enemies getting too low
         * game will succesfully quit back to menu but open up several menus. I believe it has to do with the timer recognizing the 
         * collision of the enemies and groudn as multiple collisions because it checks so fast. This variable didn't realy help but
         * I kept it cause I thought it might and don't see why it would hinder it. 
         * */

        public static int enemyspeed = 10; //Sets how fasts the enemies move. Is incremented each round for difficiulty increase
        public static int enemyBSpeed = 10; //Sets how fasts the enemy bullets move. Is incremented each round for difficiulty increase
        public static int shotPercentage = 700; //Controls how frequenty the enemies shoot.  Is decremented each round for difficiulty increase.
        //The above is elaborated more in the Enemy.bulletcreation() 



        public static int enemydeaths=0; //Tracks enemy deaths and is ultimately used to end rounds 

        public static int round = 1; //For the round counter 
        public static int score = 0; //For the score counter 

        public static int lifeCounter = 2; //Players life counter. 

        public static bool[] flags = new bool[12]; //These are flags for enemy deaths 
        public static bool[] exploded = new bool[12]; //These are flags for enemy explosions. Elaborated more in __


        public static bool GodMode = false; //For default game is false, turned true when indicated on menu. Does what it says. 

        Player stud; //Creatd to access functions of Player class
        Enemy foe; //Created to access functions of Enemy class 
        GameFunctions mechanisms; //Created to access functions of the GameFunctions class
        public static PictureBox[] enemies = new PictureBox[12]; //Array of enemies as pictureboxes
        public static PictureBox[] lives = new PictureBox[2]; //Array of Player Lives displayed on bottom left of screen
        public static System.Drawing.Point[] enemyLocation = new System.Drawing.Point[12]; //Used to reset enemy locations each round/game.

        //Figured out how to delay shots combining ideas from these two sources:
        //https://stackoverflow.com/questions/9706803/c-sharp-elapsed-time-on-a-timer Figured out Stopwatch existed
        //https://answers.unity.com/questions/665352/shot-delay-between-button-press-c.html Liked this example and applied it to the Stopwatch


        public long timeBetweenShots = 500; //Allow 2 shot per second. Represented in milliseconds
        public long timeBetweenGod = 2000; //Prevents spammable 'shots' for GodMode that may cause Game Crashes..


        private long timestamp; //Measures how much total time has elapsed in order to track the delay between player shots

        Stopwatch stopWatch = new Stopwatch(); //Used to track the time the actual amount of time that has passed after I start() and stop() it
        public MainGame()
        {
           
            InitializeComponent();
            player.URL = "MainTheme.mp3"; //accesses the Windows Media Player object above and gets maintheme.mp3 from bin/debug
            player.controls.play(); //plays the song. *Note, Not sure how to get the song to loop/end when the game ends due to late implementation

            //Initializes all the class instances above. The reason they take in the same things is in order for them to called within the other classes.
            //I'm sure better ways to implement but this how it ended up working out for me. Hope it's okay 
            stud = new Player(Tank, this, timer1, Scoreboard, roundBoard, score); 
            foe = new Enemy(Tank, this, timer1, Scoreboard, roundBoard, score);
            mechanisms = new GameFunctions(Tank, this, timer1, Scoreboard, roundBoard, score);

            EnemyArray(); //Creates enemy array in order to be controlled for movement,shots, collision, etc.
            LivesArray(); //Created array of 'lives' shown at bottom of screen.
            CreateGround(); //Creates the green ground

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            stud.Movement(); //Controls movement of the Player 

            stud.bulletMovement(); //Controls movement of the player's bullets


          
            foe.bulletCreation(); //Creates the enemies bullets
            foe.bulletMovement();  //Controls the enemies bullet movement


            //Enemy and Bullet Collision. //Citing Mooict.com for solution to my collision glitch

            foe.Collision();  //Controls the collison of the enemies on bullets and the player
            mechanisms.bulletcollision(); //Controlls the collision of the bullets on bullet collision

            
            if(enemydeaths==12) //Used to get to the new round. If enemy deaths is equal to 12, goes to the next round. THere are 12 enemies
            {
               // removeBullets();
                mechanisms.newRound(); //calls the newRound() function in GameFunctions class
            }

            foe.Movement(); //Controls enemy movement
           

            
            stud.Collision(); //Controls the player colision with enemy bullets 

           GroundCollision(); //Wanted it to be a working feature of Collision within 'Enemy' but could not get it to work for some reason.
            //Ended up implementing it here. Hope this is okay even though might be better suited elsewhere. Controlls the collision of bullets
            //and enemies on the ground 

        }


        
         /// <summary>
         /// Function for having certain keys down for movement and shooting.From my citing above I found the 
         /// 'async' and 'await' combination.I use it pretty frequently throughout my code to have pauses between 
         /// different parts of the game.Found it incredibly useful.
         /// 
         /// THis function sets moveLeft and moveRight to true and also accounts for GodMode to change how the 
         /// spacebar works in that mode. 
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private async void MainGame_KeyDown(object sender, KeyEventArgs e)
        {
            stopWatch.Start();
            long duration = stopWatch.ElapsedMilliseconds;
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            //For player shooting in default mode of the game. 
            //If duration is >= the timestamp calculated below, it will allow. This prevents player being able to spam spacebar to shoot fast
            if (GodMode == false && duration >= timestamp && e.KeyCode == Keys.Space) 
            {
               
                stud.bulletCreation(); //Creates Bullet
                timestamp = duration + timeBetweenShots; //Adds the duration of how long the stopwatch has been runnig to variable set above
                stopWatch.Stop(); 

            }
            else if(GodMode == true && duration >= timestamp && e.KeyCode == Keys.Space) //Changes spacebar instead of shooting, to kill all enemies on screen
            {
                timestamp = duration + timeBetweenGod; //functions the same as above but is a slightly larger gap to prevent spams that will break the game
                stopWatch.Stop();
                //following will be condenesd to one line after flags are made into arrays. Just doing for testing purposes...
                //Sets all the flags of each enemy death to true, as they will all be killed by this spacebar press. These values are normally
                //set in the Enemy class when they die from regular enemy bullets .
                flags[0] = true;
                flags[1] = true;
                flags[2] = true;
                flags[3] = true;
                flags[4] = true;
                flags[5] = true;
                flags[6] = true;
                flags[7] = true;
                flags[8] = true;
                flags[9] = true;
                flags[10] = true;
                flags[11] = true;
                score += 110; //Scoreboard adds +10 under normal circumstances so 110 is to account for 11 enemies, and the other 10 in the function
                mechanisms.ScoreBoard(); //Calls Scoreboard method to update scoreboard 
                for (int i =0; i<enemies.Length; i++)
                {
                    this.Controls.Remove(enemies[i]); //Removes each of the enemies on the screen and produces an explosion
                    foe.Explosion();

                }
                await Task.Delay(1000); //1 second pause before starting the newRound function
                mechanisms.newRound();


            }
            


        }

        //Up key presses to prevent any issues with left and right movement
        private void MainGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            
            
        }
      
        /// <summary>
        /// Creates enemy array and get the locations of each of the enemies in orer to reproduce their locations for every round
        /// </summary>
        private void EnemyArray()
        {
            enemies[0] = enemy1;
            enemies[1] = enemy2;
            enemies[2] = enemy3;
            enemies[3] = enemy4;
            enemies[4] = enemy5;
            enemies[5] = enemy6;
            enemies[6] = enemy7;
            enemies[7] = enemy8;
            enemies[8] = enemy9;
            enemies[9] = enemy10;
            enemies[10] = enemy11;
            enemies[11] = enemy12;
            for(int i=0; i<12; i++)
            {
                enemyLocation[i] = enemies[i].Location;
            }
        }

        /// <summary>
        /// Controls the pictures of the 2 tanks in the bottom left of the screen that represent player lives.
        /// Creates a picturebox for each, and places them in their appropriate position and adds them to thes creen. 
        /// </summary>
        public void LivesArray()
        {
            PictureBox Life1 = new PictureBox();
            Life1.Image = Properties.Resources.player;
            Life1.Size = new Size(20, 20);
            Life1.Left = 40;
            Life1.Top = Tank.Top+53;
            Life1.Tag = "life";
            Life1.SizeMode= PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Life1);

            PictureBox Life2 = new PictureBox();
            Life2.Image = Properties.Resources.player;
            Life2.Size = new Size(20, 20);
            Life2.Left = 70;
            Life2.Top = Tank.Top + 53;
            Life2.Tag = "life";
            Life2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Life2);

            lives[0] = Life1;
            lives[1] = Life2;


        }

        /// <summary>
        /// Creates the Ground using a picturebox. Width is set to match whatever screen length is. 
        /// </summary>
        public void CreateGround()
        {
            PictureBox ground = new PictureBox();
            ground.Image = Properties.Resources.Ground;
            ground.Width = this.Width;
            ground.Height = 5;
            ground.Tag = "ground";
            ground.SizeMode = PictureBoxSizeMode.StretchImage;
            ground.Top = Tank.Top + 45;
            this.Controls.Add(ground);
        }


        /// <summary>
        /// This function probably should be in GameFunctions but I originaly had trouble implementing it where i wanted
        /// for some reason I discuss more in depth in my log. Ultimatelly decided to put it here and it works so I don't want to
        /// potentially break it. 
        /// 
        /// Creates explosions for when the bullets hit the ground and not the player. Also controls collision for the enemies and 
        /// and ground. If enemies touch the ground, player loses the game. This prevents player avoiding their fire after a certain side
        /// has been removed.
        /// </summary>
        public async void GroundCollision()
        {
            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "enemybullet")
                    {
                        if (j is PictureBox && j.Tag == "ground")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                this.Controls.Remove(i);

                                PictureBox myexplosion = new PictureBox();
                                myexplosion.Image = Properties.Resources.myexplosion;
                                myexplosion.Location = i.Location;
                                myexplosion.Size = new Size(20, 20);
                                myexplosion.SizeMode = PictureBoxSizeMode.StretchImage;
                                this.Controls.Add(myexplosion);
                                myexplosion.Visible = true;

                                await Task.Delay(150);

                                myexplosion.Visible = false;
                                this.Controls.Remove(myexplosion);
                            }
                        }
                    }
                }
            }
            if(GameDone == false) //Was used in attempt to prevent the creation of multiple menus after game over. doesn't work, but it does
                                    //at least control the collision to end the game. Wish i knew why it wouldn't work though
            {
                foreach (Control i in this.Controls)
                {
                    foreach (Control j in this.Controls)
                    {
                        if (i is PictureBox && i.Tag == "invader")
                        {
                            if (j is PictureBox && j.Tag == "ground")
                            {
                                if (i.Bounds.IntersectsWith(j.Bounds))
                                {
                                    GameDone = true;
                                    mechanisms.gameOver();
                                }
                            }
                        }
                    }
                }
            }
            

        }

    }
}
