using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Model;

namespace MarsRover.Command
{
    public class RoverCommand : IRoverCommand
    {
        private string _command;
        private Rover _rover;
        public RoverCommand(string command)
        {
            _command = command;
        }
        public void Execute()
        {
            foreach (var item in _command)
            {
                _rover.Move(item);
            }
        }

        public void SetReceiver(Rover rover)
        {
            _rover = rover;
        }
    }
}
