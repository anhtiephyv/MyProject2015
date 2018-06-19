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
    public interface ICategoriesRepository : IGenericRepository<Category>
    {

    }
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(MyShopDBContext DBcontext)
            : base(DBcontext)
        {
        }
    }
}
