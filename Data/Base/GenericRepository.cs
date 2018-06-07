using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;
using Data.DBContext;
using System.Data.Entity;
using System.Linq.Expressions;
namespace Data.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        //Class variables are declared for the database context and for the entity set that the repository is instantiated for
        internal MyShopDBContext context;
        internal DbSet<TEntity> dbSet;
        //The constructor accepts a database context instance and initializes the entity set variable:
        public GenericRepository(MyShopDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        protected IUnitOfWork UnitOfWork
        {
            get;
            private set;
        }
        protected MyShopDBContext DbContext
        {
            get { return context ?? (context = UnitOfWork.Init()); }
        }
        //The Get method uses lambda expressions to allow the calling code to specify a filter condition and a column to order the results by, and a string parameter lets the caller provide a comma-delimited list of navigation properties for eager loading
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            /* The code Expression<Func<TEntity, bool>> filter means the caller will provide a lambda expression based on the TEntity type, and this expression will return a Boolean value. For example, if the repository is instantiated for the Student entity type, the code in the calling method might specify student => student.LastName == "Smith" for the filter parameter.

The code Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy also means the caller will provide a lambda expression. But in this case, the input to the expression is an IQueryable object for the TEntity type. The expression will return an ordered version of that IQueryable object. For example, if the repository is instantiated for the Student entity type, the code in the calling method might specify q => q.OrderBy(s => s.LastName) for the orderBy parameter.

The code in the Get method creates an IQueryable object and then applies the filter expression if there is one*/
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            //Next it applies the eager-loading expressions after parsing the comma-delimited list
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            //Finally, it applies the orderBy expression if there is one and returns the results; otherwise it returns the results from the unordered query
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        // Get By ID
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        //Create
        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }
        //Delete
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        //Update
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}