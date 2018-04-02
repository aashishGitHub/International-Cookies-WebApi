using System.Collections.Generic;
using System.Linq;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using ApplicationServices.Mapper;
using InternationalCookies.Domain.Interfaces;

namespace ApplicationServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDomainService _customerDomainService;
        public CustomerService(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }

        public bool AddCustomer(CustomerDto customer)
        {

         return  _customerDomainService.AddCustomer(customer.ToCustomerDomain());
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
           return _customerDomainService.GetAllCustomers().ToList()
                .Select(x=>x.ToCustomerDto());
        }

        public CustomerDto GetCustomer(int? id, long? phone)
        {
            return _customerDomainService.GetCustomer(id, phone).ToCustomerDto();
        }
    }
}
