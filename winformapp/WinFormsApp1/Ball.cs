using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Ball : IBall
    {
        public int Size {get; set;}
        public Vector2 Pos { get; set; }
        public Vector2 Speed { get; set; }
        public Ball(Vector2 pos,int newsize = 200)
        {
            Pos = pos;
            Size = (int)newsize;
        }
        public Ball() 
        {
            Pos = new Vector2(0,0);
            Speed = new Vector2(0,0);
            Size = 200;
        }
    }
}
