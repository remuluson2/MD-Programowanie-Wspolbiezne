using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public interface IBallManager
    {
        void AddBall(IBall ball);
        void AddBall(Vector2 position);
        IBall GetBall(int index);
        void ClearBalls();
        void UpdateBalls();
        void UpdateSize(int width, int height);
        void DrawBalls(PaintEventArgs e);
    }
}
