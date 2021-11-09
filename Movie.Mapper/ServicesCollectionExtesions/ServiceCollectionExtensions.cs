using Microsoft.Extensions.DependencyInjection;
using Movie.Mapper.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Mapper.ServicesCollectionExtesions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(
            this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                cfg.AddProfile<EntityToDTOMapperProfile>();

                cfg.AddProfile<ViewModelToDTOMapperProfile>();
            });
            return services;
        }
    }
}
