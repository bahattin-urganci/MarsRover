using MarsRover.Command;
using MarsRover.Utilities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AcceptanceTests
    {

        [TestCase(5, 5, 1, 2, Direction.North, "LMLMLMLMM", "1 3 N")]
        [TestCase(5, 5, 3, 3, Direction.East, "MMRMMRMRRM", "5 1 E")]
        public void Project_Validation_Seperated(int locationWidth, int locationHeight, int x, int y, Direction startDirection, string command, string expected)
        {
            IRoverCommand _commander = new Mock<RoverCommand>(command).Object;
            var rover = new Rover();
            rover.Initialize(new Location(locationWidth, locationHeight), new Coordinate { X = x, Y = y }, startDirection);
            _commander.SetReceiver(rover);
            _commander.Execute();

            Assert.AreEqual(rover.ToString(), expected);
        }
        [TestCase]
        public void Project_Validation_Combined()
        {
            Location location = new Location(5, 5);
            string[] commands = new string[2] { "LMLMLMLMM", "MMRMMRMRRM" };
            Coordinate[] coordinates = new Coordinate[2] { new Coordinate { X = 1, Y = 2 }, new Coordinate { X = 3, Y = 3 } };
            Direction[] directions = new Direction[2] { Direction.North, Direction.East };
            Rover[] rovers = new Rover[2] { new Rover(), new Rover() };
            string[] expectedResults = new string[2] { "1 3 N", "5 1 E" };

            for (int i = 0; i < rovers.Length; i++)
            {
                IRoverCommand _commander = new RoverCommand(commands[i]);
                rovers[i].Initialize(location, coordinates[i], directions[i]);
                _commander.SetReceiver(rovers[i]);
                _commander.Execute();
                Assert.AreEqual(rovers[i].ToString(), expectedResults[i]);
            }

        }
    }
}
