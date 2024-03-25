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
        public abstract Task SetCordsAsync(double newx, double newy);
        public abstract Task SetVelAsync(double newx, double newy);
        public abstract Task<double> GetXAsync();
        public abstract Task<double> GetYAsync();
        public abstract Task<double> GetVolXAsync();
        public abstract Task<double> GetVolYAsync();
        public abstract void LogStatus();
    }
}
