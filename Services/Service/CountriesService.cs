using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Base;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Data.Repository;
namespace Service.Service
{
    public interface ICountryService
    {
        IEnumerable<Country> Get(
          Expression<Func<Country, bool>> filter = null,
          string orderBy = null,
          string sortDir = null,
          string includeProperties = "");
        Country GetByID(int id);
        void Create(Country entity);
        void Delete(int id);
        void Delete(Country entityToDelete);
        void Update(Country entityToUpdate);
        IEnumerable<Country> GetPaging( int page = 0, int pageSize = 20,
           Expression<Func<Country, bool>> filter = null,
           string orderBy = null,
          string sortDir = null,
           string includeProperties = "");
        void Save();
    }
    public class CountryService : ICountryService
    {
        private ICountryRepository _CountryRepository;
        private IUnitOfWork _unitofWork;

        public CountryService(ICountryRepository CountryRepository, IUnitOfWork unitofWork)
        {
            this._CountryRepository = CountryRepository;
            this._unitofWork = unitofWork;
        }

        public IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null, string orderBy = null, string sortDir = null, string includeProperties = "")
        {
            return _CountryRepository.Get(filter, orderBy, sortDir, includeProperties);
        }

        public Country GetByID(int id)
        {
            return _CountryRepository.GetByID(id);
        }

        public void Create(Country entity)
        {
            _CountryRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _CountryRepository.Delete(id);
        }

        public void Delete(Country entityToDelete)
        {
            _CountryRepository.Delete(entityToDelete);
        }

        public void Update(Country entityToUpdate)
        {
            _CountryRepository.Update(entityToUpdate);
        }

        public IEnumerable<Country> GetPaging( int page = 0, int pageSize = 20,
           Expression<Func<Country, bool>> filter = null,
          string orderBy = null,
          string sortDir = null,
           string includeProperties = "")
        {
            IEnumerable<Country> result = _CountryRepository.GetPaging(page, pageSize, filter, orderBy, sortDir, includeProperties);
       //     totalRow = result.ToList().Count;
            return result;
        }

        public void Save()
        {
            _unitofWork.Save();
        }
    }
}
