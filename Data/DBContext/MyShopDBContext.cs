using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Data.Models;
namespace Data.DBContext
{
    public class MyShopDBContext : DbContext
    {
        public MyShopDBContext(): base("MyShopConectionString")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}