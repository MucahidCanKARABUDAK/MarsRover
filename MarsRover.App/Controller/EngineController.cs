using MarsRover.Core.Models;
using MarsRover.Services.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.App.Controller
{
    public class EngineController
    {
        readonly IEngineService _engineService;
        public EngineController(IEngineService engineService)
        {
            _engineService = engineService;
        }

        public ResultModel Start(RequestModel request)
        {

            return _engineService.Start(new VehicleRoute(request));
        }
    }
}
