using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Models
{
    public class RequestModel
    {
        private string _mapRange, _coordination, _commands;
        public string MapRange
        {
            get { return _mapRange; }
            set { _mapRange = value.Replace(" ", string.Empty).ToUpper(); }
        }
        public string Coordination
        {
            get { return _coordination; }
            set { _coordination = value.Replace(" ", string.Empty).ToUpper(); }
        }
        public string Commands
        {
            get { return _commands; }
            set { _commands = value.Replace(" ", string.Empty).ToUpper(); }
        }
    }
}
