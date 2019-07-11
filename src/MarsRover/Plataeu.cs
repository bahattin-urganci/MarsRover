using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plataeu
    {
        public Coordinate PlataeuSize { get; private set; }
        public Plataeu(Coordinate coordinate)
        {
            PlataeuSize = coordinate;
        }
    }
}
