using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Model;

namespace MarsRover.Command
{
    public class RoverCommand : IRoverCommand
    {
        private string _command;

        public RoverCommand(string command)
        {
            _command = command;
        }

        public Rover Rover { get; set; }

        public void Execute()
        {
            foreach (var item in _command)
            {
                Rover.Move(item);
            }
        }

    }
}
