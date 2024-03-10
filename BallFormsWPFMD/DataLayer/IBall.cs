using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }
}
