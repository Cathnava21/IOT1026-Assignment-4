using Assignment;
using Assignment.InterfaceCommand;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void PropertiesTest()
        {
            Robot robot1 = new();
            Assert.AreEqual(robot1.NumCommands, 6);
            var expectedCommands = 10;
            Robot robot2 = new(expectedCommands);
            Assert.AreEqual(robot2.NumCommands, expectedCommands);

            Assert.AreEqual(robot1.IsPowered, false);
            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);

            Assert.AreEqual(robot1.X, 0);
            // Moves the robot can move even though it is off!!
            // This is very bad! Not good encapsulation
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);

            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);
        }
        [TestMethod]
        public void CommandTest()
        {
            Robot testRobot = new Robot(1);
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.LoadCommand(new OnCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, true);
        }
        [TestMethod]
        public void OnTest()
        {
            Robot testRobot = new Robot();
            testRobot.IsPowered = true;
            Assert.AreEqual(testRobot.IsPowered, true);
            testRobot.IsPowered = false;
            Assert.AreEqual(testRobot.IsPowered, false);
        }
        [TestMethod]
        public void NorthCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new NorthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 0);

            testRobot.IsPowered = true;
            testRobot.LoadCommand(new NorthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 1);
            testRobot.LoadCommand(new NorthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 2);
        }
        [TestMethod]
        public void SOUTHCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.Y, 0);
            testRobot.LoadCommand(new SouthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, 0);

            testRobot.IsPowered = true;
            testRobot.LoadCommand(new SouthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, -1);
            testRobot.LoadCommand(new SouthCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.Y, -2);
        }
        [TestMethod]
        public void EastCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.LoadCommand(new EastCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 0);

            testRobot.IsPowered = true;
            testRobot.LoadCommand(new EastCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 1);
            testRobot.LoadCommand(new EastCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 2);
        }
        [TestMethod]
        public void WestCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.AreEqual(testRobot.X, 0);
            testRobot.LoadCommand(new WestCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, 0);

            testRobot.IsPowered = true;
            testRobot.LoadCommand(new WestCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, -1);
            testRobot.LoadCommand(new WestCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.X, -2);
        }
    }
}
