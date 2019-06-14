using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration=configuration;

      public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SportsStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));        //wskazuje powizanie żądań, lambda spełnia zadania cart
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();     //dodanie usługi, wymagana do uzyskania dostępu do beirzącej sesji z poziomu klasy SessionCart, (dzieki temu mozemy oproscic kontroler)
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();    //szczególy wyjatku
            app.UseStatusCodePages();   //404
            app.UseStaticFiles();   //wlacza obsluge css i js w root
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"Content")),
                RequestPath = new PathString("/Content")
            });

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(        //trasa
                    name: null,
                    template: "{category}/Strona{productPage:int}",
                    defaults: new { controller = "Product", action = "List" });

                routes.MapRoute(        //trasa
                    name: null,
                    template: "Strona{productPage}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });


                routes.MapRoute(        //trasa
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });

                routes.MapRoute(        //trasa
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List" , productPage=1});


                routes.MapRoute(        //trasa
                    name: "StronyStatyczne",
                    template: "strony/{name}",
                    defaults: new { controller = "Product", action = "StronyStatyczne"});


                routes.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}"
                    );
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
