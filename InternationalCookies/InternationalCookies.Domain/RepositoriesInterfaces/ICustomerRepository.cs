using System.Linq;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.RepositoriesInterfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllCustomers();

        Customer GetCustomer(int? id, long? phone);

        bool AddCustomer(Customer customer);
    }
}
