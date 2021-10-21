using System;
using System.Text.RegularExpressions;

namespace MarsRover.Rovers
{
    public class RoverCommand : IRoverCommand
    {
        private readonly string _command;
        private Rover _rover;
        public RoverCommand(string command)
        {
            ValidateCommand(command);
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

        public void ValidateCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException("command", "Command can not be null");

            Regex rx = new Regex(@"^[LMR]*$");

            if (!rx.IsMatch(command))
                throw new InvalidOperationException("Command is not valid");

        }
    }
}
