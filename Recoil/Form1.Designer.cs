namespace Recoil
{
    partial class Form1
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.testLabel = new System.Windows.Forms.Label();
            this.minigunTimer = new System.Windows.Forms.Timer(this.components);
            this.ammoTimer = new System.Windows.Forms.Timer(this.components);
            this.testLabel2 = new System.Windows.Forms.Label();
            this.countingTimer = new System.Windows.Forms.Timer(this.components);
            this.testLabel3 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel2 = new System.Windows.Forms.Label();
            this.testLabel4 = new System.Windows.Forms.Label();
            this.playerHealthLabel = new System.Windows.Forms.Label();
            this.Musictimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tag = "20";
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testLabel.Location = new System.Drawing.Point(21, 7);
            this.testLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(80, 17);
            this.testLabel.TabIndex = 0;
            this.testLabel.Text = "Version 1.0";
            // 
            // minigunTimer
            // 
            this.minigunTimer.Tick += new System.EventHandler(this.minigunTimer_Tick);
            // 
            // ammoTimer
            // 
            this.ammoTimer.Interval = 2000;
            this.ammoTimer.Tick += new System.EventHandler(this.ammoTimer_Tick);
            // 
            // testLabel2
            // 
            this.testLabel2.AutoSize = true;
            this.testLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testLabel2.Location = new System.Drawing.Point(130, 7);
            this.testLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testLabel2.Name = "testLabel2";
            this.testLabel2.Size = new System.Drawing.Size(80, 17);
            this.testLabel2.TabIndex = 1;
            this.testLabel2.Text = "Version 1.0";
            // 
            // countingTimer
            // 
            this.countingTimer.Enabled = true;
            this.countingTimer.Interval = 1;
            this.countingTimer.Tick += new System.EventHandler(this.countingTimer_Tick);
            // 
            // testLabel3
            // 
            this.testLabel3.AutoSize = true;
            this.testLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testLabel3.Location = new System.Drawing.Point(228, 7);
            this.testLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testLabel3.Name = "testLabel3";
            this.testLabel3.Size = new System.Drawing.Size(80, 17);
            this.testLabel3.TabIndex = 2;
            this.testLabel3.Text = "Version 1.0";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.titleLabel.Location = new System.Drawing.Point(344, 328);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(402, 108);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "RECOIL";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.subtitleLabel.Location = new System.Drawing.Point(43, 68);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(763, 241);
            this.subtitleLabel.TabIndex = 4;
            this.subtitleLabel.Text = "Press space to start playing";
            // 
            // subtitleLabel2
            // 
            this.subtitleLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel2.ForeColor = System.Drawing.Color.Firebrick;
            this.subtitleLabel2.Location = new System.Drawing.Point(2, 327);
            this.subtitleLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subtitleLabel2.Name = "subtitleLabel2";
            this.subtitleLabel2.Size = new System.Drawing.Size(331, 123);
            this.subtitleLabel2.TabIndex = 6;
            this.subtitleLabel2.Text = "Press space to use functional map gen, press enter to use classic gen.";
            // 
            // testLabel4
            // 
            this.testLabel4.AutoSize = true;
            this.testLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testLabel4.Location = new System.Drawing.Point(335, 7);
            this.testLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.testLabel4.Name = "testLabel4";
            this.testLabel4.Size = new System.Drawing.Size(96, 17);
            this.testLabel4.TabIndex = 7;
            this.testLabel4.Text = "Sniper Ammo:";
            // 
            // playerHealthLabel
            // 
            this.playerHealthLabel.AutoSize = true;
            this.playerHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerHealthLabel.Location = new System.Drawing.Point(445, 7);
            this.playerHealthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playerHealthLabel.Name = "playerHealthLabel";
            this.playerHealthLabel.Size = new System.Drawing.Size(53, 17);
            this.playerHealthLabel.TabIndex = 8;
            this.playerHealthLabel.Text = "Health:";
            // 
            // Musictimer
            // 
            this.Musictimer.Tick += new System.EventHandler(this.Musictimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(600, 365);
            this.Controls.Add(this.playerHealthLabel);
            this.Controls.Add(this.testLabel4);
            this.Controls.Add(this.subtitleLabel2);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.testLabel3);
            this.Controls.Add(this.testLabel2);
            this.Controls.Add(this.testLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.Timer minigunTimer;
        private System.Windows.Forms.Timer ammoTimer;
        private System.Windows.Forms.Label testLabel2;
        private System.Windows.Forms.Timer countingTimer;
        private System.Windows.Forms.Label testLabel3;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label subtitleLabel2;
        private System.Windows.Forms.Label testLabel4;
        private System.Windows.Forms.Label playerHealthLabel;
        private System.Windows.Forms.Timer Musictimer;
    }
}

