using SampleProject.Application.Configuration.Commands;
using SampleProject.Contract.Customers;
using SampleProject.Domain.Customers;
using SampleProject.Domain.SeedWork;

namespace SampleProject.Application.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand, CustomerDto>
    {
        private readonly ICommandCustomerRepository _customerRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCustomerCommandHandler(
            ICommandCustomerRepository customerRepository,
            ICustomerUniquenessChecker customerUniquenessChecker,
            IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateRegistered(request.Email, request.Name, this._customerUniquenessChecker);

            await this._customerRepository.AddAsync(customer);

            await this._unitOfWork.CommitAsync(cancellationToken);

            return new CustomerDto { Id = customer.Id.Value };
        }
    }
}