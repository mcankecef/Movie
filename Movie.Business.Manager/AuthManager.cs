using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Business.Manager.Hash;
using Movie.Business.Manager.Infrastructure;

namespace Movie.Business.Manager
{
    public class AuthManager:IAuthManager
    {
        private readonly IAuthRepository _authRepository;

        public AuthManager(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public User Register(User user)
        {
            user.Password = HashMD5.Create(user.Password);
            return _authRepository.Add(user);
        }

        public User Login(User user)
        {
            var _user = _authRepository.Get(x => x.Email == user.Email);

            if (_user == null)
                return null;

            if (HashMD5.Create(user.Password) != _user.Password)
                return null;

            return _user;
        }

        public async Task<bool> Any(string email)
        {
            if (await _authRepository.Any(x => x.Email == email))
                return true;

            return false;
        }
    }
}
