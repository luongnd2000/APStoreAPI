using APStore.Models.DAO;
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
        public Bill GetBill(int id)
        {
            return db.Bills.SingleOrDefault(x => x.ID == id);
        }
        public Bill Create(Bill obj)
        {
            try
            {
                obj.CreatedDate = (DateTime)DateTime.Now;
                Bill bill = db.Bills.Add(obj);
                db.SaveChanges();
                return bill;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Bill> GetListBill(int page, int number)
        {
            List<Bill> list = db.Bills.OrderBy(x => x.ID).ToPagedList(page, number).ToList();
            return list;
        }
        public List<Bill> GetAllBill()
        {
            List<Bill> list = db.Bills.OrderBy(x => x.CreatedDate).ToList();
            return list;
        }
        public decimal [] GetRevenueMonth()
        {
            decimal[] month = new decimal[13];
            List<Bill> bills = GetAllBill();
            for (int i = 0; i < 12; i++)
            {
                month[i] = 0;
            }
            foreach (var item in bills)
            {
                List<BillDetail> list = new BillDetailDAO().GetBillDetail(item.ID);
                decimal revenue=0;
                foreach(var detail in list)
                {
                    var product = new ProductDAO().Get(detail.ProductID);
                    revenue += detail.Quantities * product.Price;
                }
                var index = item.CreatedDate.Month;
                month[index-1]+=revenue;
            }
            return month;
        }
    }
}