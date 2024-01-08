namespace SampleProject.Contract.Customers;

public interface IQueryCustomerRepository
{
    Task<List<CustomerDetailsDto>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken);
}