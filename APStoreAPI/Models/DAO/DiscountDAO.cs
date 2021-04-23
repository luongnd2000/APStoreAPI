using APStoreAPI.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public class DiscountDAO
    {
        APStoreEntities db = null;
        public DiscountDAO()
        {
            db = new APStoreEntities();
        }
        public List<Discount> GetListDiscount(int page, int number)
        {
            List<Discount> list = db.Discounts.OrderBy(x => x.ID).ToPagedList(page, number).ToList();
            return list;
        }
        public List<Discount> ListAll()
        {
            return db.Discounts.ToList();
        }
        public bool Create(Discount discount)
        {
            try
            {
                db.Discounts.Add(discount);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Discount Get(int id)
        {
            return db.Discounts.Find(id);
        }
        public bool Update(Discount discount)
        {
            try
            {
                var temp = db.Discounts.SingleOrDefault(dis=>dis.ID == discount.ID);
                if (temp != null)
                {
                    if(discount.Code!=null) temp.Code = discount.Code;
                    if (discount.NameDisplay != null) temp.NameDisplay = discount.NameDisplay;
                    if (discount.Value> 0) temp.Value = discount.Value;
                    if (discount.StartDate != null) temp.StartDate = discount.StartDate;
                    if (discount.EndDate != null) temp.EndDate = discount.EndDate;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.Discounts.Find(id);
                db.Discounts.Remove(category);
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