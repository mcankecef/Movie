using Microsoft.Extensions.DependencyInjection;
using Movie.Data.MSSQL.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Repository.Entityframework.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDal(
            this IServiceCollection services)
        {
            services.AddScoped<IGenreRepository, GenreRepository>();

            return services;
        }
    }
}
