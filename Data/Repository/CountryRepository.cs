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
        bool checkCodeExist(string Code, int? ID);
    }
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(MyShopDBContext DBcontext)
            : base(DBcontext)
        {
        }
        public bool checkCodeExist(string Code, int? ID)
        {
            if (!ID.HasValue)
            {
                return DbContext.Country.Any(x => x.CountryCronyms == Code);
            }
            return DbContext.Country.Any(x => x.CountryCronyms == Code && x.CountryID != ID);
        }
    }
}
