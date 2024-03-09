using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataLayer
{
    public class Ball : IBall
    {
        private readonly int ID = 0;
        public int X;
        public int Y;
        public double Velocity;
        private readonly double Mass = 0.0;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public Ball(int ID, int X = 0, int Y = 0, double Mass = 0.0, double Velocity = 0.0)
        {
            this.ID = ID;
            this.X = X;
            this.Y = Y;
            this.Mass = Mass;
            this.Velocity = Velocity;
        }

        public override int ObjectID
        {
            get { return ID; }
        }

        public override int ObjectX
        {
            get { return X; }
            set
            {
                X = value;
                OnPropertyChanged();
            }
        }

        public override int ObjectY
        {
            get { return Y; }
            set
            {
                Y = value;
                OnPropertyChanged();
            }
        }

        public override double ObjectVelocity
        {
            get { return Velocity; }
            set { Velocity = value; }
        }

        public override double ObjectMass
        {
            get { return Mass; }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
