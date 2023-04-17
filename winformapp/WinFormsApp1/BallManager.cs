using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class BallManager : IBallManager
    {
        List<IBall> balls;
        int WIDTH, HEIGHT;


        BallManager()
        {
            balls = new List<IBall>();
        }
        public void AddBall(Vector2 position)
        {
            Ball ball = new(position);
            Vector2 speed = ball.Speed;
            speed.X = (Random.Shared.NextInt64() % 4) - 2;
            speed.Y = (Random.Shared.NextInt64() % 4) - 2;
            ball.Speed = speed;
            balls.Add(ball);
        }
        public void ClearBalls()
        {
            balls.Clear();
        }
        public void UpdateSize(int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;
        }
        public void UpdateBalls() {
            foreach (IBall ball in balls)
            {
                ball.Pos += ball.Speed;
                Vector2 speed = ball.Speed;
                if(ball.Pos.X < 0)
                {
                    // if ball is moving wrong way in X axis, reverse X vector
                    if(ball.Speed.X < 0)
                    {
                        speed.X *= -1;
                    }

                } else if (ball.Pos.X > WIDTH)
                {
                    if (ball.Speed.X > 0)
                    {
                        speed.X *= -1;
                    }
                }

                if (ball.Pos.Y < 0)
                {
                    // if ball is moving wrong way in X axis, reverse X vector
                    if (ball.Speed.Y < 0)
                    {
                        speed.Y *= -1;
                    }

                }
                else if (ball.Pos.Y > HEIGHT)
                {
                    if (ball.Speed.Y > 0)
                    {
                        speed.Y *= -1;
                    }
                }
                ball.Speed = speed;
            }
        }

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }

        public Ball GetBall(int index)
        {
            if (balls[index].GetType() == typeof(Ball))
            return (Ball)balls[index];
            throw new InvalidOperationException();
        }

        public void UpdateSize()
        {
            throw new NotImplementedException();
        }
    }
}
