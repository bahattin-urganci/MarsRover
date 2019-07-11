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

        public Rover(Coordinate coordinate, Direction direction)
        {
            _coordinate = coordinate;
            _direction = direction;
        }

        public void Move(char command)
        {
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
                default:
                    break;
            }
        }

        public void MoveEast() => _coordinate.X++;

        public void MoveWest() => _coordinate.X--;
        public void MoveNorth() => _coordinate.Y++;
        public void MoveSouth() => _coordinate.Y--;

        public override string ToString()
        {
            return $"{_coordinate.X} {_coordinate.Y} {_direction.ToString()[0]}";
        }
    }
}
