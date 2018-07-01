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
    public interface ICountryRepository : IGenericRepository<Country>
    {

    }
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(MyShopDBContext DBcontext)
            : base(DBcontext)
        {
        }
    }
}
