using HB_MarsRover.Data.Enums;
using HB_MarsRover.Data.Models;
using HB_MarsRover.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HB_MarsRover.Interfaces
{
    public interface IRoverService
    {
        ResultItem<RoverModel> SetRoverPosition(RoverModel rover , string position,SurfaceModel surface);
        ResultItem<RoverModel> SetRoverMovement(RoverModel rover , string movement, SurfaceModel surface);
        ResultItem<RoverModel> MoveRover(RoverModel rover , int lastDirection);
        ResultItem<RoverModel> GetRoverPositionMessage(RoverModel rover , SurfaceModel surface);
    }
}
