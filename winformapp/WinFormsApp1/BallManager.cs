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
            while(speed.X == 0)
            speed.X = Random.Shared.NextInt64() % 8 - 4;
            while (speed.Y == 0)
            speed.Y = Random.Shared.NextInt64() % 8 - 4;
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
            //if balls are all in proper state and collisions were handled, run the update
            foreach (IBall ball in balls)
            {
                //start thread with updateball task
                UpdateBall(ball);
            }
            //threads finish and close, app enters critical section
            HandleColisions();

        }
        private void UpdateBall(IBall ball)
        {
            ball.Pos += ball.Speed;
            WallColision(ball);
        }
        private void WallColision(IBall ball)
        {
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
        private void HandleColisions()
        {
            if(balls.Count < 2)
            {
                return;
            }
            for(int i = 0; i < balls.Count - 1; i++)
            {
                for(int j = i+1; j < balls.Count; j++)
                {
                    if(CheckColision(balls[i], balls[j]))
                    {
                        Separation(balls[i], balls[j]);
                        Deflection(balls[i], balls[j]);
                    }
                }
            }
        }
        private bool CheckColision(IBall ball1,IBall ball2)
        {
            return false;
        }
        private void Separation(IBall ball1,IBall ball2)
        {

        }
        private void Deflection(IBall ball1, IBall ball2)
        {

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
