using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eared_hunt
{
    public partial class Form1 : Form
    {     
        Bitmap frame;
        hero h;
        coin [] c;
        splash[] sp;
        PictureBox[]  pictureBox;
        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();
            frame = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            c = new coin[10];
            sp = new splash[5];
            pictureBox3.BackColor = Color.Transparent;
            Random R;
            R = new Random();
            h = new hero(pictureBox4.Width, pictureBox4.Height, R);
            for (int i = 0; i < 10; i++)
            {
                c[i] = new coin(pictureBox4.Width, pictureBox4.Height,R);
            }
            for (int i = 0; i < 5; i++)
            {
                sp[i] = new splash(pictureBox4.Width, pictureBox4.Height, R);
            }

        }
        int left;
        int score=0;
        private void timer1_Tick(object sender, EventArgs e)
        {  
            left-=4;
            if (left < -pictureBox1.Width) left = 0;
            Graphics g1 = Graphics.FromImage(frame);
            g1.DrawImage(pictureBox1.BackgroundImage, left, 0, pictureBox1.Width, pictureBox1.Height);
            g1.DrawImage(pictureBox1.BackgroundImage, left+ pictureBox1.Width, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < 10; i++)
            {
                frame=c[i].draw(pictureBox3, frame);
                if (c[i].y > h.y && c[i].y < h.y + 100 && c[i].x < 350&& c[i].x>264)
                {
                    score++; 
                   c[i].x = pictureBox4.Width;
                }          
            }
            for (int i = 0; i < 5; i++)
            {
                frame = sp[i].draw(pictureBox5, frame);
                if (sp[i].y > h.y && sp[i].y < h.y + 100 && sp[i].x < 350 && sp[i].x > 264)
                {
                    score--;
                    sp[i].x = pictureBox4.Width;
                }
            }
            h.draw(pictureBox2, frame);
            pictureBox4.Image = frame;
            label1.Text = "Score: " + score;
            if(score >= -5)
            {
                Form bc3 = new Form3();
                bc3.StartPosition = FormStartPosition.CenterScreen;
                bc3.Show();
                this.Close();

            }
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {       
            h.y = e.Y;     
        }
    /*    void play()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            player.SoundLocation = "coin-sound.wav";
            player.Play();
        }*/
    }
    class coin
    {
       public  int x, y,trottle=0;
        int frame_n = 0;
        public Random R;
       public coin(int w,int h,Random r)
        {
            R = r;
            frame_n= R.Next(0,6);
            x = R.Next(0,w-240)+200;
            y = R.Next(0, h-80)+40;
        }

            public Bitmap draw(PictureBox coin, Bitmap frame)
        {
            Bitmap b;
            b = new Bitmap(40,40);
            Graphics g=Graphics.FromImage(b);
            Graphics g1 = Graphics.FromImage(frame);
            g.DrawImage(coin.BackgroundImage, -frame_n*40, 0,240,40);
            g1.DrawImage(b,x,y,20,20);
            x--;
            trottle++;
             if (trottle == 4)
            { trottle = 0;
                frame_n++;
            }
            
            if (frame_n == 6)
                {
                frame_n = 0;
                }
            return frame;
        }
    }

    class splash
    {
        public int x, y, trottle = 0;
        int frame_n = 0;
        public Random R;
        public splash(int w, int h, Random r)
        {
            R = r;
            frame_n = R.Next(0, 6);
            x = R.Next(0, w - 240) + 200;
            y = R.Next(0, h - 80) + 40;
        }
        public Bitmap draw(PictureBox splash, Bitmap frame)
        {
            Bitmap b;
            b = new Bitmap(601/4, 105);
            Graphics g = Graphics.FromImage(b);
            Graphics g1 = Graphics.FromImage(frame);
            g.DrawImage(splash.BackgroundImage, -frame_n * (601 / 4-2), 0, 601, 105); 
            g1.DrawImage(b, x, y, 80, 80);
            x--;
            trottle++;
            if (trottle == 6)
            {
                trottle = 0;
                frame_n++;
            }

            if (frame_n == 4)
            {
                frame_n = 0;
            }
            return frame;
        }
    }
        class hero
    {
       public  int x, y, trottle = 0;
        int frame_n = 0;
        public Random R;
        public hero(int w, int h, Random r)
        {
            R = r;
            frame_n = R.Next(0, 6);
            x =236;
            y = 264;
        }
        public Bitmap draw(PictureBox coin,PictureBox splash, Bitmap frame)
        {
            Bitmap b;
            b = new Bitmap(1492/6, 210);
            Graphics g = Graphics.FromImage(b);
            Graphics g1 = Graphics.FromImage(frame);
            g.DrawImage(coin.BackgroundImage, -frame_n * (1492 / 6 - 3), 0, 1492, 210);
            g1.DrawImage(b, x, y, 150, 150);

            trottle++;
            if (trottle == 3)
            {
                trottle = 0;
                frame_n++;
            }

            if (frame_n == 6)
            {
                frame_n = 0;
            }
            return frame;
        }
    }
}
