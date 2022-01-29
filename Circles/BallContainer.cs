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

        public BallContainer()
        {
            Balls = new List<Ball>();
        }

        public void Move(IMove moveAlgorithm)
        {
            moveAlgorithm.Move(Balls);
        }
    }
}
