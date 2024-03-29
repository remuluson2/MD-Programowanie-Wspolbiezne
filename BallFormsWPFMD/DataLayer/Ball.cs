﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation.Provider;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml.Serialization;

namespace DataLayer
{
    public class Ball : IBall
    {
        private readonly SemaphoreSlim _lock;
        private object _locker = new object();
        private readonly int _ID = 0;
        private double _x;
        private double _y;
        private double _velX;
        private double _velY;
        private double _size;
        private Brush _brush;
        private readonly double _mass = 0.0;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public Ball(int ID, int X = 0, int Y = 0, double Mass = 0.0, double velocityX = 0.0, double velocityY = 0.0, double size = 50.0)
        {
            _lock = new SemaphoreSlim(1,1);
            this._ID = ID;
            this._x = X;
            this._y = Y;
            this._mass = Mass;
            this._velX = velocityX;
            this._velY = velocityY;
            this._size = size;
            this._brush = Brushes.Red;
        }

        public override int ObjectID
        {
            get { return _ID; }
        }

        public override double ObjectX
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged();
            }
        }

        public override double ObjectY
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged();
            }
        }

        public override double ObjectVelocityX
        {
            get { return _velX; }
            set { _velX = value; }
        }

        public override double ObjectVelocityY
        {
            get { return _velY; }
            set { _velY = value; }
        }

        public override double ObjectSize
        { 
          get { return _size; }
          set { _size = value; }
        }

        public override double ObjectMass
        {
            get { return _mass; }
        }

        public override Brush ObjectBrush 
        {
            get { return _brush; }
            set 
            {
                _brush = value;
                OnPropertyChanged();
            } 
        }

        public override double ObjectRadius
        {
            get { return _size / 2; }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override void Move()
        {
            double newcordX = ObjectX + ObjectVelocityX;
            double newcordY = ObjectY + ObjectVelocityY;

            SetCords(newcordX, newcordY);
            return;
        }

        public override void SetCords(double newx, double newy)
        {
            lock(_locker)
            {
                if (newx != ObjectX)
                {
                    ObjectX = newx;
                }
                if (newy != ObjectY)
                {
                    ObjectY = newy;
                }
            }
            return;
        }

        public override async Task SetVelAsync(double newx, double newy)
        {
            await _lock.WaitAsync();
            if (newx != ObjectVelocityX)
            {
                ObjectVelocityX = newx;
            }
            if (newy != ObjectVelocityY)
            {
                ObjectVelocityY = newy;
            }
            _lock.Release();
        }

        public override async Task<double> GetXAsync()
        {
            lock (_locker);
            return ObjectX;
        }

        public override async Task<double> GetYAsync()
        {
            lock (_locker) ;
            return ObjectY;
        }

        public override async Task<double> GetVolXAsync()
        {
            lock (_locker) ;
            return ObjectVelocityX;
        }

        public override async Task<double> GetVolYAsync()
        {
            lock (_locker) ;
            return ObjectVelocityY;
        }

        public override void LogStatus()
        {
            _ = Logger.GetInstance().Result.LogMessage($"Ball {ObjectID} - X: {ObjectX} Y: {ObjectY}");
        }
    }
}
