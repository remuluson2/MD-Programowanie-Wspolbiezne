using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DataLayer
{
    public abstract class IBall : INotifyPropertyChanged
    {
        public abstract int ObjectID { get; }
        public abstract double ObjectX { get; set; }
        public abstract double ObjectY { get; set; }
        public abstract double ObjectVelocityX { get; set; }
        public abstract double ObjectVelocityY { get; set; }
        public abstract double ObjectSize { get; set; }
        public abstract double ObjectMass { get; }
        public abstract double ObjectRadius { get; }
        public abstract Brush ObjectBrush { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract Task Move();
    }
}
