using SampleProject.Domain.Customers.Rules;
using SampleProject.Domain.SeedWork;

namespace SampleProject.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public CustomerId Id { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }



        private bool _welcomeEmailWasSent;

        private Customer()
        {

        }

        private Customer(string email, string name)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            Email = email;
            Name = name;
            _welcomeEmailWasSent = false;

            this.AddDomainEvent(new CustomerRegisteredEvent(this.Id));
        }

        public static Customer CreateRegistered(string email, string name, ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));

            return new Customer(email, name);
        }






        public void MarkAsWelcomedByEmail()
        {
            this._welcomeEmailWasSent = true;
        }
    }
}