using HB_MarsRover.Data.Interfaces;
using System;

namespace HB_MarsRover.Data.Models
{
    // Generic id
    public abstract class IntEntity : IBaseModel<int>
    {
        public virtual int Id { get; set; }
    }

    public abstract class BaseModel : IBaseModel<Guid>
    {
        public virtual Guid Id { get; set; }
    }
}