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
    public interface IUsersRepository : IGenericRepository<ApplicationUser>
    {

    }
    public class UsersRepository : GenericRepository<ApplicationUser>, IUsersRepository
    {
        public UsersRepository(MyShopDBContext DBcontext)
            : base(DBcontext)
        {
        }
    }
}
