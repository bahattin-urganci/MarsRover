using MarsRover.Command;
using MarsRover.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {

        [TestCase(5,5,1, 2, Direction.North, "LMLMLMLMM", "1 3 N")]
        [TestCase(5,5,3, 3, Direction.East, "MMRMMRMRRM", "5 1 E")]
        public void Project_Validation(int locationWidth,int locationHeight,int x, int y, Direction startDirection, string command, string expected)
        {
            IRoverCommand _commander = new Mock<RoverCommand>(command).Object;
            var rover = new Rover();
            rover.Initialize(new Location(locationWidth,locationHeight),new Coordinate { X = x, Y = y }, startDirection);
            _commander.SetReceiver(rover);
            _commander.Execute();

            Assert.AreEqual(rover.ToString(), expected);
        }
    }
}
