using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace appflow.Contexts
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuickMessage> QuickMessages { get; set; }
        public DbSet<ColumnFlow> ColumnFlows { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<HistoryCustomerService> HistoryCustomerServices { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite(_connectionString);
        // }
    }
}