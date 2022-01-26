using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            if(Balls.Count > 1)
            {
                for (int i = 0; i < Balls.Count - 1; i++)
                {
                    for (int j = i + 1; j < Balls.Count; j++)
                    {
                        CheckCollisions(Balls[i]);
                        CheckBallsCollision(Balls[i], Balls[j]);

                        Balls[i].Position = new Point
                        {
                            X = Balls[i].Position.X + Balls[i].XSpeed,
                            Y = Balls[i].Position.Y + Balls[i].YSpeed
                        };
                    }
                }

                Ball last = Balls.Last();
                CheckCollisions(last);
                last.Position = new Point
                {
                    X = last.Position.X + last.XSpeed,
                    Y = last.Position.Y + last.YSpeed
                };
            }
            else
            {
                Ball first = Balls.FirstOrDefault();
                if(first != null)
                {
                    CheckCollisions(first);
                    first.Position = new Point
                    {
                        X = first.Position.X + first.XSpeed,
                        Y = first.Position.Y + first.YSpeed
                    };
                }
               
            }
        }

        private void CheckCollisions(Ball ball)
        {
            if ((ball.Position.X > (_width - ball.Size)) || ball.Position.X < 0)
            {
                ball.XSpeed *= -1;
            }

            if ((ball.Position.Y > (_height - ball.Size)) || ball.Position.Y < 0)
            {
                ball.YSpeed *= -1;
            }
        }

        private void CheckBallsCollision(Ball a, Ball b)
        {
            Point aRadiusCoordinates = a.RadiusCoordinates;
            Point bRadiusCoordinates = b.RadiusCoordinates;

            var distance = Math.Sqrt(
                (aRadiusCoordinates.X - bRadiusCoordinates.X) *
                (aRadiusCoordinates.X - bRadiusCoordinates.X) +
                (aRadiusCoordinates.Y - bRadiusCoordinates.Y) *
                (aRadiusCoordinates.Y - bRadiusCoordinates.Y));

            if(distance <= (a.Size / 2 + b.Size / 2))
            {
                a.ReverseDirection();
                b.ReverseDirection();
            }
        }
    }
}
