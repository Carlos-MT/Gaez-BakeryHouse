using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Utils
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
