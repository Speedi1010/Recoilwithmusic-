using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;
using System.IO;
namespace Recoil
{
    public partial class Form1 : Form
    {
        //noah's globals
        float playerYSpeed = 0f;
        float playerXSpeed = 0f;
        float maxPlayerSpeed = 10f;

        int shotgunAmmo = 2;
        int sniperAmmo = 1;
        int sniperAmmoMax = 1;
        int ammoCount = 0;
        int shotgunAmmoMax = 2;
        int bulletSpeed = 25;
        int enemyHealth = 10;
        int enemySize = 40;
        int enemySpeed = 3;
        int enemySpeedMax = 5;
        int enemyHit = -1;
        int count = 0;


        Rectangle enemyAim = new Rectangle(0, 0, 1, 1);

        List<Rectangle> enemies = new List<Rectangle>();
        List<SolidBrush> enemyBrushes = new List<SolidBrush>();

        List<int> enemyHealths = new List<int>();
        List<int> enemySizes = new List<int>();
        List<float> enemyXSpeeds = new List<float>();
        List<float> enemyYSpeeds = new List<float>();


        double spread;
        double xStep;
        double yStep;
        double deltaX;
        double deltaY;
        double angle;

        double enemyXStep;
        double enemyYStep;
        double enemyDeltaX;
        double enemyDeltaY;
        double enemyAngle;

        Random randGen = new Random();
        int randValue = 0;
        //

        //dylan's globals
        Rectangle aim = new Rectangle(0, 0, 5, 5);
        bool shotgunfire = false;
        bool minigunfire = false;
        bool pistolfire = false;
        bool rocketfire = false;
        bool sniperfire = false;
        Rectangle explode = new Rectangle(0, 0, 10, 10);
        Random randomSpread = new Random();
        Point endpoint;
        int damage;
        List<string> bulletproperties = new List<string>();
        List<int> blasttime = new List<int>();
        List<Rectangle> explosion = new List<Rectangle>();
        System.Windows.Media.MediaPlayer backgroundMusic = new System.Windows.Media.MediaPlayer();
        //

        //alistair's gllobals
        bool classicGen = false;
        bool mapCleared = false;
        bool enemiesLoaded = false;

        int enemyCount = 10;

        int wallWidth = 25;

        int enemyDimentions = 20;
        int spikeWidth = 10;
        int spikeHeight = 20;

        List<Rectangle> walls = new List<Rectangle>();
        List<Rectangle> spikes = new List<Rectangle>();
        List<Rectangle> gates = new List<Rectangle>();

        List<List<string>> Rows = new List<List<string>>();
        List<string> ActiveRow = new List<string>();

        int currentColumn = 0;
        int currentRow = 0;

        string prevMap = "hub";
        int sameInARow = 0;

        Random mapPick = new Random();
        string[] upMaps = new string[] { "hub", "vertHallway" };
        string[] downMaps = new string[] { "hub", "vertHallway" }; //LBracket1
        string[] rightMaps = new string[] { "hub", "horizHallway", "maze" };
        string[] leftMaps = new string[] { "hub", "horizHallway", "maze" }; //LBracket1
        //



        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        SolidBrush wallBrush = new SolidBrush(Color.Beige);
        SolidBrush enemyBrush = new SolidBrush(Color.Red);
        SolidBrush playerBrush = new SolidBrush(Color.Gold);
        SolidBrush bulletBrush = new SolidBrush(Color.Goldenrod);
        SolidBrush spikeBrush = new SolidBrush(Color.Goldenrod);
        SolidBrush gateBrush = new SolidBrush(Color.HotPink);


        Pen stock = new Pen(Color.BurlyWood, 6);

        List<Rectangle> bullets = new List<Rectangle>();
        List<double> bulletSpeedsY = new List<double>();
        List<double> bulletSpeedsX = new List<double>();

        Rectangle testEnemy = new Rectangle(200, 400, 40, 40);
        Rectangle player = new Rectangle(500, 800, 20, 20);


        //this is set to running by default for testing. Later on when we add a menu and make the
        //player press a button to start we'll change this
        string gameState = "waiting";

        public Form1()
        {
            InitializeComponent();
            backgroundMusic.Open(new Uri(Application.StartupPath + "/Resources/AUD_20240113_WA0011.wav"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.X = this.Width / 2;
            player.Y = this.Height / 2;
        }

        public void GameInitialize()
        {
            gameTimer.Enabled = true;
            backgroundMusic.Stop();

            backgroundMusic.Play();
            Musictimer.Enabled = true;

            mapCleared = false;
            enemiesLoaded = false;

            shotgunAmmo = 2;

            player.X = this.Width / 2;
            player.Y = this.Height / 2;

            currentColumn = 0;
            currentRow = 0;

            ActiveRow.Clear();
            Rows.Clear();
            ClearBullets();
            enemies.Clear();

            ActiveRow.Add("hub");
            Rows.Add(ActiveRow);

            gameState = "running";
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            moveBullets();
            //remember guys, just call your own functions here
            noahFunction();
            dylanFunction();
            alistairFunction();

            player.X += (int)playerXSpeed;
            player.Y += (int)playerYSpeed;

            randValue = randGen.Next(1, 401);


            //the following makes enemies move, I should put that in a method
            for (int i = 0; i < enemies.Count(); i++)
            {
                int x = (int)Math.Round(enemies[i].X + enemyXSpeeds[i], 0);
                int y = (int)Math.Round(enemies[i].Y + enemyYSpeeds[i], 0);

                //replace the rectangle in the list with updated one
                enemies[i] = new Rectangle(x, y, enemySizes[i], enemySizes[i]);
            }

            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "gameover")
                    {
                        GameInitialize();
                        classicGen = false;
                    }
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                //Dylan keys
                case Keys.D1:
                    pistolfire = true;
                    shotgunfire = false;
                    minigunfire = false;
                    rocketfire = false;
                    sniperfire = false;
                    break;
                case Keys.D2:
                    pistolfire = false;
                    shotgunfire = true;
                    minigunfire = false;
                    rocketfire = false;
                    sniperfire = false;
                    break;
                case Keys.D3:
                    pistolfire = false;
                    shotgunfire = false;
                    minigunfire = true;
                    rocketfire = false;
                    sniperfire = false;
                    break;
                case Keys.D4:
                    pistolfire = false;
                    shotgunfire = false;
                    minigunfire = false;
                    rocketfire = true;
                    sniperfire = false;
                    break;
                case Keys.D5:
                    pistolfire = false;
                    shotgunfire = false;
                    minigunfire = false;
                    rocketfire = false;
                    sniperfire = true;
                    break;

                //alistairs keys
                case Keys.Enter:
                    if (gameState == "waiting" || gameState == "gameover")
                    {
                        GameInitialize();
                        classicGen = true;
                    }
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            shootPistol();
            ShootShotgun();
            ShootSniper();
            RocketLauncher();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;
                titleLabel.Text = "RECOIL";
                subtitleLabel.Text = "There are four weapons, each on the respective number button:\n " +
                                     "1. Pistol 2. Shotgun 3. Minigun 4. Rocket launcher 5. Sniper";
            }
            else if (gameState == "gameover")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;
                titleLabel.Text = "GAME OVER";
                subtitleLabel.Text = "Press space / enter to play again.";
            }

            else if (gameState == "running")
            {
                titleLabel.Visible = false;
                subtitleLabel.Visible = false;
                subtitleLabel2.Visible = false;

                e.Graphics.FillEllipse(wallBrush, player);


                for (int i = 0; i < bullets.Count; i++)
                {
                    e.Graphics.FillEllipse(bulletBrush, bullets[i]);
                }


                //dylan's stuff
                endpoint.X = player.X + 10 + (int)(20 * Math.Cos(angle * Math.PI / 180.0));
                endpoint.Y = player.Y + 10 + (int)(20 * Math.Sin(angle * Math.PI / 180.0));

                e.Graphics.DrawLine(stock, player.X + 10, player.Y + 10, endpoint.X, endpoint.Y);

                for (int i = 0; i < explosion.Count; i++)
                {
                    e.Graphics.FillEllipse(bulletBrush, explosion[i]);
                }

                //

                //noah's stuff\
                //draw all the enemies
                for (int i = 0; i < enemies.Count(); i++)
                {
                    e.Graphics.FillEllipse(enemyBrushes[i], enemies[i]);
                }
                //

                //alistair's stuff
                for (int i = 0; i < walls.Count; i++)
                {
                    e.Graphics.FillRectangle(wallBrush, walls[i]);
                }

                for (int i = 0; i < spikes.Count; i++)
                {
                    e.Graphics.FillRectangle(spikeBrush, spikes[i]);
                }

                for (int i = 0; i < gates.Count; i++)
                {
                    e.Graphics.FillRectangle(gateBrush, gates[i]);
                }

                //


            }
        }

        //basefunctions here. Let's just not change these alright guys?
        public void BaseMovePlayer(bool leftButton, bool rightButton, bool upButton, bool downButton, ref Rectangle player, int playerSpeed)
        {

            if (upButton == true && player.Y > 0)
            {
                player.Y -= playerSpeed;
            }
            if (downButton == true)
            {
                player.Y += playerSpeed;
            }
            if (leftButton == true)
            {
                player.X -= playerSpeed;
            }
            if (rightButton == true)
            {
                player.X += playerSpeed;
            }
        }

        //this method makes bullets move and do their other things that they do
        public void moveBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                int x = (int)Math.Round(bullets[i].X + bulletSpeedsX[i], 0);
                int y = (int)Math.Round(bullets[i].Y + bulletSpeedsY[i], 0);
                bullets[i] = new Rectangle(x, y, 7, 7);

                //Put this next bit on bullet move
                if (player.X > explode.X && bulletproperties[i] == "explosion")
                {
                    if (bullets[i].X < explode.X)
                    {
                        dylanWasLazy(i);
                        break;
                    }
                }
                else if (player.X < explode.X && bulletproperties[i] == "explosion")
                {
                    if (bullets[i].X > explode.X)
                    {
                        dylanWasLazy(i);
                        break;
                    }
                }
                else if (player.Y < explode.Y && bulletproperties[i] == "explosion")
                {
                    if (bullets[i].Y > explode.Y)
                    {
                        dylanWasLazy(i);
                        break;
                    }
                }
                else if (player.Y > explode.Y && bulletproperties[i] == "explosion")
                {
                    if (bullets[i].Y < explode.Y)
                    {
                        dylanWasLazy(i);
                        break;
                    }
                }
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (bullets[i].IntersectsWith(enemies[j]))
                    {
                        if (bulletproperties[i] == "penetration")
                        {
                            enemyHealths[j] -= damage;
                            count = 0;
                            break;
                        }
                        else
                        {
                            bullets.RemoveAt(i);
                            bulletSpeedsX.RemoveAt(i);
                            bulletSpeedsY.RemoveAt(i);
                            bulletproperties.RemoveAt(i);
                            enemyHealths[j] -= damage;
                            count = 0;
                            enemyHit = j;
                            break;
                        }
                    }
                }

                bulletCollision(i);







            }

        }
        public void shootPistol()
        {
            if (pistolfire)
            {
                funMath();
                Rectangle newBullet = new Rectangle(endpoint.X, endpoint.Y, 5, 5);
                bullets.Add(newBullet);
                bulletSpeedsX.Add(xStep * bulletSpeed);
                bulletSpeedsY.Add(yStep * bulletSpeed);
                bulletproperties.Add("none");
                applyRecoil(22);
                damage = 2;

            }
        }
        //

        //individual functions begin here
        public void noahFunction()
        {
            advancedMovement(wDown, sDown, aDown, dDown, ref player, ref playerYSpeed, ref playerXSpeed, 1f, 1.20f, 0.90f);

            //these Labels tell the player all the information he needs
            testLabel.Text = $"Shotgun Ammo: {shotgunAmmo}";
            testLabel2.Text = $"";
            testLabel3.Text = $"Count = {ammoCount}";
            testLabel4.Text = $"Sniper Ammo: {sniperAmmo}";
            if (shotgunAmmo < shotgunAmmoMax || sniperAmmo < sniperAmmoMax)
            {
                ammoTimer.Enabled = true;
            }
            else ammoTimer.Enabled = false;
            //this for loop makes enemies flash when they get hit and end the game when the player
            //touches one
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemyHit >= 0)
                {
                    if (count < 10)
                    {
                        enemyBrushes[enemyHit] = new SolidBrush(Color.Pink);
                    }
                    else enemyBrushes[enemyHit] = new SolidBrush(Color.Red);
                }

                if (player.IntersectsWith(enemies[i]))
                {
                    gameState = "gameover";
                }

                for (int j = 0; j < explosion.Count; j++)
                {
                    if (explosion[j].IntersectsWith(enemies[i]))
                    {
                        removeEnemy(i);
                    }
                }
                //here we should add that if a player touches a spike the game is over

            }


            //is it time to make a new enemy?

            if (classicGen == false)
            {
                if (enemiesLoaded == false)
                {
                    for (int i = 0; i < enemyCount; i++)
                    {
                        createEnemy(2, 1, enemyBrush);
                        enemiesLoaded = true;
                    }
                }
            }

            else
            {
                if (randValue < 5)
                {
                    createEnemy(2, 1, enemyBrush);
                }
            }




            enemyAI();
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemyHealths[i] < 0)
                {
                    removeEnemy(i);
                }
            }

            if (enemies.Count == 0)
            {
                mapCleared = true;
            }
        }
        public void dylanFunction()
        {
            Explosion();
            funMath();
        }
        public void alistairFunction()
        {
            CheckCollisions();
            GenerateColumn();
            GenerateRow(GenerateColumn());
            GenerateMap();

        }
        //and end here




        //add completely new functions down here, please put them in your designated areas to avoid
        //confusion

        //Noah's area

        //this function is responsible for making the player move when any of the movement buttons are
        //pressed. His movement speed accelerates and deccelerates
        public void advancedMovement(bool upButton, bool downButton, bool leftButton, bool rightButton, ref Rectangle player, ref float YplayerSpeed, ref float XplayerSpeed, float startingSpeed, float playerAcceleration, float playerDecceleration)
        {
            if (playerYSpeed < maxPlayerSpeed && playerYSpeed > -maxPlayerSpeed)
            {
                if (upButton == true && player.Y > 0)
                {
                    if (YplayerSpeed > -startingSpeed)
                    {
                        YplayerSpeed = -startingSpeed;
                    }
                    YplayerSpeed = YplayerSpeed * playerAcceleration;
                }

                if (downButton == true && player.Y < this.Height - player.Height)
                {
                    if (YplayerSpeed < startingSpeed)
                    {
                        YplayerSpeed = startingSpeed;
                    }
                    YplayerSpeed = YplayerSpeed * playerAcceleration;
                }
            }

            if (playerXSpeed < maxPlayerSpeed && playerXSpeed > -maxPlayerSpeed)
            {
                if (leftButton == true)
                {
                    if (XplayerSpeed > -startingSpeed)
                    {
                        XplayerSpeed = -startingSpeed;
                    }
                    XplayerSpeed = XplayerSpeed * playerAcceleration;


                }

                if (rightButton == true && player.X < this.Width - player.Width)
                {
                    if (XplayerSpeed < startingSpeed)
                    {
                        XplayerSpeed = startingSpeed;
                    }
                    XplayerSpeed = XplayerSpeed * playerAcceleration;

                }
            }
            if ((!leftButton && !rightButton) || (XplayerSpeed > maxPlayerSpeed || XplayerSpeed < -maxPlayerSpeed))
            {
                if (XplayerSpeed > 0 || XplayerSpeed < 0)
                {
                    XplayerSpeed *= playerDecceleration;
                }
            }

            if ((!upButton && !downButton) || (YplayerSpeed > maxPlayerSpeed || YplayerSpeed < -maxPlayerSpeed))
            {
                if (YplayerSpeed > 0 || YplayerSpeed < 0)
                {
                    YplayerSpeed *= playerDecceleration;
                }
            }
        }
        //this function puts a definite limit on player speed, it's for testing purposes
        public void limitSpeed(ref float XplayerSpeed, ref float YplayerSpeed)
        {
            if (XplayerSpeed >= maxPlayerSpeed)
            {
                XplayerSpeed = maxPlayerSpeed;
            }
            if (XplayerSpeed <= -maxPlayerSpeed)
            {
                XplayerSpeed = -maxPlayerSpeed;
            }

            if (YplayerSpeed >= maxPlayerSpeed)
            {
                YplayerSpeed = maxPlayerSpeed;
            }
            if (YplayerSpeed <= -maxPlayerSpeed)
            {
                YplayerSpeed = -maxPlayerSpeed;
            }
        }
        //this method adds to the player "recoilStrength" to the player speed in the direction thats 
        //opposite to where the mouse is relative to the player
        public void applyRecoil(int recoilStrength)
        {


            funMath();
            //angle = angle * -1;
            playerXSpeed -= (float)xStep * recoilStrength;
            playerYSpeed -= (float)yStep * recoilStrength;
        }
        //this method does some math, calculating the angle between the player and the mouse
        public void funMath()
        {



            aim.X = MousePosition.X;
            aim.Y = MousePosition.Y;
            deltaX = aim.X - player.X;
            deltaY = aim.Y - player.Y;
            angle = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;

            xStep = Math.Cos(angle * Math.PI / 180);
            yStep = Math.Sin(angle * Math.PI / 180);
        }
        //this method does some math, calculating the angle between the enemy in question and the player
        public void funMathEnemy(int i)
        {

            enemyAim.X = player.X;
            enemyAim.Y = player.Y;
            enemyDeltaX = enemyAim.X - enemies[i].X;
            enemyDeltaY = enemyAim.Y - enemies[i].Y;
            enemyAngle = Math.Atan2(enemyDeltaY, enemyDeltaX) * 180 / Math.PI;

            //change angle to enemyAngle
            enemyXStep = Math.Cos(enemyAngle * Math.PI / 180);
            enemyYStep = Math.Sin(enemyAngle * Math.PI / 180);
        }
        //this method makes it so the player can't leave the screen
        public void limitPlayArea()
        {
            if (player.X > this.Width - player.Width)
            {
                player.X = this.Width - player.Width;
            }
            if (player.Y > this.Height - player.Height)
            {
                player.Y = this.Height - player.Height;
            }
            if (player.X < 0)
            {
                player.X = 0;
            }
            if (player.Y < 0)
            {
                player.Y = 0;
            }
        }

        //this tick method adds 1 to count everytime it's called
        private void countingTimer_Tick(object sender, EventArgs e)
        {
            count++;
        }
        //this method makes enemies move towards the player, utilizing the angle from funMathEnemy()
        private void enemyAI()
        {
            for (int i = 0; i < enemies.Count(); i++)
            {
                funMathEnemy(i);
                //if (enemyXSpeeds <  )

                enemyXSpeeds[i] = (float)enemyXStep * enemySpeed;
                enemyYSpeeds[i] = (float)enemyYStep * enemySpeed;
                //get the new position of y and x based on speed
            }
        }
        //this method creates an enemy using the given parameters when called
        public void createEnemy(int speedFactor, int SizeFactor, SolidBrush enemyColor)
        {
            y = randGen.Next(10, this.Height - player.Height - 20);
            x = 0;
            random = randGen.Next(1, 3);
            if (random == 1)
            {
                x = 0;
            }
            else
            {
                speedFactor = -speedFactor;
                x = this.Width;
            }

            newEnemy = new Rectangle(x, y, enemySize, enemySize);

            enemies.Add(newEnemy);
            enemyBrushes.Add(enemyColor);
            enemyXSpeeds.Add(enemySpeed * speedFactor);
            enemyYSpeeds.Add(enemySpeed * speedFactor);
            enemySizes.Add(enemySize * SizeFactor);
            enemyHealths.Add(enemyHealth);
        }
        //this method removes an enemy and all his attributes from their respective lists
        public void removeEnemy(int i)
        {
            enemies.RemoveAt(i);
            enemyXSpeeds.RemoveAt(i);
            enemyYSpeeds.RemoveAt(i);
            enemyHealths.RemoveAt(i);
            enemyBrushes.RemoveAt(i);
            enemySizes.RemoveAt(i);
            enemyHit = -1;
        }
        //this method makes bullets disappear and apply damage when they hit an enemy
        public void bulletCollision(int i)
        {
            try
            {
                for (int k = 0; k < walls.Count; k++)
                {
                    if (bullets[i].IntersectsWith(walls[k]))
                    {
                        bullets.RemoveAt(i);
                        bulletSpeedsX.RemoveAt(i);
                        bulletSpeedsY.RemoveAt(i);
                        bulletproperties.RemoveAt(i);
                        break;
                    }
                }

                for (int j = 0; j < enemies.Count; j++)
                {
                    if (bullets[i].IntersectsWith(enemies[j]))
                    {
                        if (bulletproperties[i] == "penetration")
                        {
                            enemyHealth -= damage;
                            count = 0;
                            break;
                        }
                        else
                        {
                            bullets.RemoveAt(i);
                            bulletSpeedsX.RemoveAt(i);
                            bulletSpeedsY.RemoveAt(i);
                            bulletproperties.RemoveAt(i);
                            enemyHealths[j] -= damage;
                            count = 0;
                            enemyHit = j;
                            break;
                        }
                    }
                }
            }

            catch
            {

            }

        }
        //the following method was created because Dylan repeated a lot of code and was too lazy to 
        //make a method for it
        public void dylanWasLazy(int i)
        {
            bullets[i] = new Rectangle(explode.X, explode.Y, 120, 120);
            explosion.Add(bullets[i]);
            blasttime.Add(10);
            bullets.RemoveAt(i);
            bulletSpeedsX.RemoveAt(i);
            bulletSpeedsY.RemoveAt(i);
            bulletproperties.RemoveAt(i);
        }



        int x, y, random;
        Rectangle newEnemy;
        //

        //Dylan's area
        private void minigunTimer_Tick(object sender, EventArgs e)
        {
            if (minigunfire == true)
            {
                Rectangle newBullet = new Rectangle(endpoint.X, endpoint.Y, 5, 5);
                bullets.Add(newBullet);
                bulletSpeedsX.Add(xStep * bulletSpeed);
                bulletSpeedsY.Add(yStep * bulletSpeed);
                bulletproperties.Add("none");
                applyRecoil(6);
                damage = 1;

            }
        }
        private void ammoTimer_Tick(object sender, EventArgs e)
        {
            shotgunAmmo++;
            ammoCount++;
            if (ammoCount % 2 == 0)
            {
                sniperAmmo++;
            }
            if (ammoCount == 100)
            {
                ammoCount = 0;
            }
        }
        private void ShootShotgun()
        {
            if (shotgunfire == true && shotgunAmmo != 0)
            {
                funMath();
                for (int i = 0; i < 8; i++)
                {
                    spread = randomSpread.Next(-10, 11);
                    angle = Math.Atan2(deltaY, deltaX) * 180 / Math.PI + spread;

                    xStep = Math.Cos(angle * Math.PI / 180);
                    yStep = Math.Sin(angle * Math.PI / 180);
                    Rectangle newBullet = new Rectangle(endpoint.X, endpoint.Y, 5, 5);
                    bullets.Add(newBullet);
                    bulletSpeedsX.Add(xStep * bulletSpeed);
                    bulletSpeedsY.Add(yStep * bulletSpeed);
                    bulletproperties.Add("none");
                    damage = 3;
                }
                applyRecoil(40);
                shotgunAmmo--;
            }
        }
        public void ShootSniper()
        {
            if (sniperfire == true && sniperAmmo != 0)
            {
                Rectangle newBullet = new Rectangle(endpoint.X, endpoint.Y, 5, 5);
                bullets.Add(newBullet);
                bulletSpeedsX.Add(xStep * bulletSpeed);
                bulletSpeedsY.Add(yStep * bulletSpeed);
                bulletproperties.Add("penetration");
                applyRecoil(100);
                damage = 20;
                sniperAmmo--;
            }
        }

        public void RocketLauncher()
        {
            if (rocketfire == true)
            {
                explode.X = aim.X;
                explode.Y = aim.Y;
                Rectangle newBullet = new Rectangle(endpoint.X, endpoint.Y, 15, 15);
                bullets.Add(newBullet);
                bulletSpeedsX.Add(xStep * bulletSpeed);
                bulletSpeedsY.Add(yStep * bulletSpeed);
                bulletproperties.Add("explosion");
                applyRecoil(48);
                damage = 5;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            minigunTimer.Enabled = true;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            minigunTimer.Enabled = false;
        }
        public void Explosion()
        {
            for (int i = 0; i < explosion.Count; i++)
            {
                blasttime[i]--;
                if (blasttime[i] == 0)
                {
                    explosion.RemoveAt(i);
                    blasttime.RemoveAt(i);
                }
            }
        }



        //

        //Alistair's area

        public void LoadHorizHallway()
        {
            ClearMap();

            if (mapCleared == false && classicGen == false)
            {
                gates.Add(new Rectangle(0, this.Height / 2 - 50, wallWidth, 150));
                gates.Add(new Rectangle(this.Width - wallWidth, this.Height / 2 - 50, wallWidth, 150));
            }

            walls.Add(new Rectangle(0, 0, wallWidth, this.Height / 2 - 50));
            walls.Add(new Rectangle(0, this.Height / 2 + 100, wallWidth, this.Height / 2 - 50));

            walls.Add(new Rectangle(this.Width - wallWidth, 0, wallWidth, this.Height / 2 - 50));
            walls.Add(new Rectangle(this.Width - wallWidth, this.Height / 2 + 100, wallWidth, this.Height / 2 - 50));

            walls.Add(new Rectangle(0, 0, this.Width, this.Height / 2 - 100));
            walls.Add(new Rectangle(0, this.Height / 2 + 150, this.Width, this.Height / 2 - 100));

            for (int i = 0; i < 32; i++)
            {
                spikes.Add(new Rectangle(wallWidth + (i + 1) * 50, this.Height / 2 - 100, spikeWidth, spikeHeight));
                spikes.Add(new Rectangle(wallWidth + (i + 1) * 50, this.Height / 2 + 150 - spikeHeight, spikeWidth, spikeHeight));
            }
        }

        public void LoadVertHallway()
        {
            ClearMap();

            walls.Add(new Rectangle(0, 0, this.Width / 2 - 100, wallWidth));
            walls.Add(new Rectangle(this.Width / 2 + 100, 0, this.Width / 2, wallWidth));

            walls.Add(new Rectangle(0, this.Height - wallWidth, this.Width / 2 - 100, wallWidth));
            walls.Add(new Rectangle(this.Width / 2 + 100, this.Height - wallWidth, this.Width / 2, wallWidth));

            walls.Add(new Rectangle(0, 0, this.Width / 2 - 150, this.Height));
            walls.Add(new Rectangle(this.Width / 2 + 150, 0, this.Height, this.Height));

            for (int i = 0; i < 17; i++)
            {
                spikes.Add(new Rectangle(walls[4].Width, wallWidth + (i + 1) * 50, spikeHeight, spikeWidth));
                spikes.Add(new Rectangle(walls[5].X - spikeHeight, wallWidth + (i + 1) * 50, spikeHeight, spikeWidth));
            }
        }

        public void LoadLBracket1()
        {
            ClearMap();

            walls.Add(new Rectangle(0, 0, this.Width / 2 - 100, wallWidth));
            walls.Add(new Rectangle(this.Width / 2 + 100, 0, this.Width / 2, wallWidth));

            walls.Add(new Rectangle(0, this.Height - wallWidth, this.Width / 2 - 100, wallWidth));
            walls.Add(new Rectangle(this.Width / 2 + 100, this.Height - wallWidth, this.Width / 2, wallWidth));

            walls.Add(new Rectangle(0, 0, this.Width / 2 - 150, this.Height));
            walls.Add(new Rectangle(0, 0, this.Width / 2 - 150, this.Height));

            walls.Add(new Rectangle(this.Width / 2 + 150, 0, this.Height, this.Height));
        }

        public void LoadMaze()
        {
            ClearMap();
            enemies.Clear();
            walls.Add(new Rectangle(0, 0, wallWidth, this.Height / 2 - 50));
            walls.Add(new Rectangle(0, this.Height / 2 + 100, wallWidth, this.Height / 2 - 50));

            walls.Add(new Rectangle(this.Width - wallWidth, 0, wallWidth, this.Height / 2 - 50));
            walls.Add(new Rectangle(this.Width - wallWidth, this.Height / 2 + 100, wallWidth, this.Height / 2 - 50));

            walls.Add(new Rectangle(0, 0, this.Width, wallWidth));
            walls.Add(new Rectangle(0, this.Height - wallWidth, this.Width, wallWidth));

            int wallY = 200;
            int count = 1;

            for (int i = 0; i < 7; i++)
            {
                count *= -1;
                wallY += 200 * count;

                walls.Add(new Rectangle((i + 1) * 200, wallY, wallWidth, this.Height - 200));
            }

            for (int i = 0; i < 7; i++)
            {
                spikes.Add(new Rectangle(walls[6].X + wallWidth, (i + 1) * 100 - 50, spikeHeight, spikeWidth));
                spikes.Add(new Rectangle(walls[8].X + wallWidth, (i + 1) * 100 - 50, spikeHeight, spikeWidth));
                spikes.Add(new Rectangle(walls[10].X + wallWidth, (i + 1) * 100 - 50, spikeHeight, spikeWidth));
                spikes.Add(new Rectangle(walls[12].X + wallWidth, (i + 1) * 100 - 50, spikeHeight, spikeWidth));

                spikes.Add(new Rectangle(walls[7].X + wallWidth, (i + 1) * 100 + 200, spikeHeight, spikeWidth));
                spikes.Add(new Rectangle(walls[9].X + wallWidth, (i + 1) * 100 + 200, spikeHeight, spikeWidth));
                spikes.Add(new Rectangle(walls[11].X + wallWidth, (i + 1) * 100 + 200, spikeHeight, spikeWidth));
            }
        }

        public void LoadHub()
        {
            ClearMap();

            if (classicGen == false)
            {
                walls.Add(new Rectangle(0, 0, this.Width, wallWidth));
                walls.Add(new Rectangle(0, this.Height - wallWidth, this.Width, wallWidth));
            }

            else
            {
                walls.Add(new Rectangle(0, 0, this.Width / 2 - 100, wallWidth));
                walls.Add(new Rectangle(this.Width / 2 + 100, 0, this.Width / 2 - 100, wallWidth));
                walls.Add(new Rectangle(0, this.Height - wallWidth, this.Width / 2 - 100, wallWidth));
                walls.Add(new Rectangle(this.Width / 2 + 100, this.Height - wallWidth, this.Width / 2 - 100, wallWidth));
            }

            if (mapCleared == false && classicGen == false)
            {
                gates.Add(new Rectangle(0, this.Height / 2 - 50, wallWidth, 150));
                gates.Add(new Rectangle(this.Width - wallWidth, this.Height / 2 - 50, wallWidth, 150));
            }

            walls.Add(new Rectangle(0, 0, wallWidth, this.Height / 2 - 50));
            walls.Add(new Rectangle(0, this.Height / 2 + 100, wallWidth, this.Height / 2 - 50));

            walls.Add(new Rectangle(this.Width - wallWidth, 0, wallWidth, this.Height / 2 - 50));
            walls.Add(new Rectangle(this.Width - wallWidth, this.Height / 2 + 100, wallWidth, this.Height / 2 - 50));
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].IntersectsWith(player) && playerXSpeed > 0)
                {
                    //player.X = walls[i].X - walls[i].Width;
                    playerXSpeed *= -1;
                }

                else if (walls[i].IntersectsWith(player) && playerXSpeed < 0)
                {
                    //player.X = walls[i].X + walls[i].Width;
                    playerXSpeed *= -1;
                }

                if (walls[i].IntersectsWith(player) && playerYSpeed > 0)
                {
                    //player.Y = walls[i].Y - walls[i].Width;
                    playerYSpeed *= -1;
                }

                else if (walls[i].IntersectsWith(player) && playerYSpeed < 0)
                {
                    //player.Y = walls[i].Y - walls[i].Width;
                    playerYSpeed *= -1;
                }

                if (player.Y < 0 - player.Width)
                {
                    player.Y = wallWidth + player.Width + 10;
                }

                if (player.Y > this.Height + player.Width)
                {
                    player.Y = this.Height - wallWidth - player.Width - 10;
                }
            }

            for (int i = 0; i < gates.Count; i++)
            {
                if (gates[i].IntersectsWith(player) && playerXSpeed > 0)
                {
                    //player.X = walls[i].X - walls[i].Width;
                    playerXSpeed *= -1;
                }

                if (gates[i].IntersectsWith(player) && playerXSpeed < 0)
                {
                    //player.X = walls[i].X + walls[i].Width;
                    playerXSpeed *= -1;
                }
            }
            for (int i = 0; i < spikes.Count; i++)
            {
                if (spikes[i].IntersectsWith(player))
                {
                    gameState = "gameover";
                }
            }
        }

        public List<string> GenerateColumn()
        {
            List<string> NewColumn = new List<string>();

            if (player.X > this.Width && currentColumn >= ActiveRow.Count() - 1)
            {
                player.X = 0 + 2 * wallWidth;
                currentColumn++;
                Rows[currentRow].Add(ChooseMap(false, false, true, false));
                ClearBullets();
            }

            else if (player.X > this.Width && currentColumn < ActiveRow.Count() - 1)
            {
                player.X = 0 + 2 * wallWidth;
                currentColumn++;
                ClearBullets();
            }

            else if (player.X < 0 && currentColumn == 0)
            {
                Rows[currentRow].Insert(0, ChooseMap(false, false, false, true));
                player.X = this.Width - 2 * wallWidth;
                ClearBullets();
            }

            else if (player.X < 0 && currentColumn > 0)
            {
                currentColumn--;
                player.X = this.Width - 2 * wallWidth;
                ClearBullets();
            }
            return NewColumn;
        }

        public void GenerateRow(List<string> column)
        {
            List<string> NewRow = new List<string>();


            if (player.Y < 0 && currentRow >= Rows.Count() - 1)
            {
                for (int i = 0; i < currentColumn + 1; i++)
                {
                    NewRow.Add(ChooseMap(true, false, false, false));
                }
                player.Y = this.Height - wallWidth;
                currentRow++;
                Rows.Add(NewRow);
                ClearBullets();
            }

            else if (player.Y < 0 && currentRow < Rows.Count() - 1)
            {
                player.Y = this.Height - wallWidth;
                currentRow++;
                ClearBullets();
            }

            else if (player.Y > this.Height && currentRow == 0)
            {
                for (int i = 0; i < currentColumn + 1; i++)
                {
                    NewRow.Add(ChooseMap(false, true, false, false));
                }
                Rows.Insert(0, NewRow);
                player.Y = 0 + wallWidth;
                ClearBullets();
            }

            else if (player.Y > this.Height && currentRow > 0)
            {
                currentRow--;
                player.Y = 0 + wallWidth;
                ClearBullets();
            }
        }

        public string ChooseMap(bool up, bool down, bool right, bool left)
        {
            for (int i = 0; i < enemies.Count(); i++)
            {
                removeEnemy(i);
            }

            mapCleared = false;
            enemiesLoaded = false;

            string map = "hub";
            int index = 0;

        retry:

            //select map
            if (right == true)
            {
                index = mapPick.Next(0, rightMaps.Count());
                map = rightMaps[index];
            }

            if (left == true)
            {
                index = mapPick.Next(0, leftMaps.Count());
                map = leftMaps[index];
            }

            else if (up == true)
            {
                index = mapPick.Next(0, upMaps.Count());
                map = upMaps[index];
            }

            else if (down == true)
            {
                index = mapPick.Next(0, downMaps.Count());
                map = downMaps[index];
            }

            //prevent the map from being the same too many times
            if (map == prevMap)
            {
                sameInARow++;
            }

            else
            {
                sameInARow = 0;
            }

            if (sameInARow >= 2)
            {
                goto retry;
            }

            prevMap = map;
            return map;
        }

        public void GenerateMap()
        {
            while (currentColumn >= Rows[currentRow].Count)
            {
                Rows[currentRow].Add(ChooseMap(false, false, true, false));
            }

            if (Rows[currentRow][currentColumn] == "horizHallway")
            {
                LoadHorizHallway();
            }

            else if (Rows[currentRow][currentColumn] == "maze")
            {
                LoadMaze();
            }

            else if (Rows[currentRow][currentColumn] == "hub")
            {
                LoadHub();
            }

            else if (Rows[currentRow][currentColumn] == "vertHallway")
            {
                LoadVertHallway();
            }

            else if (Rows[currentRow][currentColumn] == "lBracket1")
            {
                LoadLBracket1();
            }
        }

        private void Musictimer_Tick(object sender, EventArgs e)
        {
            backgroundMusic.Stop();
        }

        public void ClearMap()
        {
            walls.Clear();
            spikes.Clear();
            gates.Clear();
        }

        public void ClearBullets()
        {
            bullets.Clear();
            bulletSpeedsX.Clear();
            bulletSpeedsY.Clear();
        }

        //


    }
}



