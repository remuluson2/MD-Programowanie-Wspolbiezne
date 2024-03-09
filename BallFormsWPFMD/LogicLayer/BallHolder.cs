using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using DataLayer;

namespace LogicLayer
{
    public class BallHolder : IBallHolder
    {
        public new ObservableCollection<IBall> Objects;
        int limitX = 0;
        int limitY = 0;
        public BallHolder(int limitX, int limitY)
        {
            Objects = new ObservableCollection<IBall>();
            this.limitX = limitX;
            this.limitY = limitY;
        }
        public BallHolder()
        {
            Objects = new ObservableCollection<IBall>();
            this.limitX = 100;
            this.limitY = 100;
        }
        public override void AddBall()
        {
            try
            {
                double Speed = GenRandomDouble();
                double Mass = GenRandomDouble();
                Objects.Add(new Ball(Objects.Count + 1, GenRandomInt(10, limitX), GenRandomInt(5, limitY), Mass, Speed));
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
                Objects.RemoveAt(index);
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: delBall, index: " + index);
            }
        }

        public void ResetBalls()
        {
            if (Objects != null)
            {
                try
                {
                    int totalAmount = Objects.Count;
                    Objects.Clear();
                    for (int i = 0; i < totalAmount; i++)
                        AddBall();
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
            return random.NextDouble() * 10.0 + 0.1;
        }

        public double CalcKinEnergy(double x, double e)
        {
            return 0.5 * x * e;
        }

        public void CalcCollision(int indexOne, int indexTwo)
        {
            try
            {
                double massOne = Objects.ElementAt(indexOne).ObjectMass, massTwo = Objects.ElementAt(indexTwo).ObjectMass;
                double speedOne = Objects.ElementAt(indexOne).ObjectVelocity, speedTwo = Objects.ElementAt(indexTwo).ObjectVelocity;
                double newSpeedOne = (speedOne * (massOne - massTwo) + 2 * massTwo * speedTwo) / (massOne + massTwo);
                double newSpeedTwo = (speedTwo * (massTwo - massOne) + 2 * massOne * speedOne) / (massOne + massTwo);
                Objects.ElementAt(indexOne).ObjectVelocity = newSpeedOne;
                Objects.ElementAt(indexTwo).ObjectVelocity = newSpeedTwo;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: calcCollision, indexOne: " + indexOne + ", indexTwo:" + indexTwo);
            }
        }

        public void SetObjectX(int index, int value)
        {
            try
            {
                Objects.ElementAt(index).ObjectX = value;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: setObjectX, index: " + index);
            }
        }
        public void SetObjectY(int index, int value)
        {
            try
            {
                Objects.ElementAt(index).ObjectY = value;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: setObjectY, index: " + index);
            }
        }

        public int GetObjectID(int index)
        {
            try
            {
                return Objects.ElementAt(index).ObjectID;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectID, index: " + index);
            }
        }

        public int GetObjectX(int index)
        {
            try
            {
                return Objects.ElementAt(index).ObjectX;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectX, index: " + index);
            }
        }
        public int GetObjectY(int index)
        {
            try
            {
                return Objects.ElementAt(index).ObjectY;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectY, index: " + index);
            }
        }
        public double GetObjectVelocity(int index)
        {
            try
            {
                return Objects.ElementAt(index).ObjectVelocity;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectY, index: " + index);
            }
        }

        public double GetObjectMass(int index)
        {
            try
            {
                return Objects.ElementAt(index).ObjectMass;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectY, index: " + index);
            }
        }

        // Sprawdza czy lista obiektów jest pusta (na potrzeby testów)
        public bool GetListStatus()
        {
            if (Objects.Count == 0)
                return true;
            else
                return false;
        }

        public void MoveBalls()
        {
            int count = Objects.Count;
            for (int i = 0; i < count; i++)
            {
                int newcordX = Objects[i].ObjectX + GenRandomInt(-2, 2);
                if (newcordX > limitX) newcordX = limitX;
                if (newcordX < 10) newcordX = 10;
                int newcordY = Objects[i].ObjectY + GenRandomInt(-2, 2);
                if (newcordY > limitY) newcordY = limitY;
                if (newcordY < 10) newcordY = 10;
                SetObjectX(i, newcordX);
                SetObjectY(i, newcordY);
            }
        }
    }
}
