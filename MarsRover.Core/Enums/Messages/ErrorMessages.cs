using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Enums.Messages
{
    public enum ErrorMessages
    {
        UnexpectedError,
        InputCantBeNull,
        WrongCommandType,
        NeedThreeInputForCoordination,
        ShouldBeNumber,
        CoordinationsWereOutOfBounds,
        WrongTypeOfDirection,
        NeedTwoInputForMapRange,
        MapRangesWereOutOfBounds
    }
}
