using System;
using System.Collections.Generic;
using System.Text;

namespace Circles
{
    public interface IMove
    {
        int Width { get; set; }
        int Height { get; set; }
        void Move(List<Ball> balls);
    }
}
