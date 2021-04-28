using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public class CartDAO
    {
        APStoreEntities db = null;
        public CartDAO()
        {
            db = new APStoreEntities();
        }
        public List<Cart> ListAll(string username)
        {
            return db.Carts.Where(x=>x.UserName==username).ToList();
        }

        public bool AddProduct(Cart obj)
        {
            var cart = db.Carts.SingleOrDefault(x => x.UserName == obj.UserName && x.ProductID == obj.ProductID);
            if (cart != null) {
                int? quantities = cart.Quantities + obj.Quantities;
                cart.Quantities = quantities;
                db.SaveChanges();
                return true;
            }
            else {
                try
                {
                    db.Carts.Add(obj);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool Update(Cart obj)
        {
            try
            {
                var temp = db.Carts.SingleOrDefault(dis => dis.ProductID == obj.ProductID&&dis.UserName==obj.UserName);
                if (temp != null)
                {
                    temp.Quantities = obj.Quantities;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string username, int productId)
        {
            try
            {
                var cart = db.Carts.Where(x=>x.ProductID==productId&&x.UserName==username).ToList()[0];
                db.Carts.Remove(cart);
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