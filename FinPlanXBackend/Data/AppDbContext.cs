using FinPlanXBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FinPlanXBackend.Data
{
    
        // AppDbContext.cs
        public class AppDbContext : DbContext
        {
            public DbSet<Client> Clients { get; set; }
            public DbSet<FinancialPlan> FinancialPlans { get; set; }
            public DbSet<User> Users { get; set; }

            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // Add any custom configurations here
            }
        }
    }

