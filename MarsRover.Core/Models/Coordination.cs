using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Models
{
    public class Coordination : Map
    {
        public Coordination(byte xAxis, byte yAxis)
        {
            this.Xaxis = xAxis;
            this.Yaxis = yAxis;
        }
        public byte Xaxis { get; set; }
        public byte Yaxis { get; set; }
    }
}
