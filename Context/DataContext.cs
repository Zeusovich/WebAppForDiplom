using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Context
{
    public class DataContext : IdentityDbContext<User, UserRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/

        }
        public DbSet<Order> Orders { get; set; }

    }
}
