using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Models;

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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("ShopProducts")));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("ShopIdentity")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(config =>
            {
                config.MapControllerRoute("catpage", "{category}/{subcategory}/Page{productPage:int}", new { controller = "Home", action = "Index" });
                config.MapControllerRoute("page", "{category}/Page{productPage:int}", new { Controller = "Home", action = "Index", productPage = 1 });
                config.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", action = "Index", productPage = 1 });
                config.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", productPage = 1 });
                config.MapControllerRoute("userroles", "{controller}/{action}/{userid}", new { Controller = "Roles", Action = "Index" });
                config.MapDefaultControllerRoute();
            });
        }
    }
}
