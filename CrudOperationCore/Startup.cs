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
    //ASP.NET Core application must include Startup class. It is like Global.asax in the traditional .NET application.
    //As the name suggests, it is executed first when the application starts.
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //ASP.NET Core allows us to register our application services with IoC container, in the ConfigureServices method of the Startup class.
        //The ConfigureServices method includes a parameter of IServiceCollection type which is used to register application services.
        //IServiceCollection interface is an empty interface. It just inherits IList<servicedescriptor>
        //The ServiceCollection class implements IServiceCollection interface.
        // This method gets called by the runtime. Use this method to add services to the container.
        
        /*
        Understanding Service Lifetime
        Built-in IoC container manages the lifetime of a registered service type. It automatically disposes a service instance based on the specified lifetime.
        The built-in IoC container supports three kinds of lifetimes:
        Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime.
        Transient: The IoC container will create a new instance of the specified service type every time you ask for it.
        Scoped: IoC container will create an instance of the specified service type once per request and will be shared in a single request.
        */
        
        /*
        Get Services Manually
        
        */
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
 * We need to install the stable version of “Microsoft.AspNetCore.Session.Then only we can access the session state in ASP.NET Core.
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


/*
 * IoC CONTAINER
 * Container responsibilities:
 *                            Creating
 *                            Disposing
 * The followings are important interfaces and classes for built-in IoC container:
 * Interfaces:
 *             IServiceProvider   :>> IServiceProvider includes GetService method.
 *                                    The ServiceProvider class implements IServiceProvider interface which returns registered services with the container.
 *                                :>> We cannot instantiate ServiceProvider class because its constructors are marked with internal access modifier.
 *                                
 *             IServiceCollection :>> lets the IoC container know of concrete implementation
 *                                    It should be used to resolve what Interface belongs to what implementation
 *                                    
 *                                    we can register application services with built-in IoC container in the Configure method of Startup class by using IServiceCollection
 *                                    The ServiceCollection class implements IServiceCollection interface.
 * Classes:
 *             ServiceProvider
 *             ServiceCollection
 *             ServiceDescription
 *             ServiceCollectionServiceExtensions
 *             ServiceCollectionContainerBuilderExtensions
 * 
 * 
 * Service lifetimes
 * The service life time means how long the service will live, before it's being garbage collected. There are currently three different lifetimes:
 *             Transient, services.AddTransient(), the service is created each time it is requested
 *             Singleton, services.AddSingleton(), created once for the lifetime of the application
 *             Scoped, services.AddScoped(), created once per request
 * There are 3 variations each for AddTransient, AddScoped & AddSingleton methods:
 *             <service, implType>() :>>This variation creates an instance of the implementation type for every dependency. 
 *             <service>() :>> This variation is used to register a Single Type object.
 *             <service>(factoryFunc) :>> This variation is used to register a factory function that will be invoked to create implementation objects. 
 *                                  
 * 
 * 
 * 
 * Inject the dependency in controller action
 * Declaring dependency through a constructor of the Controller can be expensive because the dependency is resolved every time the Controller is created,
 * and also because not all action methods need the implementation type object.
 * Some time, we required dependency to the particular controller action method not to throughout controller.
 * ASP.net core MVC allows us to inject the dependency to particular action using "FromServices" attribute.
 * This attribute tell the ASP.net core framework that parameter should be retrieve from the service container.
 * 
 * 
 * 
 *       public IActionResult Index([FromServices] IHelloWorldService helloWorldService)
 *        {
 *           ViewData["MyText"] = helloWorldService.SaysHello() + "Jignesh!";
 *           return View();
 *        }
 * 
 * 
 * 
 * 
 * Get the service instance manually
 * There is another way to get dependency services from the service container.
 * In this method, service is not injected in controller constructor or in action method as parameter. 
 * Using method "GetService" of "HttpContext.RequestServices" property, we can get dependent services configured with Service container.
 *
 *
 *
 * Dependency Injection for Single Type
 * If you have a simple class that does not implement an Interface then it is a Single Type. In such a case you can use the Dependency Injection technique.
 *  services.AddTransient<ProductSum>();
 *  
 *
 *
 */
