using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFormApp
{
    public class Ball : IBall
    {
        public int Size { get; set; }
        public int Mass { get; set; }
        public Vector2 Pos { get; set; }
        public Vector2 Speed { get; set; }
        public Ball(Vector2 pos, int newsize = 50, int newmass = 1)
        {
            Pos = pos;
            Size = newsize;
            Mass = newmass;
        }
        public Ball()
        {
            Pos = new Vector2(0, 0);
            Speed = new Vector2(0, 0);
            Size = 50;
            Mass = 1;
        }
    }
}
