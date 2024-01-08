using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Customers;

namespace SampleProject.Infrastructure.Database
{

    public class OrdersContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }


        public OrdersContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }
    }
}
