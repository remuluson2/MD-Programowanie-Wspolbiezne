using DataLayer;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Timers;

namespace LogicLayer
{
    public class BallHolder : IBallHolder
    {
        public ObservableCollection<IBall> Balls {  get; private set; }

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

        public static double CalcKinEnergy(double x, double e)
        {
            return 0.5 * x * e;
        }

        /*public void CalcCollision(int indexOne, int indexTwo)
        {
            try
            {
                double massOne = balls.ElementAt(indexOne).ObjectMass, massTwo = balls.ElementAt(indexTwo).ObjectMass;
                double speedOne = balls.ElementAt(indexOne).ObjectVelocity, speedTwo = balls.ElementAt(indexTwo).ObjectVelocity;
                double newSpeedOne = (speedOne * (massOne - massTwo) + 2 * massTwo * speedTwo) / (massOne + massTwo);
                double newSpeedTwo = (speedTwo * (massTwo - massOne) + 2 * massOne * speedOne) / (massOne + massTwo);
                balls.ElementAt(indexOne).ObjectVelocity = newSpeedOne;
                balls.ElementAt(indexTwo).ObjectVelocity = newSpeedTwo;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: calcCollision, indexOne: " + indexOne + ", indexTwo:" + indexTwo);
            }
        }*/

        public void MoveBalls()
        {
            foreach(var ball in Balls)
            {
                double newcordX = ball.ObjectX + ball.ObjectVelocityX;
                double newcordY = ball.ObjectY + ball.ObjectVelocityY;
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

                if (ball.ObjectX != newcordX)
                {
                    ball.ObjectX = newcordX;
                }

                if (ball.ObjectY != newcordY)
                {
                    ball.ObjectY = newcordY;
                }

                if (ball.ObjectVelocityX != newvelX)
                {
                    ball.ObjectVelocityX = newvelX;
                }

                if (ball.ObjectVelocityY != newvelY)
                {
                    ball.ObjectVelocityY = newvelY;
                }

            }
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
