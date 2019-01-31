namespace SpaceInvaders
{
    partial class MenuScreen
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
            this.NewGame = new System.Windows.Forms.Button();
            this.GodMode = new System.Windows.Forms.Button();
            this.QuitGame = new System.Windows.Forms.Button();
            this.DisplayHighSCore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.NewGame.Location = new System.Drawing.Point(363, 465);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(471, 73);
            this.NewGame.TabIndex = 0;
            this.NewGame.Text = "Start Game";
            this.NewGame.UseVisualStyleBackColor = true;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // GodMode
            // 
            this.GodMode.Location = new System.Drawing.Point(363, 552);
            this.GodMode.Name = "GodMode";
            this.GodMode.Size = new System.Drawing.Size(471, 73);
            this.GodMode.TabIndex = 1;
            this.GodMode.Text = "Start Game + \"God Mode\"";
            this.GodMode.UseVisualStyleBackColor = true;
            this.GodMode.Click += new System.EventHandler(this.GodMode_Click);
            // 
            // QuitGame
            // 
            this.QuitGame.Location = new System.Drawing.Point(363, 722);
            this.QuitGame.Name = "QuitGame";
            this.QuitGame.Size = new System.Drawing.Size(471, 74);
            this.QuitGame.TabIndex = 2;
            this.QuitGame.Text = "Quit Game";
            this.QuitGame.UseVisualStyleBackColor = true;
            this.QuitGame.Click += new System.EventHandler(this.QuitGame_Click);
            // 
            // DisplayHighSCore
            // 
            this.DisplayHighSCore.Location = new System.Drawing.Point(363, 640);
            this.DisplayHighSCore.Name = "DisplayHighSCore";
            this.DisplayHighSCore.Size = new System.Drawing.Size(471, 73);
            this.DisplayHighSCore.TabIndex = 3;
            this.DisplayHighSCore.Text = "High Score";
            this.DisplayHighSCore.UseVisualStyleBackColor = true;
            this.DisplayHighSCore.Click += new System.EventHandler(this.DisplayHighSCore_Click);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceInvaders.Properties.Resources.Title_Screen;
            this.ClientSize = new System.Drawing.Size(1178, 801);
            this.Controls.Add(this.DisplayHighSCore);
            this.Controls.Add(this.QuitGame);
            this.Controls.Add(this.GodMode);
            this.Controls.Add(this.NewGame);
            this.MaximumSize = new System.Drawing.Size(1200, 857);
            this.MinimumSize = new System.Drawing.Size(1200, 857);
            this.Name = "MenuScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button GodMode;
        private System.Windows.Forms.Button QuitGame;
        private System.Windows.Forms.Button DisplayHighSCore;
    }
}