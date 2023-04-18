using System.Numerics;
using WinFormsApp1;
namespace BallTests
{
    public class BallSimTests
    {
        BallManager manager;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BallConstruction()
        {
            Ball ball = new Ball();
            Assert.IsNotNull(ball);
            Assert.That(new Vector2(0, 0), Is.EqualTo(ball.Pos));
            Assert.That(new Vector2(0, 0), Is.EqualTo(ball.Speed));
            Assert.That(200, Is.EqualTo(ball.Size));
        }
        [Test]
        public void ManagerTest() 
        {
            manager = new BallManager();
            Assert.That(manager, Is.Not.Null);
            Ball ball = new Ball(new Vector2(50,100), 50);
            manager.AddBall(ball);
            Ball ball2 = (Ball)manager.GetBall(0);
            Assert.That(ball, Is.EqualTo(ball2));
        }
    }
}