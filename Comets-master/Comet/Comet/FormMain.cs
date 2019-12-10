using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comet
{
    public partial class FormMain : Form
    {
        List<Ball> balls = new List<Ball>();
        int count = 15;

        public FormMain()
        {
            InitializeComponent();
        }
       
        private void FormMain_Click(object sender, EventArgs e)
        {
            var ball = sender as Ball;
            ball.Go();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                balls.Add(new Ball(this));
                balls.Last().MouseDown += FormMain_Click;
                balls.Last().SetBalls();
                using (var gp = new GraphicsPath())
                {
                    gp.AddEllipse(new Rectangle(0, 0, balls.Last().Width - 1, balls.Last().Height - 1));
                    balls.Last().Region = new Region(gp);
                }
            }
            START.Enabled = false;
            START.Visible = false;
        }
    }
}
