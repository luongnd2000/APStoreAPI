using APStoreAPI.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APStore.Models.DAO
{
    public class ProductCategoryDAO
    {
        APStoreEntities db = null;
        public ProductCategoryDAO()
        {
            db = new APStoreEntities();
        }
        public List<ProductCategory> GetListProduct(int page,int number )
        {
            List<ProductCategory> list=db.ProductCategories.OrderBy(x=>x.ID).ToPagedList(page,number).ToList();
            return list;
        }
        public bool Create(ProductCategory category)
        {
            try
            {
                db.ProductCategories.Add(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ProductCategory Get(int id)
        {
            return db.ProductCategories.Find(id);
        }
        public bool Update(ProductCategory category)
        {
            try
            {
                var temp = db.ProductCategories.SingleOrDefault(cate=>cate.ID==category.ID);
                if (temp != null)
                {
                    temp.Name = category.Name;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      
    }
}