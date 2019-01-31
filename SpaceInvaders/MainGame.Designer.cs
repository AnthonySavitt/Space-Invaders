namespace SpaceInvaders
{



    partial class MainGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.roundBoard = new System.Windows.Forms.Label();
            this.Scoreboard = new System.Windows.Forms.Label();
            this.enemy12 = new System.Windows.Forms.PictureBox();
            this.enemy6 = new System.Windows.Forms.PictureBox();
            this.enemy5 = new System.Windows.Forms.PictureBox();
            this.enemy11 = new System.Windows.Forms.PictureBox();
            this.enemy10 = new System.Windows.Forms.PictureBox();
            this.enemy4 = new System.Windows.Forms.PictureBox();
            this.enemy9 = new System.Windows.Forms.PictureBox();
            this.enemy3 = new System.Windows.Forms.PictureBox();
            this.enemy2 = new System.Windows.Forms.PictureBox();
            this.enemy8 = new System.Windows.Forms.PictureBox();
            this.enemy7 = new System.Windows.Forms.PictureBox();
            this.enemy1 = new System.Windows.Forms.PictureBox();
            this.Tank = new System.Windows.Forms.PictureBox();
            this.LifeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.enemy12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tank)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // roundBoard
            // 
            this.roundBoard.AutoSize = true;
            this.roundBoard.BackColor = System.Drawing.Color.Transparent;
            this.roundBoard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roundBoard.Location = new System.Drawing.Point(1178, 20);
            this.roundBoard.Name = "roundBoard";
            this.roundBoard.Size = new System.Drawing.Size(74, 20);
            this.roundBoard.TabIndex = 2;
            this.roundBoard.Text = "Round: 1";
            // 
            // Scoreboard
            // 
            this.Scoreboard.AutoSize = true;
            this.Scoreboard.BackColor = System.Drawing.Color.Transparent;
            this.Scoreboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Scoreboard.Location = new System.Drawing.Point(1179, 56);
            this.Scoreboard.Name = "Scoreboard";
            this.Scoreboard.Size = new System.Drawing.Size(68, 20);
            this.Scoreboard.TabIndex = 3;
            this.Scoreboard.Text = "Score: 0";
            // 
            // enemy12
            // 
            this.enemy12.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy12.Location = new System.Drawing.Point(682, 139);
            this.enemy12.Name = "enemy12";
            this.enemy12.Size = new System.Drawing.Size(100, 100);
            this.enemy12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy12.TabIndex = 1;
            this.enemy12.TabStop = false;
            this.enemy12.Tag = "invader";
            // 
            // enemy6
            // 
            this.enemy6.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy6.Location = new System.Drawing.Point(682, 0);
            this.enemy6.Name = "enemy6";
            this.enemy6.Size = new System.Drawing.Size(100, 100);
            this.enemy6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy6.TabIndex = 1;
            this.enemy6.TabStop = false;
            this.enemy6.Tag = "invader";
            // 
            // enemy5
            // 
            this.enemy5.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy5.Location = new System.Drawing.Point(549, 0);
            this.enemy5.Name = "enemy5";
            this.enemy5.Size = new System.Drawing.Size(100, 100);
            this.enemy5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy5.TabIndex = 1;
            this.enemy5.TabStop = false;
            this.enemy5.Tag = "invader";
            // 
            // enemy11
            // 
            this.enemy11.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy11.Location = new System.Drawing.Point(549, 139);
            this.enemy11.Name = "enemy11";
            this.enemy11.Size = new System.Drawing.Size(100, 100);
            this.enemy11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy11.TabIndex = 1;
            this.enemy11.TabStop = false;
            this.enemy11.Tag = "invader";
            // 
            // enemy10
            // 
            this.enemy10.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy10.Location = new System.Drawing.Point(416, 139);
            this.enemy10.Name = "enemy10";
            this.enemy10.Size = new System.Drawing.Size(100, 100);
            this.enemy10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy10.TabIndex = 1;
            this.enemy10.TabStop = false;
            this.enemy10.Tag = "invader";
            // 
            // enemy4
            // 
            this.enemy4.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy4.Location = new System.Drawing.Point(416, 0);
            this.enemy4.Name = "enemy4";
            this.enemy4.Size = new System.Drawing.Size(100, 100);
            this.enemy4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy4.TabIndex = 1;
            this.enemy4.TabStop = false;
            this.enemy4.Tag = "invader";
            // 
            // enemy9
            // 
            this.enemy9.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy9.Location = new System.Drawing.Point(278, 139);
            this.enemy9.Name = "enemy9";
            this.enemy9.Size = new System.Drawing.Size(100, 100);
            this.enemy9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy9.TabIndex = 1;
            this.enemy9.TabStop = false;
            this.enemy9.Tag = "invader";
            // 
            // enemy3
            // 
            this.enemy3.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy3.Location = new System.Drawing.Point(278, 0);
            this.enemy3.Name = "enemy3";
            this.enemy3.Size = new System.Drawing.Size(100, 100);
            this.enemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy3.TabIndex = 1;
            this.enemy3.TabStop = false;
            this.enemy3.Tag = "invader";
            // 
            // enemy2
            // 
            this.enemy2.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy2.Location = new System.Drawing.Point(139, 0);
            this.enemy2.Name = "enemy2";
            this.enemy2.Size = new System.Drawing.Size(100, 100);
            this.enemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy2.TabIndex = 1;
            this.enemy2.TabStop = false;
            this.enemy2.Tag = "invader";
            // 
            // enemy8
            // 
            this.enemy8.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy8.Location = new System.Drawing.Point(139, 139);
            this.enemy8.Name = "enemy8";
            this.enemy8.Size = new System.Drawing.Size(100, 100);
            this.enemy8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy8.TabIndex = 1;
            this.enemy8.TabStop = false;
            this.enemy8.Tag = "invader";
            // 
            // enemy7
            // 
            this.enemy7.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy7.Location = new System.Drawing.Point(1, 139);
            this.enemy7.Name = "enemy7";
            this.enemy7.Size = new System.Drawing.Size(100, 100);
            this.enemy7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy7.TabIndex = 1;
            this.enemy7.TabStop = false;
            this.enemy7.Tag = "invader";
            // 
            // enemy1
            // 
            this.enemy1.Image = global::SpaceInvaders.Properties.Resources.enemy;
            this.enemy1.Location = new System.Drawing.Point(1, 0);
            this.enemy1.Name = "enemy1";
            this.enemy1.Size = new System.Drawing.Size(100, 100);
            this.enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemy1.TabIndex = 1;
            this.enemy1.TabStop = false;
            this.enemy1.Tag = "invader";
            // 
            // Tank
            // 
            this.Tank.Image = global::SpaceInvaders.Properties.Resources.player;
            this.Tank.Location = new System.Drawing.Point(589, 679);
            this.Tank.Name = "Tank";
            this.Tank.Size = new System.Drawing.Size(87, 64);
            this.Tank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Tank.TabIndex = 0;
            this.Tank.TabStop = false;
            // 
            // LifeLabel
            // 
            this.LifeLabel.AutoSize = true;
            this.LifeLabel.BackColor = System.Drawing.Color.Transparent;
            this.LifeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LifeLabel.Location = new System.Drawing.Point(5, 766);
            this.LifeLabel.Name = "LifeLabel";
            this.LifeLabel.Size = new System.Drawing.Size(49, 20);
            this.LifeLabel.TabIndex = 3;
            this.LifeLabel.Text = "Lives:";
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1295, 795);
            this.Controls.Add(this.LifeLabel);
            this.Controls.Add(this.Scoreboard);
            this.Controls.Add(this.roundBoard);
            this.Controls.Add(this.enemy12);
            this.Controls.Add(this.enemy6);
            this.Controls.Add(this.enemy5);
            this.Controls.Add(this.enemy11);
            this.Controls.Add(this.enemy10);
            this.Controls.Add(this.enemy4);
            this.Controls.Add(this.enemy9);
            this.Controls.Add(this.enemy3);
            this.Controls.Add(this.enemy2);
            this.Controls.Add(this.enemy8);
            this.Controls.Add(this.enemy7);
            this.Controls.Add(this.enemy1);
            this.Controls.Add(this.Tank);
            this.MaximumSize = new System.Drawing.Size(1317, 851);
            this.MinimumSize = new System.Drawing.Size(1317, 851);
            this.Name = "MainGame";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainGame_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.enemy12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Tank;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox enemy1;
        private System.Windows.Forms.PictureBox enemy2;
        private System.Windows.Forms.PictureBox enemy3;
        private System.Windows.Forms.PictureBox enemy4;
        private System.Windows.Forms.PictureBox enemy5;
        private System.Windows.Forms.PictureBox enemy6;
        private System.Windows.Forms.PictureBox enemy7;
        private System.Windows.Forms.PictureBox enemy8;
        private System.Windows.Forms.PictureBox enemy9;
        private System.Windows.Forms.PictureBox enemy10;
        private System.Windows.Forms.PictureBox enemy11;
        private System.Windows.Forms.PictureBox enemy12;
        private System.Windows.Forms.Label roundBoard; //it is bad to mess with this? Ask. Probably is...
        private System.Windows.Forms.Label Scoreboard;
        private System.Windows.Forms.Label LifeLabel;
    }
}

