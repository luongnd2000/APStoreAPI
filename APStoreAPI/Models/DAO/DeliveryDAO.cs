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
        public DeliveryDetail Get(int id)
        {
            return db.DeliveryDetails.SingleOrDefault(x => x.ID == id);
        }
        public DeliveryDetail Create(DeliveryDetail obj)
        {
            try
            {
                var delivery=db.DeliveryDetails.Add(obj);
                db.SaveChanges();
                return delivery;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Update(DeliveryDetail obj)
        {
            try
            {
                var temp = db.DeliveryDetails.SingleOrDefault(dis => dis.ID == obj.ID);
                if (temp != null)
                {
                    if (!string.IsNullOrEmpty(obj.Name)) temp.Name = obj.Name;
                    if (!string.IsNullOrEmpty(obj.PhoneNumber)) temp.PhoneNumber = obj.PhoneNumber;
                    if (!string.IsNullOrEmpty(obj.Adress)) temp.Adress = obj.Adress;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string userName,int id)
        {
            try
            {
                var temp = db.DeliveryDetails.FirstOrDefault(x => x.ID == id && x.UserName == userName); 
                db.DeliveryDetails.Remove(temp);
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