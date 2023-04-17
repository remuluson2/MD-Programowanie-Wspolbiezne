using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal interface IBall
    {
        Vector2 Pos { get; set; }
        Vector2 Speed { get; set; }
    }
}
