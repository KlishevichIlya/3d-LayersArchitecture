using BLL.Services;
using Common.Validators;
using DAL;
using DAL.Repositories;
using DAL.UnitOfWork;
using DataAccess.EFCore.UnitOfWork;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProjectRepository, ProjectService>();
            services.AddTransient<IDeveloperRepository, DeveloperService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddFluentValidation(fv => {                
                fv.RegisterValidatorsFromAssemblyContaining<DeveloperDTOValidator>(); // Scoped
            });          
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "PL", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Presentation layer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}