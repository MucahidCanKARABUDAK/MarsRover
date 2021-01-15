using MarsRover.Core.Enums;
using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core
{
    public static class Helper
    {
        public static Vehicle CreateVehicleModel(string coordination, string mapRange)
        {
            Vehicle vehicle = new Vehicle();

            #region MapRange

            byte xRange = 0, yRange = 0;

            if (mapRange.Length >= 2)
            {
                Byte.TryParse(mapRange[0].ToString(), out xRange);
                Byte.TryParse(mapRange[1].ToString(), out yRange);
            }

            vehicle.Coordination.MapRange = new byte[xRange, yRange];

            #endregion

            #region Coordination

            byte xAxis = 0, yAxis = 0;

            if (coordination.Length >= 3)
            {
                Byte.TryParse(coordination[0].ToString(), out xAxis);
                Byte.TryParse(coordination[1].ToString(), out yAxis);

                #region Direction

                switch (coordination[2])
                {
                    case (char)Directions.North:
                        vehicle.Direction = Directions.North;
                        break;
                    case (char)Directions.South:
                        vehicle.Direction = Directions.South;
                        break;
                    case (char)Directions.West:
                        vehicle.Direction = Directions.West;
                        break;
                    case (char)Directions.East:
                        vehicle.Direction = Directions.East;
                        break;
                    default:
                        vehicle.Direction = Directions.North;
                        break;
                }

                #endregion
            }

            vehicle.Coordination.Xaxis = xAxis;
            vehicle.Coordination.Yaxis = yAxis;

            #endregion

            return vehicle;

        }
    }
}
