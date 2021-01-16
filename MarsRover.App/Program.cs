using MarsRover.App.Controller;
using MarsRover.Core;
using MarsRover.Core.Enums.Messages;
using MarsRover.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestModel request = new RequestModel();
            var container = Startup.ConfigureService();
            var engineController = container.GetRequiredService<EngineController>();

            Console.WriteLine(Helper.GetMessage(InfoMessages.FillTheFirstInput));
            request.MapRange = Console.ReadLine();

            Console.WriteLine(Helper.GetMessage(InfoMessages.FillTheSecondInput));
            request.Coordination = Console.ReadLine();

            Console.WriteLine(Helper.GetMessage(InfoMessages.FillTheThirdInput));
            request.Commands = Console.ReadLine();

            ResultModel result = engineController.Start(request);

            Console.WriteLine(result.Message);
        }
    }
}
