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
        [HttpGet]
        public BaseResponse<Bill> ListAll()
        {
            var list = new BillDAO().GetAllBill();
            foreach(var item in list)
            {
                var deliverydetail = new DeliveryDAO().Get(item.DeliveryDetailID);
                item.Name = deliverydetail.Name;
                item.Phone = deliverydetail.PhoneNumber;
                item.Adress = deliverydetail.Adress;
                double value = 0;
                decimal price= new BillDetailDAO().TotalPrice(item.ID);
                if (!string.IsNullOrEmpty(item.DiscountCode))
                {
                    price = price - price *(decimal) (new DiscountDAO().Get(item.DiscountCode).Value);
                    value = (new DiscountDAO().Get(item.DiscountCode).Value )* 100;
                }
                item.DiscountValue = value;
                item.TotalPrice = price;
            }
            StatusResponse status = list != null ? StatusResponse.Success : StatusResponse.Fail;
            BaseResponse<Bill> response = new BaseResponse<Bill>(status, "", list);
            return response;
        }
    }
}
