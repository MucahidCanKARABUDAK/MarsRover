using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Models
{
    public class RequestModel
    {
        public string MapRange { get; set; }
        public string Coordination { get; set; }
        public string Commands { get; set; }
    }
}
