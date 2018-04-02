using System.Linq;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.Model;
using InternationalCookies.Domain.RepositoriesInterfaces;

namespace InternationalCookies.Domain.Service
{
    public class CustomerService: ICustomerDomainService
    {
        
        private readonly ICustomerRepository _customertRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customertRepository = customerRepository;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
           return _customertRepository.GetAllCustomers();
        }

        public Customer GetCustomer(int? id, long? phone)
        {
           return _customertRepository.GetCustomer(id, phone);
        }

        public bool AddCustomer(Customer customer)
        {
            return _customertRepository.AddCustomer(customer);
        }
    }
}
