using APStore.Models.DAO;
using APStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStoreAPI.Models.DAO
{
    public class BillDetailDAO
    {
        APStoreEntities db = null;
        public BillDetailDAO()
        {
            db = new APStoreEntities();
        }
        public bool Create(List<BillDetail> objs,string UserName)
        {
            try
            {
                foreach(var item in objs)
                {
                    var result = new CartDAO().Delete(UserName, item.ProductID);
                    if (result)
                    {
                        db.BillDetails.Add(item);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<BillDetail> GetBillDetail(int id)
        {
            var list = db.BillDetails.Where(x => x.BillID == id);
            return list.ToList();
        }
    }
}