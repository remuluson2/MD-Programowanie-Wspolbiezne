using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public void AddBall()
        {
            Vector2 RandomPos = new Vector2();
            RandomPos.X = Random.Shared.Next(0,WIDTH);
            RandomPos.Y = Random.Shared.Next(0,HEIGHT);
            AddBall(RandomPos);
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
                //end of task
                WallColision(ball);
            }
            //threads finish and close, app enters critical section
            HandleColisions();

        }
        private void UpdateBall(IBall ball)
        {
            ball.Pos += ball.Speed;
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
                        Deflection(balls[i], balls[j]);
                    }
                }
            }
        }

        private bool CheckColision(IBall ball1, IBall ball2)
        {
            double distance = Math.Sqrt(Math.Pow((ball1.Pos.X
                                    + ball1.Speed.X)
                                    - (ball2.Pos.X
                                    + ball2.Speed.X), 2)
                                    + Math.Pow((ball1.Pos.Y
                                    + ball1.Speed.Y)
                                    - (ball2.Pos.Y
                                    + ball2.Speed.Y), 2));
            if (Math.Abs(distance) <= ball1.Size/2 + ball2.Size/2)
            {
                return true;
            } else {
                return false;
            }

        }

        private void Deflection(IBall ball1, IBall ball2)
        {
                double mass = ball1.Mass;
                double otherMass = ball2.Mass;

                double[] velocity = new double[2] { ball1.Speed.X, ball1.Speed.Y };
                double[] position = new double[2] {ball1.Pos.X, ball1.Pos.Y };

                double[] velocityOther = new double[2] { ball2.Speed.X , ball2.Speed.Y };
                double[] positionOther = new double[2] { ball2.Pos.X, ball2.Pos.Y };

                double fDistance = (double)Math.Sqrt((position[0] - positionOther[0]) * (position[0] - positionOther[0])
                       + (position[1] - positionOther[1]) * (position[1] - positionOther[1]));

                double nx = (positionOther[0] - position[0]) / fDistance;
                double ny = (positionOther[1] - position[1]) / fDistance;

                double tx = -ny;
                double ty = nx;

                // Dot Product Tangent
                double dpTan1 = velocity[0] * tx + velocity[1] * ty;
                double dpTan2 = velocityOther[0] * tx + velocityOther[1] * ty;

                // Dot Product Normal
                double dpNorm1 = velocity[0] * nx + velocity[1] * ny;
                double dpNorm2 = velocityOther[0] * nx + velocityOther[1] * ny;

                // Conservation of momentum in 1D
                double m1 = (dpNorm1 * (mass - otherMass) + 2.0f * otherMass * dpNorm2) / (mass + otherMass);
                double m2 = (dpNorm2 * (otherMass - mass) + 2.0f * mass * dpNorm1) / (mass + otherMass);

                double[] newMovements = new double[4]
                {
                    tx * dpTan1 + nx * m1,
                    ty * dpTan1 + ny * m1,
                    tx * dpTan2 + nx * m2,
                    ty * dpTan2 + ny * m2
                };
            Vector2 newSpeed = new Vector2();
            newSpeed.X = (float)newMovements[0];
            newSpeed.Y = (float)newMovements[1];
            ball1.Speed = newSpeed;
            newSpeed.X = (float)newMovements[2];
            newSpeed.Y = (float)newMovements[3];
            ball2.Speed = newSpeed;
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
