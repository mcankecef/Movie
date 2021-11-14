using Movie.Business.Manager.Infrastructure;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Manager
{
    public class UserManager :IUserManager
    {
        public readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int userId)
        {
            return _userRepository.Get(x => x.Id == userId);
        }

        public async Task<bool> AnyAsync(string email)
        {
            return await _userRepository.Any(x => x.Email == email);
        }

        public User Save(User user)
        {
            _userRepository.Update(user);
            return GetUser(user.Id);
        }
    }
}
