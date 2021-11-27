using HB_MarsRover.Data.Enums;
using HB_MarsRover.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB_MarsRover.Data.Models
{
    public class RoverModel : BaseModel
    {
        public DirectionEnum Direction{ get; set; }
        public string Movement{ get; set; }
        public int XPosition{ get; set; }
        public int YPosition{ get; set; }
        public RoverModel()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
