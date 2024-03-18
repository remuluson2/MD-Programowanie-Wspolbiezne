using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;

namespace LogicLayer
{
    public class BallHolder : IBallHolder
    {
        public ObservableCollection<IBall> Balls {  get; private set; }
        Task moveBallsTask;
        readonly Timer cycleTimer;
        double limitX = 0;
        double limitY = 0;
        int defaultRadius = 100;

        public override int Count 
        {
            get 
            { 
                return Balls.Count;
            }
        }


        public override event NotifyCollectionChangedEventHandler? CollectionChanged;

        public BallHolder(double limitX = 100, double limitY = 100)
        {
            Balls = new ObservableCollection<IBall>();
            this.limitX = limitX;
            this.limitY = limitY;

            cycleTimer = new Timer(10);
            cycleTimer.Elapsed += OnTimerElapsed;
            cycleTimer.AutoReset = true;
        }

        public override void InitBalls(int ballsNumber)
        {
            for(int i = 0; i < ballsNumber; i++)
            {
                AddBall();
            }
        }

        public override void AddBall()
        {
            try
            {
                Balls.Add(
                    new Ball(
                        Balls.Count + 1,
                        GenRandomInt(0, (int)limitX - defaultRadius),
                        GenRandomInt(0, (int)limitY - defaultRadius),
                        velocityX: GenRandomDouble(),
                        velocityY: GenRandomDouble(),
                        size: defaultRadius)
                    );
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error: addBall");
            }
        }

        public override void DelBall(int index)
        {
            try
            {
                Balls.RemoveAt(index);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: delBall, index: " + index);
            }
        }

        public override void Clear()
        {
            if (Balls != null)
            {
                try
                {
                    Balls.Clear();
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Error: resetBalls");
                }
            }
        }

        private static int GenRandomInt(int x, int y)
        {
            Random random = new();
            return random.Next(x, y);
        }

        private static double GenRandomDouble()
        {
            Random random = new();
            return random.NextDouble() * 10.0 - 5.0;
        }

        public void MoveBalls()
        {
            if (moveBallsTask == null ||  moveBallsTask.IsCompleted)
            {
                List<Task> ballTasks = new List<Task>();
                foreach (var ball in Balls)
                {
                    ballTasks.Add(ball.Move());
                }
                moveBallsTask = Task.WhenAll(ballTasks.ToArray());

                CheckColisions();
            }
        }

        public void CheckColisions()
        {
            static bool DoCirclesOverlap(IBall ball1, IBall ball2)
            {
                //Size is actualy radius * 2 so we need to divide it first
                double r1 = ball1.ObjectRadius;
                double x1 = ball1.ObjectX;
                double y1 = ball1.ObjectY;

                double r2 = ball2.ObjectRadius;
                double x2 = ball2.ObjectX;
                double y2 = ball2.ObjectY;

                return Math.Abs((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) <= (r1 + r2) * (r1 + r2);
            }
            foreach (var ball in Balls)
            {
                ball.ObjectBrush = Brushes.Red;
            }

            foreach (var ball in Balls)
            {
                BorderColision(ball);
                foreach (var target in Balls)
                {
                    if (ball.ObjectID != target.ObjectID)
                    {
                        if(DoCirclesOverlap(ball,target))
                        {
                            //ball.ObjectBrush = Brushes.Blue;
                            StaticColision(ball, target);
                            DynamicColision(ball, target);
                        }
                    }
                }
            }
        }

        public void BorderColision(IBall ball)
        {
            double newcordX = ball.ObjectX;
            double newcordY = ball.ObjectY;
            double newvelX = ball.ObjectVelocityX;
            double newvelY = ball.ObjectVelocityY;

            if (newcordX > limitX - ball.ObjectSize)
            {
                newcordX = limitX - ball.ObjectSize;
                newvelX = -newvelX;
            }
            if (newcordX < 0)
            {
                newcordX = 0;
                newvelX = -newvelX;
            }
            if (newcordY > limitY - ball.ObjectSize)
            {
                newcordY = limitY - ball.ObjectSize;
                newvelY = -newvelY;
            }
            if (newcordY < 0)
            {
                newcordY = 0;
                newvelY = -newvelY;
            }

            if (ball.ObjectVelocityX != newvelX)
            {
                ball.ObjectVelocityX = newvelX;
            }

            if (ball.ObjectVelocityY != newvelY)
            {
                ball.ObjectVelocityY = newvelY;
            }

            if (ball.ObjectX != newcordX)
            {
                ball.ObjectX = newcordX;
            }

            if (ball.ObjectY != newcordY)
            {
                ball.ObjectY = newcordY;
            }
        }

        public void StaticColision(IBall ball1, IBall ball2)
        {
            double distance = Math.Sqrt((ball1.ObjectX - ball2.ObjectX) * (ball1.ObjectX - ball2.ObjectX) + (ball1.ObjectY - ball2.ObjectY) * (ball1.ObjectY - ball2.ObjectY));
            double overlap = 0.5d * (distance - ball1.ObjectRadius - ball2.ObjectRadius);

            ball1.ObjectX -= overlap * (ball1.ObjectX - ball2.ObjectX) / distance;
            ball1.ObjectY -= overlap * (ball1.ObjectY - ball2.ObjectY) / distance;

            ball2.ObjectX += overlap * (ball1.ObjectX - ball2.ObjectX) / distance;
            ball2.ObjectY += overlap * (ball1.ObjectY - ball2.ObjectY) / distance;
        }

        public void DynamicColision(IBall ball1, IBall ball2)
        {
            double distance = Math.Sqrt((ball1.ObjectX - ball2.ObjectX) * (ball1.ObjectX - ball2.ObjectX) + (ball1.ObjectY - ball2.ObjectY) * (ball1.ObjectY - ball2.ObjectY));

            double nx = (ball2.ObjectX - ball1.ObjectX) / distance;
            double ny = (ball2.ObjectY - ball1.ObjectY) / distance;

            double tx = -ny;
            double ty = nx;

            double dpTan1 = ball1.ObjectVelocityX * tx + ball1.ObjectVelocityY * ty;
            double dpTan2 = ball2.ObjectVelocityX * tx + ball2.ObjectVelocityY * ty;

            double dpNorm1 = ball1.ObjectVelocityX * nx + ball1.ObjectVelocityY * ny;
            double dpNorm2 = ball2.ObjectVelocityX * nx + ball2.ObjectVelocityY * ny;

            double momentum1 = dpNorm2;
            double momentum2 = dpNorm1;

            ball1.ObjectVelocityX = tx * dpTan1 + nx * momentum1;
            ball1.ObjectVelocityY = ty * dpTan1 + ny * momentum1;

            ball2.ObjectVelocityX = tx * dpTan2 + nx * momentum2;
            ball2.ObjectVelocityY = ty * dpTan2 + ny * momentum2;

        }

        public override void Dispose()
        {
            Balls.Clear();
            cycleTimer.Stop();
            cycleTimer.Dispose();
        }

        public override void SetNewArea(double width, double height)
        {
            limitX = width;
            limitY = height;
        }

        public override void SetNewSize(int size)
        {
            defaultRadius = size;
        }

        public override void StartTimer()
        {
            cycleTimer.Start();
        }

        public override void StopTimer()
        {
            cycleTimer.Stop();
        }

        private void OnTimerElapsed(Object? source, ElapsedEventArgs e)
        {
            MoveBalls();
        }
    }
}
