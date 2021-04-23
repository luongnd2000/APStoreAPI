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
    public class UserController : ApiController
    {
        [HttpGet]
        public BaseResponse<UserLogin> Login(UserLogin obj)
        {
            UserLoginDAO dao = new UserLoginDAO();
            LoginStatus result = dao.Login(obj);
            UserLogin user = null;
            if (result == LoginStatus.Success)
            {
                user = dao.GetLogin(obj.Name);
            }
            var list = new List<UserLogin>();
            list.Add(user);
            BaseResponse<UserLogin> response = new BaseResponse<UserLogin>(StatusResponse.Success, result + "", list);
            return response;
        }
        [HttpPost]
        public BaseResponse<UserLogin> Register(UserLogin obj)
        {
            UserLoginDAO dao = new UserLoginDAO();
            bool result = dao.Register(obj);
            UserLogin user = null;
            if (result == true)
            {
                user = dao.GetLogin(obj.Name);
            }
            var list = new List<UserLogin>();
            var status = result ? StatusResponse.Success : StatusResponse.Fail;
            list.Add(user);
            BaseResponse<UserLogin> response = new BaseResponse<UserLogin>(status, result + "", list);
            return response;    
        }

    }
}
