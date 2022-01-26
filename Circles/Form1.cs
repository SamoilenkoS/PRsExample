using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circles
{
    public partial class Form1 : Form
    {
        private BallContainer _ballContainer;
        public Form1()
        {
            InitializeComponent();
            _ballContainer = new BallContainer(pictureBox1.Width, pictureBox1.Height);
        }

        private void trackBarRed_Scroll(object sender, EventArgs e)
        {
            DrawEllipse();
        }

        private void DrawEllipse()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var graphics = Graphics.FromImage(bitmap);
            //graphics.Clear(Color.White);
            Brush brush = new SolidBrush(
                Color.FromArgb(255,
                (byte)trackBarRed.Value,
                (byte)trackBarGreen.Value,
                (byte)trackBarBlue.Value));
            int centerSize = 2;
            foreach (var ball in _ballContainer.Balls)
            {
               graphics.FillEllipse(
                   brush,
                   ball.Position.X,
                   ball.Position.Y,
                   ball.Size,
                   ball.Size);

                //graphics.FillEllipse(
                //    Brushes.Red,
                //    ball.Position.X + (ball.Size / 2) - centerSize,
                //    ball.Position.Y + (ball.Size / 2) - centerSize,
                //    centerSize, centerSize);
            }

            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawEllipse();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ballContainer.Move();
            DrawEllipse();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _ballContainer.Balls.Add(
                new Ball(
                    pictureBox1.Width / 2,
                    pictureBox1.Height - 150));
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            _ballContainer.Resize(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
