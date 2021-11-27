using HB_MarsRover.Constants;
using HB_MarsRover.Data.Models;
using HB_MarsRover.Extensions;
using HB_MarsRover.Interfaces;
using HB_MarsRover.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HB_MarsRover.Services
{
    public class SurfaceService : ISurfaceService
    {
        public ResultItem<SurfaceModel> CreateSurface(string surfaceArea)
        {
            ResultItem<SurfaceModel> res = new ResultItem<SurfaceModel>();

            string[] pos = surfaceArea.Split(CoreConstant.SurfaceSplit);

            // correct input value check
            // dimension size must be 2
            // first element must be int and higher than 0
            // second element must be int and higher than 0

            if ((pos.Length == CoreConstant.SurfaceSplitLength) &&
                (pos[0].ToNullableInt() != null && pos[0].ToInt() > 0) &&
                (pos[1].ToNullableInt() != null && pos[1].ToInt() > 0))
            {

                SurfaceModel oSurface = new SurfaceModel();
                oSurface.Width = pos[0]; //width
                oSurface.Height = pos[1]; //height

                res.IsSuccess = true;
                res.Data = oSurface;
                res.Message = null;

                return res;
            }


            res.IsSuccess = false;
            res.Data = null;
            res.Message = CoreConstant.SurfaceExceptionError;

            return res;

        }
    }
}
