using Microsoft.Extensions.DependencyInjection;
using Movie.Business.Manager.Infrastructure;
using Movie.Data.MSSQL.Repository.Entityframework;
using Movie.Data.MSSQL.Repository.Infrastructure;

namespace Movie.Business.Manager.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddBusinessManager(
            this IServiceCollection services)
        {
            services.AddScoped<IGenreManager, GenreManager>();
            services.AddScoped<IFilmManager, FilmManager>();

            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IGenreManager, GenreManager>();

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IActorManager, ActorManager>();

            return services;
        }
    }
}
