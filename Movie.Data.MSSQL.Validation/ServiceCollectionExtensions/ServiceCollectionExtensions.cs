using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Movie.Data.MSSQL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data.MSSQL.Validation.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddMSSQLValidator(
            this IMvcBuilder mvcBuilder,
            IServiceCollection services
            )
        {
            services.AddTransient<IValidator<Directory>,DirectoryValidator>();
            services.AddTransient<IValidator<Actor>, ActorValidator>();
            services.AddTransient<IValidator<Film>, FilmValidator>();
            services.AddTransient<IValidator<Genre>, GenreValidator>();
            services.AddTransient<IValidator<User>, UserValidator>();

            mvcBuilder.AddFluentValidation();

            return mvcBuilder;

        }
    }
}
