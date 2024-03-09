using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace LogicLayer
{
    public abstract class IBallHolder
    {
        public ObservableCollection<IBall>? Objects;
        public abstract void AddBall();
        public abstract void DelBall(int index);

    }
}
