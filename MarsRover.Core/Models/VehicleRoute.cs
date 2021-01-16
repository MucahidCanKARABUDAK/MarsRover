using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Models
{
    public class VehicleRoute
    {
        public VehicleRoute(RequestModel requestModel)
        {
            this.Commands = requestModel.Commands;
            if (this.Vehicle == null)
                this.Vehicle = Helper.CreateVehicleModel(requestModel.Coordination, requestModel.MapRange);
        }
        public string Commands { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
