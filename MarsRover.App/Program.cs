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
            try
            {
                var container = Startup.ConfigureService();
                var engineController = container.GetRequiredService<EngineController>();
                RequestModel request;

                while (true)
                {
                    request = new RequestModel();

                    Console.WriteLine(Helper.GetMessage(InfoMessages.FillTheFirstInput));
                    request.MapRange = Console.ReadLine();

                    Console.WriteLine(Helper.GetMessage(InfoMessages.FillTheSecondInput));
                    request.Coordination = Console.ReadLine();

                    Console.WriteLine(Helper.GetMessage(InfoMessages.FillTheThirdInput));
                    request.Commands = Console.ReadLine();

                    Console.WriteLine("\n" + engineController.Start(request).Message + "\n");

                    Console.WriteLine(Helper.GetMessage(InfoMessages.ExitOrContinue));
                    if (Console.ReadLine().ToUpper() == "D")
                        Environment.Exit(-1);
                }
            }
            catch
            {
                //We should log the error in here
                Console.WriteLine(Helper.GetMessage(ErrorMessages.UnexpectedError));
            }
        }
    }
}
