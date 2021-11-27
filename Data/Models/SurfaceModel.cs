using System;
using System.Collections.Generic;
using System.Text;

namespace HB_MarsRover.Data.Models
{
    public class SurfaceModel : BaseModel
    {
        public SurfaceModel()
        {
            this.Id = Guid.NewGuid();
            this.Rovers = new List<RoverModel>();
        }
        public string Width{ get; set; }
        public string Height{ get; set; }
        public List<RoverModel> Rovers{ get; set; }
    }
}
