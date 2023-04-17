using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal interface IBallManager
    {
        void AddBall(Ball ball);
        void AddBall(Vector2 position);
        Ball GetBall(int index);
        void ClearBalls();
        void UpdateBalls();
        void UpdateSize();
    }
}
