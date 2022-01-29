using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Circles
{
    public class CollisionMove : IMove
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public CollisionMove(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Move(List<Ball> balls)
        {
            if (balls.Count > 1)
            {
                for (int i = 0; i < balls.Count - 1; i++)
                {
                    for (int j = i + 1; j < balls.Count; j++)
                    {
                        CollisionHelper.CheckCollisions(balls[i], Width, Height);
                        CollisionHelper.CheckBallsCollision(balls[i], balls[j]);

                        balls[i].Position = new Point
                        {
                            X = balls[i].Position.X + balls[i].XSpeed,
                            Y = balls[i].Position.Y + balls[i].YSpeed
                        };
                    }
                }

                Ball last = balls.Last();
                CollisionHelper.CheckCollisions(last, Width, Height);
                last.Position = new Point
                {
                    X = last.Position.X + last.XSpeed,
                    Y = last.Position.Y + last.YSpeed
                };
            }
            else
            {
                Ball first = balls.FirstOrDefault();
                if (first != null)
                {
                    CollisionHelper.CheckCollisions(first, Width, Height);
                    first.Position = new Point
                    {
                        X = first.Position.X + first.XSpeed,
                        Y = first.Position.Y + first.YSpeed
                    };
                }

            }
        }
    }
}
