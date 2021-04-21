using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{ 
    public class UserLoginDAO
    {
        APStoreEntities db = null;
        public UserLoginDAO()
        {
            db = new APStoreEntities();
        }
        public LoginStatus Login(UserLogin login)
        {
            var result = db.UserLogins.SingleOrDefault(x => x.Name == login.Name);
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
        public bool Register(UserLogin login)
        {
            var result = db.UserLogins.SingleOrDefault(x => x.Name == login.Name);
            if (result != null)
            {
                return false;
            }
            else
            {
                db.UserLogins.Add(login);
                db.SaveChanges();
                return true;
            }
        }
        public UserLogin GetLogin(string loginName)
        {
            return db.UserLogins.SingleOrDefault(x => x.Name == loginName);
        }


    }
}