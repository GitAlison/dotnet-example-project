using Microsoft.EntityFrameworkCore;

namespace appflow.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuickMessage> QuickMessages { get; set; }
        public DbSet<ColumnFlow> ColumnFlows { get; set; }
        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<HistoryCustomerService> HistoryCustomerServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=Database.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}