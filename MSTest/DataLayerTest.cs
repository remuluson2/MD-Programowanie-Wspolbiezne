using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using DataLayer;

namespace MSTest
{
    [TestClass]
    public class DataLayerTest
    {
        [TestMethod, TestCategory("DataLayer")]
        public void TestBall()
        {
            IBall ball = new Ball(ID:1);
            Assert.IsNotNull(ball);
            ball.ObjectX = 1;
            Assert.IsTrue(ball.ObjectX == 1);
            ball.ObjectY = 1;
            Assert.IsTrue(ball.ObjectY == 1);
            ball.ObjectVelocity = 1.0;
            Assert.IsTrue(ball.ObjectVelocity == 1.0);
            ball.ObjectY = 1;
            Assert.IsTrue(ball.ObjectY == 1);
        }
    }
}
