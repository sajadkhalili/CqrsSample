using SampleProject.Contract.Customers;
using SampleProject.Domain.Customers;
namespace SampleProject.Application.Customers.DomainServices
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly ICommandCustomerRepository _repository;


        public CustomerUniquenessChecker(ICommandCustomerRepository repository)
        {
            _repository = repository;

        }

        public async Task<bool> IsUnique(string customerEmail)
        {


            return !await _repository.ExistEmail(customerEmail);
        }
    }
}