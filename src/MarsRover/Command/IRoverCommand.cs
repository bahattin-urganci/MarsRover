using MarsRover.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface IRoverCommand : ICommand
    {
        void ValidateCommand(string command);
        void SetReceiver(Rover rover);
    }
}
