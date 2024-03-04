using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace MSTest
{
    [TestClass]
    public class DataLayerTest
    {
        [TestMethod, TestCategory("DataLayer")]
        public void TestAddAndRemove()
        {
            IBallHolder holder = new BallHolder();
            IBall ball1 = new Ball();
            holder.Add(ball1);
            Assert.IsTrue(holder.Contains(ball1));
            holder.Remove(ball1);
            Assert.IsFalse(holder.Contains(ball1));
        }
        [TestMethod, TestCategory("DataLayer")]
        public void TestCount()
        {
            IBallHolder holder = new BallHolder();
            IBall ball1 = new Ball();
            IBall ball2 = new Ball();

            holder.Add(ball1);
            holder.Add(ball2);
            Assert.AreEqual(2, holder.Count);
            Assert.AreNotEqual(0, holder.Count);

            holder.Clear();
            Assert.AreEqual(0, holder.Count);
        }
    }
}
