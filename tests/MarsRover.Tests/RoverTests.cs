using NUnit.Framework;
using Moq;
using MarsRover.Command;
using MarsRover;
using MarsRover.Utilities;
using System;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [TestCase(Direction.North, 'R', Direction.East)]
        [TestCase(Direction.East, 'R', Direction.South)]
        [TestCase(Direction.South, 'R', Direction.West)]
        [TestCase(Direction.West, 'R', Direction.North)]
        public void Turning_By_Start_Direction_Check(Direction start, char to, Direction expected)
        {
            var rover = new Rover();

            rover.Initialize(new Location(0, 0), new Coordinate(), start);
            rover.Move(to);
            Assert.AreEqual(rover.ToString().Split(' ')[2], expected.ToString()[0].ToString());
        }

        [TestCase(5, 5, 0, 0, Direction.North, 'R', 'M', 'L', 'M', 1, 1, Direction.North)]
        [TestCase(5, 5, 2, 3, Direction.South, 'M', 'M', 'R', 'M', 1, 1, Direction.West)]
        [TestCase(5, 5, 4, 2, Direction.West, 'R', 'R', 'R', 'R', 4, 2, Direction.West)]
        public void Movement_By_CommandSet(int locationWidth, int locationHeight, int startX, int startY, Direction startDirection, char firstMove, char secondMove, char thirdMove, char fourthMove, int expectedX, int expectedY, Direction expectedDirection)
        {
            var rover = new Rover();
            rover.Initialize(new Location(locationWidth, locationHeight), new Coordinate { X = startX, Y = startY }, startDirection);
            rover.Move(firstMove);
            rover.Move(secondMove);
            rover.Move(thirdMove);
            rover.Move(fourthMove);

            Assert.AreEqual(rover.ToString(), $"{expectedX} {expectedY} {expectedDirection.ToString()[0].ToString()}");
        }

        [Test]
        public void Movement_Without_Initialized_Should_Throw_Invalid_Operation_Exception()
        {
            var rover = new Rover();
            Assert.Throws<InvalidOperationException>(() => rover.Move('R'), "Rover hasn't been initiliazed");
        }

        [TestCase(5, 5, 3, 6, Direction.North)]
        public void Rover_Invalid_Position_Should_Throw_Invalid_Operation_Exception(int locationWidth, int locationHeight, int x, int y, Direction direction)
        {
            var rover = new Rover();
            Assert.Throws<InvalidOperationException>(() => rover.Initialize(new Location(locationWidth, locationHeight), new Coordinate() { X = x, Y = y }, direction), "Location and Rover coordinates not valid");
        }

        [TestCase(5, 5, 2, 3, Direction.North, "2 3 N")]
        public void Rover_Result_String_Should_Be_Equal(int locationWidth, int locationHeight, int x, int y, Direction direction, string expected)
        {
            var rover = new Rover();
            rover.Initialize(new Location(locationWidth, locationHeight), new Coordinate { X = x, Y = y }, direction);
            Assert.AreEqual(rover.ToString(), expected);
        }
    }
}