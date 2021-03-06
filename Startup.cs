using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using WebAppForDiplom.BusinessLogic;
using WebAppForDiplom.Context;
using WebAppForDiplom.Data;
using WebAppForDiplom.Interfaces;
using WebAppForDiplom.Models;

namespace WebAppForDiplom
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
             })
                .AddIdentity<User, UserRole>(config =>
                {
                    config.Password.RequireLowercase = false;
                    config.Password.RequiredLength = 6;
                    config.Password.RequireDigit = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                })
             .AddEntityFrameworkStores<DataContext>();
             

            services.AddTransient<IOrderData, OrdersService>();
            services.AddTransient<OptimizationAlgorithm>();

            services.AddControllersWithViews();

            /*services.AddAuthentication("Cookie").AddCookie("Cookie");*/

            var administrator = "Administrator";
            var workerRole = "Worker";
            var bossRole = "Boss";
            var guestRole = "Guest";

            services.AddAuthorization(options =>
            {

                options.AddPolicy(administrator, builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, administrator);
                });

                options.AddPolicy(workerRole, builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, administrator) 
                    || x.User.HasClaim(ClaimTypes.Role, workerRole));
                });

                options.AddPolicy(bossRole, builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, administrator) 
                    || x.User.HasClaim(ClaimTypes.Role, bossRole));
                });

                options.AddPolicy(guestRole, builder =>
                {
                    builder.RequireAssertion(x=>x.User.HasClaim(ClaimTypes.Role,administrator)
                    ||x.User.HasClaim(ClaimTypes.Role,guestRole));
                    });

            });     

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
