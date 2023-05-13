using ChemicalShop.Data;
using ChemicalShop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ChemicalShop
{
    public class Startup
    {
        private IConfiguration _confString;
        public Startup(IConfiguration configuration, IHostingEnvironment hostEnv)
        {
            Configuration = configuration;
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();

            services.AddTransient<IReagentsCategory, CategoryRepository>();
            services.AddTransient<IAllReagents, ReagentsRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                name: "reagents",
                pattern: "{controller=Reagents}/{action=ReagentsList}");

                endpoints.MapControllerRoute(
                name: "shopCart",
                pattern: "{controller=ShopCart}/{action=Index}");

            });
           
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObjects.Initial(content);
            }
            
        }
    }
}
