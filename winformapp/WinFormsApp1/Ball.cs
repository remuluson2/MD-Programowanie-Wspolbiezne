using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Ball : IBall
    {
        public int size = 10;
        public Vector2 Pos { get; set; }
        public Vector2 Speed { get; set; }
        public Ball(Vector2 pos,int newsize = 10)
        {
            Pos = pos;
            size = (int)newsize;
        }
        public Ball() { }
    }
}
