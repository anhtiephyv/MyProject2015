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
    public interface IApplicationUsersService
    {
        IEnumerable<ApplicationUser> Get(
          Expression<Func<ApplicationUser, bool>> filter = null,
          string orderBy = null,
          string sortDir = null,
          string includeProperties = "");
        ApplicationUser GetByID(int id);
        void Create(ApplicationUser entity);
        void Delete(int id);
        void Delete(ApplicationUser entityToDelete);
        void Update(ApplicationUser entityToUpdate);
        IEnumerable<ApplicationUser> GetPaging(out int totalRow, int page = 0, int pageSize = 20,
           Expression<Func<ApplicationUser, bool>> filter = null,
           string orderBy = null,
          string sortDir = null,
           string includeProperties = "");
        void Save();
    }
    public class ApplicationUsersService : IApplicationUsersService
    {
        private IUsersRepository _usersRepository;
        private IUnitOfWork _unitofWork;

        public ApplicationUsersService(IUsersRepository UsersRepository, IUnitOfWork unitofWork)
        {
            this._usersRepository = UsersRepository;
            this._unitofWork = unitofWork;
        }

        public IEnumerable<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> filter = null, string orderBy = null, string sortDir = null, string includeProperties = "")
        {
            return _usersRepository.Get(filter, orderBy, sortDir, includeProperties);
        }

        public ApplicationUser GetByID(int id)
        {
            return _usersRepository.GetByID(id);
        }

        public void Create(ApplicationUser entity)
        {
            _usersRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _usersRepository.Delete(id);
        }

        public void Delete(ApplicationUser entityToDelete)
        {
            _usersRepository.Delete(entityToDelete);
        }

        public void Update(ApplicationUser entityToUpdate)
        {
            _usersRepository.Update(entityToUpdate);
        }

        public IEnumerable<ApplicationUser> GetPaging(out int totalRow, int page = 0, int pageSize = 20,
           Expression<Func<ApplicationUser, bool>> filter = null,
          string orderBy = null,
          string sortDir = null,
           string includeProperties = "")
        {
            IEnumerable<ApplicationUser> result = _usersRepository.GetPaging(page, pageSize, filter, orderBy, sortDir, includeProperties);
            totalRow = result.ToList().Count;
            return result;
        }

        public void Save()
        {
            _unitofWork.Save();
        }
    }
}
