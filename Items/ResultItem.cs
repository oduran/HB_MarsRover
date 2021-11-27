using System;
using System.Collections.Generic;
using System.Text;

namespace HB_MarsRover.Items
{
    public class ResultItem<T> where T : class, new()
    {
        public bool IsSuccess { get; set; }
        public T Data{ get; set; }
        public string Message{ get; set; }

        public ResultItem()
        {
            this.IsSuccess = false;
            this.Message = null;
            this.Data = null;
        }
    }
}
