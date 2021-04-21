//using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStoreAPI.Common
{
    public class BaseResponse<T>
    {
        public StatusResponse status;
        public string message;
        public List<T> data;

        public BaseResponse(StatusResponse status, string message, List<T> data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}