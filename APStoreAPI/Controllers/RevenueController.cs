using APStoreAPI.Common;
using APStoreAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APStoreAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class RevenueController : ApiController
    {
        [HttpGet]
        public BaseResponse<decimal> GetAll()
        {
            var list = new BillDAO().GetRevenueMonth();
            BaseResponse<decimal> response = new BaseResponse<decimal>(StatusResponse.Success, "", list.ToList());
            return response;
        }
    }
}
