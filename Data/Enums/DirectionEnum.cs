using System.ComponentModel;

namespace HB_MarsRover.Data.Enums
{
    public enum DirectionEnum
    {
        [Description("N")]
        North = 0,

        [Description("E")]
        East = 90,
        
        [Description("S")]
        South = 180,

        [Description("W")]
        West = 270,
    }
}
