using HB_MarsRover.Data.Models;
using HB_MarsRover.Items;

namespace HB_MarsRover.Interfaces
{
    public interface ISurfaceService
    {
        ResultItem<SurfaceModel> CreateSurface(string surfaceArea);
    }
}
