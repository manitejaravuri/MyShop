using Myshop.Core.Models;
using System.Data.Entity;

namespace Myshop.DataAccess.SQL
{
    public  class Datacontext:DbContext
    {
        public Datacontext():base ("Defaultconnection")
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<productCategory> productCategories { get; set; }

    }

    public class Product
    {
    }
}

