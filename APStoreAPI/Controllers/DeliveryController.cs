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
    public class DeliveryController : ApiController
    {
        [HttpGet]
        public BaseResponse<DeliveryDetail> ListAll(string userName)
        {
            var list = new DeliveryDAO().ListAll(userName);
            BaseResponse<DeliveryDetail> response = new BaseResponse<DeliveryDetail>(StatusResponse.Success, "", list);
            return response;
        }
        [HttpPost]
        public BaseResponse<DeliveryDetail> Create(DeliveryDetail obj)
        {
            bool result = new DeliveryDAO().Create(obj);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<DeliveryDetail> response = new BaseResponse<DeliveryDetail>(status, "", null);
            return response;
        }
        [HttpPut]
        public BaseResponse<DeliveryDetail> Update(DeliveryDetail obj)
        {
            bool result = new DeliveryDAO().Update(obj);
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<DeliveryDetail> response = new BaseResponse<DeliveryDetail>(status, "", null);
            return response;
        }
        [HttpDelete]
        public BaseResponse<DeliveryDetail> Delete(string userName,int id)
        {
            var result = new DeliveryDAO().Delete(userName,id);

            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<DeliveryDetail> response = new BaseResponse<DeliveryDetail>(status, "", null);
            return response;
        }
    }
}
