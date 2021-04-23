using APStore.Common;
using APStore.Models.DAO;
using APStoreAPI.Common;
using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace APStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public BaseResponse<Product> Get(int page,int number)
        {
            var list = new ProductDAO().GetListProduct(page, number);
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpGet]
        public BaseResponse<Product> Get(int id)
        {
            var list = new List<Product>();
            list.Add(new ProductDAO().Get(id));
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpGet]
        public BaseResponse<Product> GetAll()
        {
            var list = new ProductDAO().ListAll();
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", list);
            return response;
        }
        
        [HttpPost]
        public BaseResponse<Product> Create(Product product)
        {
            var result= new ProductDAO().Create(product);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", null);
            return response;
        }
        [HttpPut]
        public BaseResponse<Product> Update(Product product)
        {
            var result = new ProductDAO().Update(product);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", null);
            return response;
        }
        [HttpDelete]
        public BaseResponse<Product> Delete(int id)
        {
            var result = new ProductDAO().Delete(id);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Product> response = new BaseResponse<Product>(StatusResponse.Success, "", null);
            return response;
        }
    }
}
