using APStoreAPI.Models.DAO;
using APStoreAPI.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public class ProductDAO
    {
        APStoreEntities db = null;
        public ProductDAO()
        {
            db = new APStoreEntities();
        }
        public List<Product> GetListProduct(int page, int number)
        {
            List<Product> list = db.Products.OrderBy(x => x.ID).ToPagedList(page, number).ToList();
            return list;
        }
        public List<Product> ListAll(int idFilter, string searchString)
        {
            try
            {
                if (idFilter == 0)
                {
                    if (string.IsNullOrEmpty(searchString))
                    {
                        return db.Products.ToList();

                    }
                    else
                    {
                        return db.Products.Where(x => x.Name.Contains(searchString)).ToList();
                    }
                }

                else
                {
                    if (string.IsNullOrEmpty(searchString))
                    {
                        return db.Products.Where(x => x.CategoryID == idFilter).ToList();
                    }
                    else
                    {
                        return db.Products.Where(x => x.CategoryID == idFilter && x.Name.Contains(searchString)).ToList();
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Create(Product obj)
        {
            try
            {
                db.Products.Add(obj);
                db.SaveChanges();
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
                var category = db.Products.Find(id);
                db.Products.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Product Get(int id)
        {
            try
            {
                return db.Products.Find(id);

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Update(Product obj)
        {
            try
            {
                var temp = db.Products.SingleOrDefault(dis => dis.ID == obj.ID);
                if (temp != null)
                {
                    if (obj.Name != null) temp.Name = obj.Name;
                    if (obj.ImagePath != null) temp.ImagePath = obj.ImagePath;
                    if (obj.Price > 0) temp.Price = obj.Price;
                    if (obj.CategoryID > 0) temp.CategoryID = obj.CategoryID;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public decimal GetRevenue(int id)
        {
            var product = Get(id);
            List<BillDetail> listbill = db.BillDetails.Where(x => x.ProductID == id).ToList();
            decimal revenue = 0;
            foreach (var item in listbill)
            {
                revenue += product.Price * item.Quantities;
            }
            return revenue;

        }
        public int GetQuantities(int id)
        {
            var product = Get(id);
            List<BillDetail> listbill = db.BillDetails.Where(x => x.ProductID == id).ToList();
            int revenue = 0;
            foreach (var item in listbill)
            {
                revenue += item.Quantities;
            }
            return revenue;
        }
        public List<Product> GetRank()
        {
            List<Product> list = ListAll(0, "");
            foreach (var item in list)
            {
                item.Total = GetRevenue(item.ID);
                var category = new ProductCategoryDAO().Get(item.CategoryID);
                item.CategoryName = category.Name;
                item.TotalQuantities = GetQuantities(item.ID);
            }
            list = list.OrderByDescending(x=>x.Total).ToList();
            return list;
        }
    }
}