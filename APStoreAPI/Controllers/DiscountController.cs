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
    public class DiscountController : ApiController
    {
        [HttpGet]
        public BaseResponse<Discount> GetProductCategory(int page, int number)
        {
            var list = new DiscountDAO().GetListDiscount(page, number);
            BaseResponse<Discount> response = new BaseResponse<Discount>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpGet]
        public BaseResponse<Discount> GetProductCategory()
        {
            var list = new DiscountDAO().ListAll();
            BaseResponse<Discount> response = new BaseResponse<Discount>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpPost]
        public BaseResponse<Discount> CreateProductCategory(Discount obj)
        {
            bool result = new DiscountDAO().Create(obj);
            StatusResponse status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Discount> response = new BaseResponse<Discount>(status, "", null);
            return response;
        }
        [HttpDelete]
        public BaseResponse<Discount> DeleteProductCategory(int id)
        {
            bool result = new DiscountDAO().Delete(id);
            StatusResponse status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Discount> response = new BaseResponse<Discount>(status, "", null);
            return response;
        }
        [HttpPut]
        public BaseResponse<Discount> UpdateProductCategory(Discount obj)
        {
            bool result = new DiscountDAO().Update(obj);
            StatusResponse status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Discount> response = new BaseResponse<Discount>(status, "", null);
            return response;
        }
    }
}
