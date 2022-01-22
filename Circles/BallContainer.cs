using System;
using System.Collections.Generic;
using System.Text;

namespace Circles
{
    public class BallContainer
    {
        public List<Ball> Balls { get; set; }
        private int _width;
        private int _height;

        public BallContainer(int width, int height)
        {
            Balls = new List<Ball>();
            _width = width;
            _height = height;
        }

        public void Resize(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void Move()
        {
            foreach (var ball in Balls)
            {
                CheckCollisions(ball);

                ball.Position = new System.Drawing.Point
                {
                    X = ball.Position.X + ball.XSpeed,
                    Y = ball.Position.Y + ball.YSpeed
                };
            }
        }

        private void CheckCollisions(Ball ball)
        {
            if (ball.Position.X > _width || ball.Position.X < 0)
            {
                ball.XSpeed *= -1;
            }

            if (ball.Position.Y > _height || ball.Position.Y < 0)
            {
                ball.YSpeed *= -1;
            }
        }
    }
}
