using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager.Infrastructure
{
    public interface IAuthManager
    {
        User Register(User user);
        User Login(User user);
        Task<bool> Any(string email);
    }
}
