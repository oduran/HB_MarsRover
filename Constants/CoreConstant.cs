using System;
using System.Collections.Generic;
using System.Text;

namespace HB_MarsRover.Constants
{
    public class CoreConstant
    {
        public const string SurfaceSplit = " ";
        public const int SurfaceSplitLength = 2;
        public const string SurfaceExceptionError= "Error : Your input is invalid surface area.";
        public const string RoverPositionExceptionError= "Error : Its position must be in surface area and it must contains the direction which is N,W,S,E";
        public const string RoverMovementExceptionError= "Error : Your input must includes just L,M and R characters. Ex: LMLMLRMRMLMLM";
        public const string RoverGoneOutOfSurface= "Rover is going to outer space. Its position X:{0} Y:{1} Direction:{2}";
        public const string RoverInSurface = "Rover position X:{0} Y:{1} Direction:{2}";
        public const string PositionSplit = " ";
        public const int PositionSplitLength = 3;
        public static readonly string[] DirectionsAllowedCharacters = { "N","W","S","E"};
        public static readonly string[] MovementAllowedCharacters = { "L","M","R"};
    }
}
