using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circles
{
    public partial class Form1 : Form
    {
        private BallContainer _ballContainer;
        private IMove _move;
        private DateTime _lastCheck;
        public Form1()
        {
            InitializeComponent();
            _lastCheck = DateTime.Now;
            _move = new DefaultMove(pictureBox1.Width, pictureBox1.Height);
            _ballContainer = new BallContainer();
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
            _ballContainer.Move(_move);

            DrawEllipse();
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                _ballContainer.Balls.Add(
                    new Ball(
                        pictureBox1.Width / 2,
                        pictureBox1.Height - 150));

                _ballContainer.Move(_move);

                labelCount.Text = $"Count: {_ballContainer.Balls.Count}";
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            _move.Width = pictureBox1.Width;
            _move.Height = pictureBox1.Height;
        }
    }
}
