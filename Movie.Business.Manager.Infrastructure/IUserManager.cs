using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Infrastructure
{
    public interface IUserManager
    {
        User GetUser(int userId);
        User Save(User user);
    }
}
