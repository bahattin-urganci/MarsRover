using MarsRover.Command;
using MarsRover.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverCommandTests
    {
        
        [TestCase("")]
        [TestCase(null)]
        public void Command_Should_Throw_Exception_When_Command_String_IsNullOrEmpty(string command)
        {
            Assert.Throws<ArgumentNullException>(() => new RoverCommand(command), "Command can not be null");
        }

        [TestCase(5, 5, 1, 2, Direction.North, "LMLMLMLMMLMLMMMMMMMMMMMMMMMMMMMMMMMMMMM")]
        public void Command_Does_Exceeding_The_Limit_Of_Location_Should_Throw_Invalid_Operation_Exception(int locationWidth,int locationHeight,int startX,int startY,Direction direction,string command)
        {
            var roverCommand = new RoverCommand(command);
            var rover = new Rover();
            rover.Initialize(new Location(locationWidth, locationHeight), new Coordinate { X = startX, Y = startY }, direction);
            roverCommand.SetReceiver(rover);
            Assert.Throws<InvalidOperationException>(()=>roverCommand.Execute(), "Rover Can not exceed the given location");

        }
    }

    
}
