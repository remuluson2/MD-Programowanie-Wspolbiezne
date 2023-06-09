﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFormApp
{
    public interface IBallManager
    {
        void AddBall();
        void AddBall(IBall ball);
        void AddBall(Vector2 position);
        IBall GetBall(int index);
        void ClearBalls();
        void UpdateBalls();
        void UpdateSize(int width, int height);
        void DrawBalls(PaintEventArgs e);
    }
}
