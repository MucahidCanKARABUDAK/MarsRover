using MarsRover.Core.Enums;
using MarsRover.Core.Enums.Messages;
using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core
{
    public static class Helper
    {
        #region Model Helper

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

            vehicle.Coordination.MapRange = new byte[,] { { xRange, yRange } };

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

        public static ResultModel CheckRequestModel(RequestModel request)
        {
            ResultModel result = new ResultModel() { Type = ResultTypes.Error };
            bool mapRangeFlag = false, coordinationFlag = false, commandsFlag = false;

            #region MapRange

            byte xRange = 0, yRange = 0;
            if (!string.IsNullOrEmpty(request.MapRange))
            {
                if (request.MapRange.Length == 2)
                {
                    if (byte.TryParse(request.MapRange[0].ToString() ,out xRange) && byte.TryParse(request.MapRange[1].ToString(), out yRange))
                    {
                        if (xRange > 0 && yRange > 0)
                            mapRangeFlag = true;
                        else
                            result.Message = GetMessage(ErrorMessages.MapRangesWereOutOfBounds);
                    }
                    else
                        result.Message = GetMessage(ErrorMessages.ShouldBeNumber);
                }
                else
                    result.Message = GetMessage(ErrorMessages.NeedTwoInputForMapRange);
            }
            else
                result.Message = GetMessage(ErrorMessages.InputCantBeNull);

            if (!mapRangeFlag)
                return result;

            #endregion

            #region Coordination

            if (!string.IsNullOrEmpty(request.Coordination))
            {
                if (request.Coordination.Length == 3)
                {
                    byte xAxis = 0, yAxis = 0;
                    if (byte.TryParse(request.Coordination[0].ToString(), out xAxis) && byte.TryParse(request.Coordination[1].ToString(), out yAxis))
                    {
                        if (xAxis > 0 && xAxis <= xRange && yAxis > 0 && yAxis <= yRange)
                        {
                            if (Enum.IsDefined(typeof(Directions), (int)request.Coordination[2]))
                                coordinationFlag = true;
                            else
                                result.Message = GetMessage(ErrorMessages.WrongTypeOfDirection);
                        }
                        else
                            result.Message = GetMessage(ErrorMessages.CoordinationsWereOutOfBounds);
                    }
                    else
                        result.Message = GetMessage(ErrorMessages.ShouldBeNumber);
                }
                else
                    result.Message = GetMessage(ErrorMessages.NeedThreeInputForCoordination);
            }
            else
                result.Message = GetMessage(ErrorMessages.InputCantBeNull);

            if (!coordinationFlag)
                return result;

            #endregion

            #region Commands

            if (!string.IsNullOrEmpty(request.Commands))
            {
                bool commandFlag = true;
                foreach (char command in request.Commands)
                {
                    if (!Enum.IsDefined(typeof(Commands), (int)command))
                        commandFlag = false;
                }

                if (commandFlag)
                    commandsFlag = true;
                else
                    result.Message = GetMessage(ErrorMessages.WrongCommandType);
            }
            else
                result.Message = GetMessage(ErrorMessages.InputCantBeNull);

            if (!commandsFlag)
                return result;

            #endregion

            result.Type = ResultTypes.Success;

            return result;
        }

        #endregion

        #region Message Helper

        public static string GetMessage(InfoMessages infoMessages)
        {
            switch (infoMessages)
            {
                case InfoMessages.FillTheFirstInput:
                    return "Please Enter The Coordinates Range Of The Plateau. (Example Input = 5 5) (Min : 1 - Max : 9)";
                case InfoMessages.FillTheSecondInput:
                    return "Please Enter The Coordinates And Direction Of The Vehicle. (Example Input = 1 2 N) (Min : 1 - Max : 9)";
                case InfoMessages.FillTheThirdInput:
                    return "Please Enter The Commands Of Route. (Example Input = L M L M L M L M M)";
                case InfoMessages.ExitOrContinue:
                    return "Press \"D\" If You Are Done! Press Anything If You Want To Continue.";
                default:
                    return "";
            }
        }

        public static string GetMessage(SuccessMessages successMessages)
        {
            switch (successMessages)
            {
                case SuccessMessages.EverythingsOkay:
                    return "Vehicle Perfectly Landed.. Those Are Coordination Informations Of It";
                default:
                    return "";
            }
            
        }

        public static string GetMessage(FailMessages failMessages)
        {
            switch (failMessages)
            {
                case FailMessages.VehicleWentOffRoute:
                    return "OH NO !! The Vehicle Went Off Route .. We Lost It .. ";
                default:
                    return "";
            }
        }

        public static string GetMessage(ErrorMessages errorMessages)
        {
            switch (errorMessages)
            {
                case ErrorMessages.UnexpectedError:
                    return "Ups.. An Unexpected Error Has Occurred.";
                case ErrorMessages.InputCantBeNull:
                    return "Input Can Not Be Null Or Empty";
                case ErrorMessages.WrongCommandType:
                    return "Not All Command Types Were Correct";
                case ErrorMessages.NeedThreeInputForCoordination:
                    return "Need Three Input For Coordination";
                case ErrorMessages.ShouldBeNumber:
                    return "Expected Input Value In Number Type Was Not Correct";
                case ErrorMessages.CoordinationsWereOutOfBounds:
                    return "Coordinates Must Be More Than Zero And Less Than The Map Range.";
                case ErrorMessages.WrongTypeOfDirection:
                    return "Direction Type Were Not Correct";
                case ErrorMessages.NeedTwoInputForMapRange:
                    return "Need Two Input For Map Ranges";
                case ErrorMessages.MapRangesWereOutOfBounds:
                    return "Map Ranges Must Be More Than Zero.";
                default:
                    return "";
            }

        }

        #endregion
    }
}
