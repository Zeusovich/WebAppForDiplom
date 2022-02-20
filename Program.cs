using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using WebAppForDiplom.Context;
using WebAppForDiplom.Models;

namespace WebAppForDiplom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    RoleInitializer.Initialize(userManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
                
            }

            host.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class RoleInitializer
    {
        public static void Initialize(UserManager<User> _userManager)
        {
            var admin = new User
            {
                UserName = "admin",
                FirstName = "Danya",
            };

            var worker1 = new User
            {
                UserName = "worker1",
                FirstName = "worker1",
            };

            var worker2 = new User
            {
                UserName = "worker2",
                FirstName = "worker2",
            };

            var worker3 = new User
            {
                UserName = "worker3",
                FirstName = "worker3",
            };
          
            var boss = new User
            {
                UserName = "boss",
                FirstName = "boss",
            };

            var result1 = _userManager.CreateAsync(admin, "qwert123").GetAwaiter().GetResult();
            var result2 = _userManager.CreateAsync(worker1, "worker1123").GetAwaiter().GetResult();
            var result3 = _userManager.CreateAsync(worker2, "worker2123").GetAwaiter().GetResult();
            var result4 = _userManager.CreateAsync(worker3, "worker3123").GetAwaiter().GetResult();
            var result5 = _userManager.CreateAsync(boss, "boss123").GetAwaiter().GetResult();
            

            if (result1.Succeeded)
            {
                _userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
            }
            if (result2.Succeeded)
            {
                _userManager.AddClaimAsync(worker1, new Claim(ClaimTypes.Role, "Worker")).GetAwaiter().GetResult();
            }
            if (result3.Succeeded)
            {
                _userManager.AddClaimAsync(worker2, new Claim(ClaimTypes.Role, "Worker")).GetAwaiter().GetResult();
            }
            if (result4.Succeeded)
            {
                _userManager.AddClaimAsync(worker3, new Claim(ClaimTypes.Role, "Worker")).GetAwaiter().GetResult();
            }
            if (result5.Succeeded)
            {
                _userManager.AddClaimAsync(boss, new Claim(ClaimTypes.Role, "Boss")).GetAwaiter().GetResult();
            }
            
        }
    }
}
