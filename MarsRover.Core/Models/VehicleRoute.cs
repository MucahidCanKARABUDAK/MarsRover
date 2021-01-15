using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Models
{
    public class VehicleRoute
    {
        public VehicleRoute(string mapRange, string coordination, string commands)
        {
            this.Commands = commands;
            if (this.Vehicle == null)
                this.Vehicle = Helper.CreateVehicleModel(coordination, mapRange);
        }
        public string Commands { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
