using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Command
{
    public interface IRoverCommand : ICommand
    {    
        Rover Rover { get; set; }        
    }
}
