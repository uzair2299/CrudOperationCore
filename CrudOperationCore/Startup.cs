using CrudOperationCore.Interfaces;
using CrudOperationCore.Models;
using CrudOperationCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            //services.AddSession(options => {
            //    options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            //});

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
/*
 * SESSION IN ASP.NET CORE
 * Web applications work on HTTP protocol and HTTP is a stateless protocol. Every HTTP request is treated as an independent request.
 * The Server does not have knowledge about the variable values, which are being used in the previous request.
 * 
 * It is important to call "UseSession" method before the "UseMvc" method in Configure method of startup class.
 * If we call “UseMvc” method before “UseSession” method, the system will throw an exception.
 * 
 * We can use session from HttpContext, once it is installed and configured. 
 * To use session in controller class, we need to reference "Microsoft.AspNet.Http" in controller.
 * There are three methods that enables us to set the session value, which are Set, SetInt32 and SetString.
 * Same as there are three methods that  are used to retrieve the value from the session: Get, GetInt32 and GetString.
 * 
 * If you want to save or restore objects, Microsoft's recommendation is to convert them to JSON strings using the NewtonSoft utilities and then use SetString and GetString.
 */


//We need to install the stable version of “Microsoft.AspNetCore.Session.Then only we can access the session state in ASP.NET Core.
