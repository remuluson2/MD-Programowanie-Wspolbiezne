using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BallFormApp
{
    public class BallManager : IBallManager
    {
        List<IBall> balls;
        int WIDTH, HEIGHT;


        public BallManager()
        {
            balls = new List<IBall>();
        }
        public void AddBall(Vector2 position)
        {
            Ball ball = new(position);
            Vector2 speed = ball.Speed;
            speed.X = Random.Shared.NextInt64() % 4 - 2;
            speed.Y = Random.Shared.NextInt64() % 4 - 2;
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
        public void UpdateBalls()
        {
            foreach (IBall ball in balls)
            {
                ball.Pos += ball.Speed;
                Vector2 speed = ball.Speed;
                if (ball.Pos.X < 0)
                {
                    // if ball is moving wrong way in X axis, reverse X vector
                    if (ball.Speed.X < 0)
                    {
                        speed.X *= -1;
                    }

                }
                else if (ball.Pos.X + ball.Size > WIDTH)
                {
                    if (ball.Speed.X > 0)
                    {
                        speed.X *= -1;
                    }
                }

                if (ball.Pos.Y < HEIGHT / 10.0)
                {
                    // if ball is moving wrong way in Y axis, reverse Y vector
                    if (ball.Speed.Y < 0)
                    {
                        speed.Y *= -1;
                    }

                }
                else if (ball.Pos.Y + ball.Size > HEIGHT)
                {
                    if (ball.Speed.Y > 0)
                    {
                        speed.Y *= -1;
                    }
                }
                ball.Speed = speed;
            }
        }

        public void AddBall(IBall ball)
        {
            balls.Add(ball);
        }

        public IBall GetBall(int index)
        {
            return balls[index];
        }

        public void DrawBalls(PaintEventArgs e)
        {
            foreach (IBall ball in balls)
            {
                e.Graphics.FillEllipse(Brushes.BlueViolet, ball.Pos.X, ball.Pos.Y, ball.Size, ball.Size);
            }
        }
    }
}
