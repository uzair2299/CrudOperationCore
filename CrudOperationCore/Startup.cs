using CrudOperationCore.Interfaces;
using CrudOperationCore.Models;
using CrudOperationCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrudOperationCore
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
            //The AddDbContext extension method sets up the services provided by Entity Framework Core for the database context class
                        services.AddDbContext<ApplicationContext>(options =>
                   options.UseSqlServer(
                   Configuration.GetConnectionString("Core_ContextConnection")));
            services.AddTransient<IRepository, UserRepo>();
            services.AddTransient<ICityRepository, CityRepository>();

            //book
            services.AddTransient<IProductRepository, EFProductRepository>();
            //services.AddTransient<Seed>();

            //services.AddMvc();
            services.AddControllersWithViews();
            //services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //The Microsoft.AspNetCore.StaticFiles package contains the functionality for handling static files,which must be enabled in the Startup class
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
