using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFormApp
{
    public interface IBall
    {
        Vector2 Pos { get; set; }
        Vector2 Speed { get; set; }
        int Size { get; set; }
        int Mass { get; set; }
    }
}
