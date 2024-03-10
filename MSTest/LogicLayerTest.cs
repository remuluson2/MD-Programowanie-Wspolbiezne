using LogicLayer;
using System.Collections.Specialized;

namespace MSTest
{
    [TestClass]
    public class LogicLayerTest
    {
        [TestMethod, TestCategory("LogicLayerTest")]
        public void TestBallHolder()
        {
            List<string> receivedEvents = new List<string>();
            IBallHolder ballHolder = new BallHolder();

            ballHolder.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
            {
                receivedEvents.Add(e.ToString());
            };

            Assert.IsNotNull(ballHolder);
            ballHolder.AddBall();
            Assert.IsTrue(ballHolder.Count == 1);
            ballHolder.Clear();
            Assert.IsTrue(ballHolder.Count == 0);

            Assert.IsTrue(receivedEvents.Count == 2);
        }
    }
}
