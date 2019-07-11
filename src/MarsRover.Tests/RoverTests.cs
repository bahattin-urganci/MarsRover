using NUnit.Framework;
using Moq;
using MarsRover.Command;
using MarsRover;
using MarsRover.Model;

namespace Tests
{
    public class RoverTests
    {
        private IRoverCommand _commanderMock;
        
        [SetUp]
        public void Setup()
        {

            _commanderMock = new Mock<RoverCommand>("MMRMMRMRRM").Object;
            
        }

        [Test]
        public void Test1()
        {

            _commanderMock.Rover = new Rover(new Coordinate { X = 3, Y = 3 }, Direction.East);

            _commanderMock.Execute();
            Assert.AreEqual("5 1 E", _commanderMock.Rover.ToString());
            
        }
    }
}