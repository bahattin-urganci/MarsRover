using MarsRover.Command;

namespace MarsRover.Rovers
{
    public interface IRoverCommand : ICommand
    {
        void ValidateCommand(string command);
        void SetReceiver(Rover rover);
    }
}
