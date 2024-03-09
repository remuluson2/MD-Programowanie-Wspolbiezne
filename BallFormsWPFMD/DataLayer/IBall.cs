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
        public abstract int ObjectX { get; set; }
        public abstract int ObjectY { get; set; }
        public abstract double ObjectVelocity { get; set; }
        public abstract double ObjectMass { get; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }
}
