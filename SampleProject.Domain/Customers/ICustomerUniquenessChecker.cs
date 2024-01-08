namespace SampleProject.Domain.Customers
{
    public interface ICustomerUniquenessChecker
    {
        Task<bool> IsUnique(string customerEmail);
    }
}