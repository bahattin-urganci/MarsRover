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
            if (!IsValidInitialization())            
                throw new InvalidOperationException("Location and Rover coordinates not valid");
            
        }
        public bool IsValidInitialization() => (_coordinate.X >= 0 && _coordinate.X <= _location.Width) && (_coordinate.Y >= 0 && _coordinate.Y <= _location.Height);

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
                    Move();
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft() => _direction = _direction - 1 < Direction.North ? Direction.West : _direction - 1;

        public void TurnRight() => _direction = _direction + 1 > Direction.West ? Direction.North : _direction + 1;

        public void Move()
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
        }

        public void MoveEast() => _coordinate.X++;

        public void MoveWest() => _coordinate.X--;
        public void MoveNorth() => _coordinate.Y++;
        public void MoveSouth() => _coordinate.Y--;        
        public override string ToString() => $"{_coordinate.X} {_coordinate.Y} {_direction.ToString()[0]}";
    }
}
