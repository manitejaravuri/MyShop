using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Myshop.Core.Models;

namespace Myshop.DataAccess.inMemory
{
    public class productRepositary
    {
        ObjectCache cache = MemoryCache.Default;

        List<product> products = new List<product>();

        public productRepositary()
        {
            products = cache["products"] as List<product>;

            if(products==null)
            {
                products = new List<product>();
            }
        }
        public void commit()
        {
            cache["products"] = products;
        }
        public void insert(product p)
        {
            products.Add(p);
        }
        public void update(product product)
        {
            product productToupdate = products.Find(p => p.id == product.id);
            if(productToupdate!=null)
            {
                productToupdate = product;
            }
            else
            {
                throw new Exception("product no found");
            }

        }
        public product find(string id)
        {
            product product = products.Find(p => p.id == id);

            if(product!=null)
            {
                return product;
            }
            else
            {
                throw new Exception("product no found");
            }
        }
        public IQueryable<product> collection()
        {
            return products.AsQueryable();
        }
       public void Delete (string id)
        {
            product productToDelete = products.Find(p => p.id == id);

            if(productToDelete!=null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("product no found");
            }
        }
    }
}
