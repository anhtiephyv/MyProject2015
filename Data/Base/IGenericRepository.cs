using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Data.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // Get by expression
        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        //Get by id
        TEntity GetByID(object id);
        //Create
       void Create(TEntity entity);
        //Delete
       void Delete(object id);
        // Delete by entity
       void Delete(TEntity entityToDelete);
        //Update
        void Update(TEntity entityToUpdate);
    }
}
