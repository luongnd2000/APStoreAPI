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
    public class CartController : ApiController
    {
        [HttpGet]
        public BaseResponse<Cart> ListAll(string userName)
        {
            var list = new CartDAO().ListAll(userName);
            foreach(var item in list)
            {
                var product = new ProductDAO().Get(item.ProductID);
                var category = new ProductCategoryDAO().Get(product.CategoryID);
                item.NameDisplay = product.Name;
                item.Price = product.Price;
                item.Category = category.Name;
                item.ImagePath = product.ImagePath;
                item.TotalPrice = item.Price * (decimal) item.Quantities;
            }
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
        [HttpPut]
        public BaseResponse<Cart> Update(Cart obj)
        {
            bool result = new CartDAO().Update(obj);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Cart> response = new BaseResponse<Cart>(status, "", null);
            return response;
        }
    }
}
