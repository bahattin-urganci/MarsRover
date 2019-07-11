using NUnit.Framework;
using Moq;
using MarsRover.Command;
using MarsRover;
using MarsRover.Model;

namespace Tests
{
    [TestFixture]
    public class RoverTests
    {
        private IRoverCommand _commander;

        [SetUp]
        public void Setup()
        {
        }


        [TestCase(1, 2, Direction.North, "LMLMLMLMM", "1 3 N")]
        [TestCase(3, 3, Direction.East, "MMRMMRMRRM", "5 1 E")]
        public void Project_Validation(int x, int y, Direction startDirection, string command, string expected)
        {
            _commander = new Mock<RoverCommand>(command).Object;
            var rover = new Rover();
            rover.Initialize(new Coordinate { X = x, Y = y }, startDirection);
            _commander.SetReceiver(rover);
            _commander.Execute();

            Assert.AreEqual(rover.ToString(), expected);

        }

        [TestCase(Direction.North, 'R', Direction.East)]
        [TestCase(Direction.East, 'R', Direction.South)]
        [TestCase(Direction.South, 'R', Direction.West)]
        [TestCase(Direction.West, 'R', Direction.North)]
        public void Turning_By_Start_Direction_Check(Direction start, char to, Direction expected)
        {
            var rover = new Rover();

            rover.Initialize(new Coordinate(), start);
            rover.Move(to);
            Assert.AreEqual(rover.ToString().Split(' ')[2], expected.ToString()[0].ToString());
            
        }


    }
}