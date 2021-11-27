using HB_MarsRover.Constants;
using HB_MarsRover.Data.Enums;
using HB_MarsRover.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HB_MarsRover.Helpers
{
    public static class DirectionHelper
    {
        //  Turn by movement direction from last direction 
        public static int TurnByMovement(int lastDirection,char movement)
        {
            switch (movement)
            {
                case (char)MovementEnum.Left: return TurnLeft(lastDirection);
                case (char)MovementEnum.Right: return TurnRight(lastDirection);
                default: return 0;
            }
        }

        //  Turn left direction 
        private static int TurnLeft(int lastDirection)
        {
            return (lastDirection + 270) % 360;
        }

        //  Turn right direction 
        private static int TurnRight(int lastDirection)
        {
            return (lastDirection + 90) % 360;
        }
    }
}
