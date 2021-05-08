using APStore.Models.DAO;
using APStoreAPI.Common;
using APStoreAPI.Models.Entities;
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
    public class RankProductController : ApiController
    {
        [HttpGet]
        public BaseResponse<Product> GetAll()
        {
            var list = new ProductDAO().GetRank();
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", list);
            return response;
        }
        
    }
}
