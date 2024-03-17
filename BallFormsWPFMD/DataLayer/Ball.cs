using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace DataLayer
{
    public class Ball : IBall
    {
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
            
            if (ObjectX != newcordX)
            {
                ObjectX = newcordX;
            }

            if (ObjectY != newcordY)
            {
                ObjectY = newcordY;
            }
        }
    }
}
