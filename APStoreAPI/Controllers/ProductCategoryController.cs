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

namespace APStoreAPI.Models.DAO
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class ProductCategoryController : ApiController
    {
        [HttpGet]
        public BaseResponse<ProductCategory> GetProductCategory(int page ,int number)
        {
            var list = new ProductCategoryDAO().GetListProduct(page,number);
            BaseResponse<ProductCategory> response = new BaseResponse<ProductCategory>(StatusResponse.Success,"", list);
            return response;
        }
        [HttpGet]
        public BaseResponse<ProductCategory> GetProductCategory()
        {
            var list = new ProductCategoryDAO().ListAll();
            BaseResponse<ProductCategory> response = new BaseResponse<ProductCategory>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpPost]
        public BaseResponse<ProductCategory> CreateProductCategory(ProductCategory obj)
        {
            bool result = new ProductCategoryDAO().Create(obj);
            StatusResponse status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<ProductCategory> response = new BaseResponse<ProductCategory>(status, "", null);
            return response;
        }
        [HttpDelete]
        public BaseResponse<ProductCategory> DeleteProductCategory(int id)
        {
            bool result = new ProductCategoryDAO().Delete(id);
            StatusResponse status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<ProductCategory> response = new BaseResponse<ProductCategory>(status, "", null);
            return response;
        }
        [HttpPut]
        public BaseResponse<ProductCategory> UpdateProductCategory(ProductCategory obj)
        {
            bool result = new ProductCategoryDAO().Update(obj);
            StatusResponse status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<ProductCategory> response = new BaseResponse<ProductCategory>(status, "", null);
            return response;
        }
    }
}
