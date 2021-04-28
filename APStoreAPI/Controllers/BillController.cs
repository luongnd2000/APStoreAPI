using APStoreAPI.Common;
using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APStoreAPI.Models.DAO
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class BillController : ApiController
    {
        [HttpPost] 
        public BaseResponse<Bill> CreateBill(Bill obj)
        {
            var result1 = new BillDAO().Create(obj);
            StatusResponse status = result1 !=null? StatusResponse.Success : StatusResponse.Fail;
            List<Bill> list = new List<Bill>();
            if (result1 != null) list.Add(result1);
            BaseResponse<Bill> response = new BaseResponse<Bill>(status, "", list);
            return response;
        }
    }
}
