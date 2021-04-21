using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public class DeliveryDAO
    {
        APStoreEntities db = null;
        public DeliveryDAO()
        {
            db = new APStoreEntities();
        }
        public List<DeliveryDetail> ListAll(string username)
        {
            return db.DeliveryDetails.Where(x => x.UserName == username).ToList();
        }
        public bool Create(DeliveryDetail obj)
        {
            try
            {
                db.DeliveryDetails.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}