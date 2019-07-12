using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        private Coordinate _coordinate;
        private Direction _direction;
        private Location _location;

        public void Initialize(Location location, Coordinate coordinate, Direction direction)
        {
            _location = location;
            _coordinate = coordinate;
            _direction = direction;
            if (!ValidateRoverPosition())            
                throw new InvalidOperationException("Location and Rover coordinates not valid");
            
        }
        public bool ValidateRoverPosition() => (_coordinate.X >= 0 && _coordinate.X <= _location.Width) && (_coordinate.Y >= 0 && _coordinate.Y <= _location.Height);

        public void Move(char command)
        {
            if (_coordinate == null)
                throw new InvalidOperationException("Rover hasn't been initiliazed");

            switch (command)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    Go();
                    break;
                default:
                    break;
            }
        }

        private void TurnLeft() => _direction = _direction - 1 < Direction.North ? Direction.West : _direction - 1;

        private void TurnRight() => _direction = _direction + 1 > Direction.West ? Direction.North : _direction + 1;

        private void Go()
        {
            switch (_direction)
            {
                case Direction.North:
                    MoveNorth();
                    break;
                case Direction.East:
                    MoveEast();
                    break;
                case Direction.South:
                    MoveSouth();
                    break;
                case Direction.West:
                    MoveWest();
                    break;
            }
            if (!ValidateRoverPosition())
                throw new InvalidOperationException("Rover Can not exceed the given location");

        }

        private void MoveEast() => _coordinate.X++;
        private void MoveWest() => _coordinate.X--;
        private void MoveNorth() => _coordinate.Y++;
        private void MoveSouth() => _coordinate.Y--;        
        public override string ToString() => $"{_coordinate.X} {_coordinate.Y} {_direction.ToString()[0]}";
    }
}
