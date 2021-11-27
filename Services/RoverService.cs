using HB_MarsRover.Constants;
using HB_MarsRover.Data.Enums;
using HB_MarsRover.Data.Models;
using HB_MarsRover.Extensions;
using HB_MarsRover.Helpers;
using HB_MarsRover.Interfaces;
using HB_MarsRover.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB_MarsRover.Services
{
    public class RoverService : IRoverService
    {
        public ResultItem<RoverModel> SetRoverPosition(RoverModel rover, string position, SurfaceModel surface)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();

            string[] pos = position.Split(CoreConstant.PositionSplit);
            
            //position must have 3 characters 
            
            if(pos.Length != CoreConstant.PositionSplitLength)
            {
                res.IsSuccess = false;
                res.Data = null;
                res.Message = CoreConstant.RoverPositionExceptionError;

                return res;
            }

            // correct input value check
            // first element must be int and lower or equal than surface width
            // second element must be int and lower or equal than surface height
            // third element must be character and contains in DirectionsAllowedCharacters

            if ((pos[0].ToNullableInt() != null && pos[0].ToInt() <= surface.Width.ToInt()) &&
               (pos[1].ToNullableInt() != null && pos[1].ToInt() <= surface.Height.ToInt()) &&
                CoreConstant.DirectionsAllowedCharacters.Contains(pos[2]))
            {
                var direction = EnumHelper.GetValueFromDescription<DirectionEnum>(pos[2]);

                rover.XPosition = pos[0].ToInt();
                rover.YPosition = pos[1].ToInt();
                rover.Direction = direction; 

                res.IsSuccess = true;
                res.Data = rover;
                res.Message = null;

                return res;
            }
            else //invalid inputs
            {
                res.IsSuccess = false;
                res.Data = null;
                res.Message = CoreConstant.RoverPositionExceptionError;

                return res;
            }
        }

        public ResultItem<RoverModel> SetRoverMovement(RoverModel rover, string movement, SurfaceModel surface)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();

            //check input valid characters 

            if (movement.ToUpperArray().HasIncludeCharArray(CoreConstant.MovementAllowedCharacters))
            {
                rover.Movement = movement;

                res.IsSuccess = true;
                res.Data = rover;

                return res;
            }

            res.Message = CoreConstant.RoverMovementExceptionError;

            return res;
        }
        public ResultItem<RoverModel> MoveRover(RoverModel rover, int lastDirection)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();
            switch (lastDirection)
            {
                case (int)DirectionEnum.North: return GoToNorth(rover);
                case (int)DirectionEnum.East: return GoToEast(rover);
                case (int)DirectionEnum.West: return GoToWest(rover);
                case (int)DirectionEnum.South: return GoToSouth(rover);
                default: return res;
            }
        }
        
        public ResultItem<RoverModel> GetRoverPositionMessage(RoverModel rover, SurfaceModel surface)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();
            
            if (rover.XPosition > surface.Width.ToInt() || rover.YPosition > surface.Height.ToInt())
            {
                res.Message = string.Format(CoreConstant.RoverGoneOutOfSurface,rover.XPosition,rover.YPosition,rover.Direction);
                return res;
            }

            res.Message = string.Format(CoreConstant.RoverInSurface, rover.XPosition, rover.YPosition, rover.Direction);
            return res;
        }

        private ResultItem<RoverModel> GoToSouth(RoverModel rover)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();
            rover.XPosition = rover.XPosition ;
            rover.YPosition = rover.YPosition - 1;
            rover.Direction = DirectionEnum.South;

            res.IsSuccess = true;
            res.Data = rover;

            return res;
        }

        private ResultItem<RoverModel> GoToWest(RoverModel rover)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();
            rover.XPosition = rover.XPosition - 1;
            rover.YPosition = rover.YPosition;
            rover.Direction = DirectionEnum.West;

            res.IsSuccess = true;
            res.Data = rover;

            return res;
        }

        private ResultItem<RoverModel> GoToEast(RoverModel rover)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();
            rover.XPosition = rover.XPosition + 1;
            rover.YPosition = rover.YPosition;
            rover.Direction = DirectionEnum.East;

            res.IsSuccess = true;
            res.Data = rover;

            return res;
        }

        private ResultItem<RoverModel> GoToNorth(RoverModel rover)
        {
            ResultItem<RoverModel> res = new ResultItem<RoverModel>();
            rover.XPosition = rover.XPosition;
            rover.YPosition = rover.YPosition + 1;
            rover.Direction = DirectionEnum.North;

            res.IsSuccess = true;
            res.Data = rover;

            return res;
        }
    }
}
