using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public enum LoginStatus
    {
        Success,
        UserNameFail,
        PasswordFail
    }
    public class AdminLoginDAO
    {
        APStoreEntities db = null;
        public AdminLoginDAO()
        {
            db = new APStoreEntities();
        }

        public LoginStatus Login(AdminLogin login)
        {
            var result = db.AdminLogins.SingleOrDefault(x => x.LoginName == login.LoginName);
            if (result == null)
            {
                return LoginStatus.UserNameFail;
            }
            else
            {
                if (result.Pass == login.Pass)
                {
                    return LoginStatus.Success;
                }
                else
                {
                    return LoginStatus.PasswordFail;
                }
            }
        }   
        public AdminLogin GetLogin(string loginName)
        {
            return db.AdminLogins.SingleOrDefault(x => x.LoginName == loginName);
        }
    }
}