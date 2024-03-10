using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataLayer
{
    public class Ball : IBall
    {
        private readonly int ID = 0;
        private double X;
        private double Y;
        private double velX;
        private double velY;
        private double size;
        private readonly double mass = 0.0;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public Ball(int ID, int X = 0, int Y = 0, double Mass = 0.0, double velocityX = 0.0, double velocityY = 0.0, double size = 50.0)
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.mass = Mass;
            this.velX = velocityX;
            this.velY = velocityY;
            this.size = size;
        }

        public override int ObjectID
        {
            get { return ID; }
        }

        public override double ObjectX
        {
            get { return X; }
            set
            {
                X = value;
                OnPropertyChanged();
            }
        }

        public override double ObjectY
        {
            get { return Y; }
            set
            {
                Y = value;
                OnPropertyChanged();
            }
        }

        public override double ObjectVelocityX
        {
            get { return velX; }
            set { velX = value; }
        }

        public override double ObjectVelocityY
        {
            get { return velY; }
            set { velY = value; }
        }

        public override double ObjectSize
        { 
          get { return size; }
          set { size = value; }
        }

        public override double ObjectMass
        {
            get { return mass; }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
