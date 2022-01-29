using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Circles
{
    public class Ball
    {
        private IRandom random;
        public Point Position { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }
        public int Size { get; set; }
        public Point RadiusCoordinates => new Point(Position.X + Size / 2, Position.Y + Size / 2);

        public Ball(int x = 0, int y = 0)
        {
            random = new BaseRandom();
            Position = new Point { X = x, Y = y };
            XSpeed = random.GetRandom(5, 20);
            YSpeed = random.GetRandom(5, 20);
            Size = random.GetRandom(5, 25);
        }

        public void ReverseDirection()
        {
            XSpeed *= -1;
            YSpeed *= -1;
        }

        private class BaseRandom : IRandom
        {
            private static Random _random;

            static BaseRandom()
            {
                _random = new Random();
            }

            public int GetRandom(int min, int max)
            {
                return _random.Next(min, max);
            }
        }
    }
}
