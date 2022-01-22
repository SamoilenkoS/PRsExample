using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Circles
{
    public class Ball
    {
        private static Random random;
        public Point Position { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }

        static Ball()
        {
            random = new Random();
        }

        public Ball(int x = 0, int y = 0)
        {
            Position = new Point { X = x, Y = y };
            XSpeed = random.Next(5, 20);
            YSpeed = random.Next(5, 20);
        }
    }
}
