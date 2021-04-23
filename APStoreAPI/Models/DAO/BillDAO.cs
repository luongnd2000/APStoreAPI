using APStoreAPI.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStoreAPI.Models.DAO
{
    public class BillDAO
    {
        APStoreEntities db = null;
        public BillDAO()
        {
            db = new APStoreEntities();
        }
        public bool Create(Bill obj)
        {
            try
            {
                obj.CreatedDate = DateTime.Now;
                db.Bills.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Bill> GetListBill(int page ,int number)
        {
            List<Bill> list = db.Bills.OrderBy(x => x.ID).ToPagedList(page, number).ToList();
            return list;
        }
    }
}