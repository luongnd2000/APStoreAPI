using APStore.Models.DAO;
using APStoreAPI.Common;
using APStoreAPI.Models.DAO;
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
    public class BillDetailController : ApiController
    {
        [HttpPost]
        public BaseResponse<BillDetail> CreateBill(List<BillDetail> obj)
        {
            var bill = new BillDAO().GetBill(obj[0].BillID);

            var result1 = new BillDetailDAO().Create(obj,bill.UserName);
            StatusResponse status = result1  ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<BillDetail> response = new BaseResponse<BillDetail>(status, "", null);
            return response;
        }
        [HttpGet]
        public BaseResponse<BillDetail> GetDetail(int id)
        {
            var bill = new BillDetailDAO().GetBillDetail(id);
            foreach(var item in bill)
            {
                var product = new ProductDAO().Get(item.ProductID);
                item.ImagePath = product.ImagePath;
                item.TotalPrice = item.Quantities * product.Price;
                item.ProductName = product.Name;
            }
            StatusResponse status = bill!=null ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<BillDetail> response = new BaseResponse<BillDetail>(status, "", bill);
            return response;
        }
    }
}
