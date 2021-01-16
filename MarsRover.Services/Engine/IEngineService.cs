﻿using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Engine
{
    public interface IEngineService
    {
        public ResultModel Start(VehicleRoute vehicleRoute);
    }
}
