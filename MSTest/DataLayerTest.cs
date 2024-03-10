using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using DataLayer;
using System.ComponentModel;

namespace MSTest
{
    [TestClass]
    public class DataLayerTest
    {
        [TestMethod, TestCategory("DataLayer")]
        public void TestBall()
        {
            List<string> receivedEvents = new List<string>();
            IBall ball = new Ball(ID: 1);

            ball.PropertyChanged += delegate (object? sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            Assert.IsNotNull(ball);
            ball.ObjectX = 1;
            Assert.IsTrue(ball.ObjectX == 1);
            ball.ObjectY = 1;
            Assert.IsTrue(ball.ObjectY == 1);
            ball.ObjectVelocityX = 1.0;
            Assert.IsTrue(ball.ObjectVelocityX == 1.0);
            Assert.IsTrue(receivedEvents.Count == 2);
        }
    }
}
