using MarsRover.Core.Enums;
using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Interfaces
{
    public interface IMovementService
    {
        public Direction TurnToLeft(Direction direction);
        public Direction TurnToRight(Direction direction);
        public Coordination MoveForward(Coordination coordination);
    }
}
