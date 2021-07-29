using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop
{
    public class Startup
    {
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMemoryCache();
            services.AddSession();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductRepository, EFProductRepository>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: null,
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                config.MapControllerRoute(
                    name: null,
                    pattern: "{category}/Page{productPage:int}");
                config.MapControllerRoute(
                    name: null,
                    pattern: "Page{productPage:int}");
                config.MapControllerRoute(
                    name: null,
                    pattern: "{category}");
                config.MapControllerRoute(
                    name: null,
                    pattern: "");
                //config.MapControllerRoute(
                //    name: null,
                //    pattern: "{controller=Cart}#/{action=Index}/{ReturnUrl}");
            });
        }
    }
}
