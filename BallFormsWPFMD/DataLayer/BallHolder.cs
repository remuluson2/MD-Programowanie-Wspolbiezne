using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BallHolder : IBallHolder
    {
        List<IBall> balls;

        public int Count {  get { return balls.Count; } }

        public bool IsReadOnly { get { return false; } }

        public BallHolder() 
        { 
            balls = new List<IBall>();
        }

        void ICollection<IBall>.Add(IBall item)
        {
            ((ICollection<IBall>)balls).Add(item);
        }

        public void Clear()
        {
            ((ICollection<IBall>)balls).Clear();
        }

        bool ICollection<IBall>.Contains(IBall item)
        {
            return ((ICollection<IBall>)balls).Contains(item);
        }

        public void CopyTo(IBall[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<IBall>.Remove(IBall item)
        {
            return ((ICollection<IBall>)balls).Remove(item);
        }

        IEnumerator<IBall> IEnumerable<IBall>.GetEnumerator()
        {
            return ((IEnumerable<IBall>)balls).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)balls).GetEnumerator();
        }
    }
}
