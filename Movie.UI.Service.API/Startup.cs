using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movie.Business.Manager.ServiceCollectionExtensions;
using Movie.Data.MSSQL.Context.Entityframework;
using Movie.Data.MSSQL.Validation.ServiceCollectionExtensions;
using Movie.Mapper.ServicesCollectionExtesions;
using Movie.UI.Service.API.Extensions;
using Newtonsoft.Json;
namespace Movie.UI.Service.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secretKey = Configuration.GetSection("AppSettings:SecretKey").Value.ToString();

            services.AddDbContext<MovieDbContext>(op =>
              op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddControllers()
                .AddMSSQLValidator(services)
                .AddNewtonsoftJson(opt=>
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie.UI.Service.API", Version = "v1" });
            });

            services.AddAutoMapper();
            services.AddBusinessManager();
            services.AddAuthenticationServices(secretKey);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie.UI.Service.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
