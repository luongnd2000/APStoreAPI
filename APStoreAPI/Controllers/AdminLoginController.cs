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
    public class AdminLoginController : ApiController
    {
        [HttpGet]
        public BaseResponse<AdminLogin> Login(AdminLogin obj)
        {
            AdminLoginDAO dao = new AdminLoginDAO();
            LoginStatus result = dao.Login(obj);
            AdminLogin admin=null;
            if (result == LoginStatus.Success) { 
                admin = dao.GetLogin(obj.LoginName);
            }
            var list = new List<AdminLogin>();
            list.Add(admin);
            BaseResponse<AdminLogin> response = new BaseResponse<AdminLogin>(StatusResponse.Success,result+"",list);
            return response;
        } 
    }
}
