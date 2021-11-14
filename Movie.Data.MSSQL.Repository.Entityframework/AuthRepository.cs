using Microsoft.EntityFrameworkCore;
using Movie.Data.MSSQL.Context.Entityframework;
using Movie.Data.MSSQL.Entity;
using Movie.Data.MSSQL.Repository.Entityframework.Base;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Entityframework
{
    public class AuthRepository : EntityframeworkRepositoryBase<User, int>, IAuthRepository
    {
        public AuthRepository(MovieDbContext context) : base(context)
        {
        }

        public User Add(User entity)
        {
            using (var context = new MovieDbContext())
            {
                var _entity = context.Entry(entity);
                _entity.State = EntityState.Added;
                context.SaveChanges();
                return _entity.Entity;
            }
        }

        public async Task<bool> Any(Expression<Func<User, bool>> filter)
        {

            using (var context = new MovieDbContext())
            {
                return await context.Set<User>().Where(filter).AnyAsync();
            }

        }

        public void Delete(User entity)
        {
            using (var context = new MovieDbContext())
            {
                var _entity = context.Entry(entity);
                _entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (var context = new MovieDbContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new MovieDbContext())
            {
                return filter == null ? context.Set<User>().ToList() : context.Set<User>().Where(filter).ToList();
            }
        }

        public User Update(User entity)
        {
            using (var context = new MovieDbContext())
            {
                var _entity = context.Entry(entity);
                _entity.State = EntityState.Modified;
                context.SaveChanges();
                return _entity.Entity;
            }
        }
    }
}
