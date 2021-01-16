using MarsRover.Core.Enums;
using MarsRover.Core.Models;
using MarsRover.Services.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Engine
{
    public class EngineService : Movement, IEngineService
    {
        public ResultModel Start(VehicleRoute vehicleRoute)
        {
            Vehicle vehicle = vehicleRoute.Vehicle;

            foreach (char command in vehicleRoute.Commands)
            {
                switch (command)
                {
                    case (char)Commands.Move:
                        vehicle.Coordination = MoveForward(vehicle);
                        break;
                    case (char)Commands.Right:
                        vehicle.Direction = TurnRight(vehicle.Direction);
                        break;
                    case (char)Commands.Left:
                        vehicle.Direction = TurnLeft(vehicle.Direction);
                        break;
                    default:
                        //Do nothing. I believe it is just better than throw exception if it is wrong type of command. 
                        break;
                }
            }

            return new ResultModel();
        }
        protected override Coordination MoveForward(Vehicle vehicle)
        {
            Coordination coordination = vehicle.Coordination;

            switch (vehicle.Direction)
            {
                case Directions.North:
                    coordination.Yaxis++;
                    break;
                case Directions.South:
                    coordination.Yaxis--;
                    break;
                case Directions.East:
                    coordination.Xaxis++;
                    break;
                case Directions.West:
                    coordination.Xaxis--;
                    break;
            }
            return coordination;
        }
        protected override Directions TurnLeft(Directions direction)
        {
            switch (direction)
            {
                case Directions.North:
                    return Directions.West;
                case Directions.South:
                    return Directions.East;
                case Directions.East:
                    return Directions.North;
                case Directions.West:
                    return Directions.South;
                default:
                    return direction;
            }
        }
        protected override Directions TurnRight(Directions direction)
        {
            switch (direction)
            {
                case Directions.North:
                    return Directions.East;
                case Directions.South:
                    return Directions.West;
                case Directions.East:
                    return Directions.South;
                case Directions.West:
                    return Directions.North;
                default:
                    return direction;
            }
        }
    }
}
