using System;
using System.Collections.Generic;
using System.Text;

namespace Gaez.BakeryHouse.Models
{
    public enum ResultCode
    {
        Error,
        Success
    }

    public class ReturnInfo
    {
        public ReturnInfo()
        {
            Result = ResultCode.Success;
            Message = "";
        }
        public ResultCode Result { get; set; }
        public string Message { get; set; }
    }
}
