using System.Collections.Generic;
using ApplicationServices.Dto;

namespace ApplicationServices.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();

        CustomerDto GetCustomer(int? id, long? phone);

        bool AddCustomer(CustomerDto customer);
    }
}
