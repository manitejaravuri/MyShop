using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.DataAccess.inMemory
{
    public class productCategoryRepositary
    {
        ObjectCache cache = MemoryCache.Default;
        List<productCategory> productCategories;
        private string Id;

        public  productCategoryRepositary()
        {
            productCategories = cache["productCategories"] as List<productCategory>;

            if(productCategories==null)
            {
                productCategories = new List<productCategory>();
            }
        }
        public void commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(productCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(productCategory productCategory)
        {
            productCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
             if(productCategoryToUpdate!=null)
            {
                productCategoryToUpdate = productCategory;
            }
             else
            {
                throw new Exception("product category no found");
            }
        }
        public  productCategory Find(string Id)
        {
            productCategory productCategory = productCategories.Find(p => p.Id == Id);

            if(productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("product category no found");
            }
        }
        public IQueryable<productCategory>Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string Id)
        {
            productCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if(productCategoryToDelete!=null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("product no Found");
            }

        }
    }
}
