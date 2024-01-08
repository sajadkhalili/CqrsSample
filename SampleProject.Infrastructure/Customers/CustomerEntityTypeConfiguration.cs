using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Domain.Customers;
using SampleProject.Infrastructure.Database;

namespace SampleProject.Infrastructure.Domain.Customers
{
    internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        internal const string OrdersList = "_orders";
        internal const string OrderProducts = "_orderProducts";

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", SchemaNames.Orders);

            builder.HasKey(b => b.Id);


            builder.Property(c => c.Id)
                .HasConversion(c => c.Value, c => new CustomerId(c));


        }
    }
}