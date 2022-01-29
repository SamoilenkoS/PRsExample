using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Circles
{
    public static class CollisionHelper
    {
        public static void CheckCollisions(Ball ball, int width, int height)
        {
            if ((ball.Position.X > (width - ball.Size)) || ball.Position.X < 0)
            {
                ball.XSpeed *= -1;
            }

            if ((ball.Position.Y > (height - ball.Size)) || ball.Position.Y < 0)
            {
                ball.YSpeed *= -1;
            }
        }

        public static void CheckBallsCollision(Ball a, Ball b)
        {
            Point aRadiusCoordinates = a.RadiusCoordinates;
            Point bRadiusCoordinates = b.RadiusCoordinates;

            var distance = Math.Sqrt(
                (aRadiusCoordinates.X - bRadiusCoordinates.X) *
                (aRadiusCoordinates.X - bRadiusCoordinates.X) +
                (aRadiusCoordinates.Y - bRadiusCoordinates.Y) *
                (aRadiusCoordinates.Y - bRadiusCoordinates.Y));

            if (distance <= (a.Size / 2 + b.Size / 2))
            {
                a.ReverseDirection();
                b.ReverseDirection();
            }
        }
    }
}
