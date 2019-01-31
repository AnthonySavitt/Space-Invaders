using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Anthony Savitt
/// 818054985
/// 12/10/17
/// Space Invaders Game. Abstract Sprite Class 
/// </summary>
namespace SpaceInvaders
{

    /// <summary>
    /// Abstract class that represents the Enemy and Player classes. Shares the functions
    /// Movement, bulletMOvement, bulletCreation, Collision, and Explosion. Each has their own definition. 
    /// 
    /// </summary>
    public abstract class Sprite
    {
        public Form maingame;
        PictureBox _tank;
        System.Windows.Forms.Timer newTimer;
        Label scoreboard;

        //Passes in player picturebox, the form itself, the timer, and scoreboard.
        public Sprite(PictureBox Tank, Form maingame, System.Windows.Forms.Timer timer1, Label scoreboard)
        {
            _tank = Tank;
            this.maingame = maingame;
            newTimer = timer1;
            this.scoreboard = scoreboard;
        }

        public abstract void Movement();
        public abstract void bulletMovement();
        public abstract void bulletCreation();
        public abstract void Collision();
        public abstract void Explosion();
    }
}
