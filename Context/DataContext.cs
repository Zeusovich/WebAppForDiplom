using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Context
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Guest> Guest { get; set; } = null!;
        public DbSet<OrderValue> OrderValue { get; set; }
        //public DbSet<User> Users { get; set; }

    }
}
