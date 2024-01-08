using SampleProject.Contract.Customers;
using SampleProject.Contract.Queries;

namespace SampleProject.Application.Customers.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IQueryHandler<GetCustomerDetailsQuery, List<CustomerDetailsDto>>
    {
        private readonly IQueryCustomerRepository _query;


        public GetCustomerDetailsQueryHandler(IQueryCustomerRepository query)
        {
            _query = query;

        }

        public Task<List<CustomerDetailsDto>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            return _query.Handle(request, cancellationToken);
        }
    }
}