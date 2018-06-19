using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DBContext;
using Data.Models;
using Data.Base;
namespace Data.Repository
{
    public interface IroductRepository : IGenericRepository<Product>
    {

    }
    public class ProductRepository : GenericRepository<Product>, IroductRepository
    {
        public ProductRepository(MyShopDBContext DBcontext)
            : base(DBcontext)
        {
        }
    }
}
