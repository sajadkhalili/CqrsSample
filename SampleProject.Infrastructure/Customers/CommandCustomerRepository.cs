using Microsoft.EntityFrameworkCore;
using SampleProject.Contract.Customers;
using SampleProject.Domain.Customers;
using SampleProject.Infrastructure.Database;
using SampleProject.Infrastructure.SeedWork;

namespace SampleProject.Infrastructure.Domain.Customers
{
    public class CommandCustomerRepository : ICommandCustomerRepository
    {
        private readonly OrdersContext _context;

        public CommandCustomerRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Customer customer)
        {
            await this._context.Customers.AddAsync(customer);
        }

        public async Task<bool> ExistEmail(string email)
        {
            return await _context.Customers.AnyAsync(s => s.Email == email);
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            return await this._context.Customers
                .IncludePaths(
                    CustomerEntityTypeConfiguration.OrdersList,
                    CustomerEntityTypeConfiguration.OrderProducts)
                .SingleAsync(x => x.Id == id);
        }
    }
}