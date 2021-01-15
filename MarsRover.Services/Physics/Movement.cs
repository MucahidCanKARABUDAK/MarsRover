using MarsRover.Core.Enums;
using MarsRover.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Physics
{
    public abstract class Movement
    {
        protected abstract Coordination MoveForward(Vehicle Vehicle);
        protected abstract Directions TurnLeft(Directions direction);
        protected abstract Directions TurnRight(Directions direction);
    }
}
