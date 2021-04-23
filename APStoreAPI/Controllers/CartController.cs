using APStore.Models.DAO;
using APStoreAPI.Common;
using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APStoreAPI.Controllers
{
    public class CartController : ApiController
    {
        [HttpGet]
        public BaseResponse<Cart> ListAll(string userName)
        {
            var list = new CartDAO().ListAll(userName);
            BaseResponse<Cart> response = new BaseResponse<Cart>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpPost]
        public BaseResponse<Cart> Add(Cart cart)
        {
            bool result = new CartDAO().AddProduct(cart);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Cart> response = new BaseResponse<Cart>(status, "", null);
            return response;
        }
        [HttpDelete]
        public BaseResponse<Cart> Delete(string userName,int productID)
        {
            bool result = new CartDAO().Delete(userName,productID);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Cart> response = new BaseResponse<Cart>(status, "", null);
            return response;
        }
    }
}
