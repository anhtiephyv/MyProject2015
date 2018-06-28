using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Base;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface ICategoryService
    {

        IEnumerable<Category> GetAll();
    }
    public class CategoryService : ICategoryService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CategoryService()
        {
        }
        public IEnumerable<Category> GetAll()
        {

            var check = unitOfWork.CategoryRepository.Get().ToList();
            return check;
        }
    }
}
