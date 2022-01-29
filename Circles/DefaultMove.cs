using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Circles
{
    public class DefaultMove : IMove
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public DefaultMove(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Move(List<Ball> balls)
        {
            foreach (var ball in balls)
            {
                CollisionHelper.CheckCollisions(ball, Width, Height);

                ball.Position = new Point
                {
                    X = ball.Position.X + ball.XSpeed,
                    Y = ball.Position.Y + ball.YSpeed
                };
            }
        }
    }
}
