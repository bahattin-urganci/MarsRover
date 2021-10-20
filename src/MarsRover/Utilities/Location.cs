using MarsRover.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Utilities
{
    public class Location
    {
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Location(int width,int height)
        {
            Width = width;
            Height = height;
        }
    }
}
