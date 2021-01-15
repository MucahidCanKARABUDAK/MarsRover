using MarsRover.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Models
{
    public class Vehicle
    {
        public Directions Direction { get; set; }
        public Coordination Coordination { get; set; }
    }
}
