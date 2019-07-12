using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model
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
