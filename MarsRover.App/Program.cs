using MarsRover.App.Controller;
using MarsRover.Core.Models;
using MarsRover.Services.Engine;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Startup.ConfigureService();
            var engineController = container.GetRequiredService<EngineController>();

            var mapRange = Console.ReadLine();
            var coordination = Console.ReadLine();
            var commands = Console.ReadLine();

            Vehicle vehicle = engineController.Start(new VehicleRoute(mapRange,coordination,commands));

            Console.WriteLine(vehicle.Coordination.Xaxis.ToString() + vehicle.Coordination.Yaxis.ToString() + (char)vehicle.Direction);
        }
    }
}
