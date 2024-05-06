using MindBoxTask_1;

namespace ShapeLibTests {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestPointStruct() {

            var p1 = new Point(1, 1);
            Assert.AreEqual(1.4142135623730951, p1.Magnitude(), 1e-10);

            p1.X = 1; p1.Y = 1;
            var p2 = new Point(2, 2);
            var p3 = p1 + p2;
            Assert.AreEqual(3, p3.X, 1e-10);
            Assert.AreEqual(3, p3.Y, 1e-10);
            p3 -= (p2 + p2);
            Assert.AreEqual(-1, p3.X, 1e-10);
            Assert.AreEqual(-1, p3.Y, 1e-10);

            Assert.AreEqual(2, Point.Dot(p3, p3), 1e-10);
            Assert.AreEqual(-2, Point.Dot(p3, p1), 1e-10);

            p1.X = 0; p1.Y = 0;
            p2.X = 0; p2.Y = 2;
            Assert.AreEqual(2, Point.Distance(p2, p1), 1e-10);
        }

        [TestMethod]
        public void TestCircleShape() {
            var a = new Circle(new Point(0, 0), 1);
            Assert.AreEqual(Math.PI, a.Area());

            a.Radius = 2;
            Assert.AreEqual(Math.PI * 4.0, a.Area(), 1e-10);
        }

        [TestMethod]
        public void TestTriangleShape() {
            var a = new Triangle(new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(0, 0));
            Assert.AreEqual(0.5, a.Area(), 1e-10);
            Assert.AreEqual(true, a.IsRightAngle());
        }
    }
   
}