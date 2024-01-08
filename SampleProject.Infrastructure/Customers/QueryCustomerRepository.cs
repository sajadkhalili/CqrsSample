using Microsoft.EntityFrameworkCore;
using SampleProject.Contract.Customers;
using SampleProject.Infrastructure.Database;

namespace SampleProject.Infrastructure.Domain.Customers;

public class QueryCustomerRepository : IQueryCustomerRepository
{
    private readonly OrdersContext _context;

    public QueryCustomerRepository(OrdersContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<List<CustomerDetailsDto>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers.Select(x => new CustomerDetailsDto()
        {
            Email = x.Email,
            Id = x.Id.Value,
            Name = x.Name,


        }).ToListAsync();
    }
}