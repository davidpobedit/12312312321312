using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comet
{
    class Ball : PictureBox
    {
        double x, y;
        double vx, vy;
        int size;
        Form parent;
        Timer timer = new Timer();
        Timer timerSet = new Timer();
        Bitmap image = new Bitmap("ball.png");
        
        static Random random = new Random();
        public Ball(Form form)
        {
            parent = form;
            size = random.Next(10, 30);
            x = random.Next(size, form.ClientSize.Width - size);
            y = random.Next(size, form.ClientSize.Height - size);
            vy = (random.NextDouble() - 0.5) * 15;
            vx = (random.NextDouble() - 0.5) * 15;
            parent.Controls.Add(this);

            this.Image = image;
            this.Height = 2 * size;
            this.Width = 2 * size;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            timer.Enabled = false;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

            timerSet.Enabled = false;
            timerSet.Interval = 100;
            timerSet.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Move();
            Show();
        }
        public new void Move()
        {
            x += vx;
            y += vy;
        }
        public new void Show()
        {
            this.Top = (int)y - size;
            this.Left = (int)x - size;
        }
        public void Go()
        {
            timer.Enabled = true;
        }
        public void SetBalls()
        {
            timerSet.Start();
            timerSet.Tick += Timer_Tick1;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            timerSet.Stop();
        }
    }
}
