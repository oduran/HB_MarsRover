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
        public static int TurnByMovement(int lastDirection,int rotate)
        {
            return (lastDirection + rotate) % 360; // rotate : 90 or 270
        }
    }
}
