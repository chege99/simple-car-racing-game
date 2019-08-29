using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Racing_Game
{
    public partial class Form1 : Form
    {
        int windowheight = 385;//Screen.GetBounds.windowheight;
        int sidelaneswidth = 8;
        int windowwidth = 308;
        int gamespeed = 3;
        int gamespeedupperlimit = 20;
        int gamespeedlowerlimit = 3;
        int enemyspeed = 3;
        int coinspoints = 0;
        Random R = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        void movelanes(int speed)
        {
            
            if (pictureBox_mlane1.Top > windowheight)
            {   pictureBox_mlane1.Top = 0;   }
            else
            {   pictureBox_mlane1.Top += speed; }

            if (pictureBox_mlane2.Top > windowheight)
            { pictureBox_mlane2.Top = 0; }
            else
            { pictureBox_mlane2.Top += speed; }

            if (pictureBox_mlane3.Top > windowheight)
            { pictureBox_mlane3.Top = 0; }
            else
            { pictureBox_mlane3.Top += speed; }

            if (pictureBox_mlane4.Top > windowheight)
            { pictureBox_mlane4.Top = 0; }
            else
            { pictureBox_mlane4.Top += speed; }

            if (pictureBox_mlane5.Top > windowheight)
            { pictureBox_mlane5.Top = 0; }
            else
            { pictureBox_mlane5.Top += speed; }
        }
        void CarCollideWithEnemy()
        {
            if (mycar.Bounds.IntersectsWith((pictureBox_enemy1.Bounds)))
            {
                gameover();
            }
            if (mycar.Bounds.IntersectsWith((pictureBox_enemy2.Bounds)))
            {
                gameover();
            }
            if (mycar.Bounds.IntersectsWith((pictureBox_enemy3.Bounds)))
            {
                gameover();
            }
            if (mycar.Bounds.IntersectsWith((pictureBox_enemy4.Bounds)))
            {
                gameover();
            }

        }
        void gameover()
        {
            LBL_gameover.Visible = true;
            timer1.Enabled = false;
        }
        int x;//position of enemy on x-axis
        void enemy(int speed)
        {
            //Enemy 1
            if (pictureBox_enemy1.Top > windowheight)
            {
                x = R.Next(sidelaneswidth, ((windowwidth) / 2));
                pictureBox_enemy1.Location = new Point(x, 0);
            }else
                pictureBox_enemy1.Top += speed;
            
            //Enemy 2
            if (pictureBox_enemy2.Top > windowheight)
            {
                x = R.Next(sidelaneswidth, ((windowwidth) / 2));
                pictureBox_enemy2.Location = new Point(x, 0);
            }else
                pictureBox_enemy2.Top += speed;

            //Enemy 3
            if (pictureBox_enemy3.Top > windowheight)
            {
                x = R.Next(sidelaneswidth+ ((windowwidth) / 2), windowwidth-(2*sidelaneswidth));
                pictureBox_enemy3.Location = new Point(x, 0);
            } else
                pictureBox_enemy3.Top += speed;

            //Enemy 4
            if (pictureBox_enemy4.Top > windowheight)
            {
                x = R.Next(sidelaneswidth + ((windowwidth) / 2), windowwidth - (2 * sidelaneswidth));
                pictureBox_enemy4.Location = new Point(x, 0);
            } else
                pictureBox_enemy4.Top += speed;

        }
        void coins(int speed)
        {
            //Coin 1
           if (pictureBox_coin1.Top > windowheight)
            {
                x = R.Next(sidelaneswidth, ((windowwidth) / 2));
                pictureBox_coin1.Location = new Point(x, 0);
            }
            else
                pictureBox_coin1.Top += speed;

            //Coin 2
            if (pictureBox_coin2.Top > windowheight)
            {
                x = R.Next(sidelaneswidth, ((windowwidth) / 2));
                pictureBox_coin2.Location = new Point(x, 0);
            }
            else
                pictureBox_coin2.Top += speed;

            //Coin 1
            if (pictureBox_coin3.Top > windowheight)
            {
                x = R.Next(sidelaneswidth, ((windowwidth) / 2));
                pictureBox_coin3.Location = new Point(x, 0);
            }
            else
                pictureBox_coin3.Top += speed;

            //Coin 4
            if (pictureBox_coin4.Top > windowheight)
            {
                x = R.Next(sidelaneswidth, ((windowwidth) / 2));
                pictureBox_coin4.Location = new Point(x, 0);
            }
            else
                pictureBox_coin4.Top += speed;
        }
        void collectcoins()
        {
            if (mycar.Bounds.IntersectsWith(pictureBox_coin1.Bounds))
            {
                coinspoints++;
                LBL_coins.Text = "COINS=" + coinspoints;
                pictureBox_coin1.Location = new Point(x, 0);
            }
            if (mycar.Bounds.IntersectsWith(pictureBox_coin2.Bounds))
            {
                coinspoints++;
                LBL_coins.Text = "COINS=" + coinspoints;
                pictureBox_coin2.Location = new Point(x, 0);
            }
            if (mycar.Bounds.IntersectsWith(pictureBox_coin3.Bounds))
            {
                coinspoints++;
                LBL_coins.Text = "COINS=" + coinspoints;
                pictureBox_coin3.Location = new Point(x, 0);
            }
            if (mycar.Bounds.IntersectsWith(pictureBox_coin4.Bounds))
            {
                coinspoints++;
                LBL_coins.Text = "COINS=" + coinspoints;
                pictureBox_coin4.Location = new Point(x, 0);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            movelanes(gamespeed);
            enemy(enemyspeed-1);
            //CarCollideWithEnemy();
            coins(gamespeed);
            collectcoins();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (mycar.Left > sidelaneswidth)
                    mycar.Left -= gamespeed;
            }
            if (e.KeyCode == Keys.Right)
            {
                if(mycar.Right < (windowwidth-sidelaneswidth) )
                    mycar.Left += gamespeed;
            }
            if (e.KeyCode == Keys.Up)
            {
                if(gamespeed<gamespeedupperlimit)
                    gamespeed++;
            }
            if (e.KeyCode == Keys.Down)
            {
                if(gamespeed>gamespeedlowerlimit)
                gamespeed--;
            }
        }

    }
}
