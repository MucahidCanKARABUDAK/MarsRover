using MarsRover.App.Controller;
using MarsRover.Services.Engine;
using MarsRover.Services.Physics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.App
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddSingleton<Movement, EngineService>()
                .AddSingleton<IEngineService, EngineService>()
                .AddSingleton<EngineController>()
                .BuildServiceProvider();

            return provider;
        }
    }
}
