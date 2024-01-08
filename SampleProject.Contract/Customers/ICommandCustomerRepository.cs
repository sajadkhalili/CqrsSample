using SampleProject.Domain.Customers;

namespace SampleProject.Contract.Customers
{
    public interface ICommandCustomerRepository
    {
        Task<Customer> GetByIdAsync(CustomerId id);

        Task AddAsync(Customer customer);

        Task<bool> ExistEmail(string email);
    }
}