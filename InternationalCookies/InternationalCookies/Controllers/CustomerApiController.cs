using System;
using System.Web.Http;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using CookiesBootstrapper;
using Unity;

namespace InternationalCookies.Controllers.Api
{
    public class CustomerApiController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerApiController()
        {
            _customerService = CookiesUnityContainer.Current.Resolve<ICustomerService>();
        }

        //public CustomerApiController(ICustomerService customerService)
        //{
        //    _customerService = customerService;
        //}

       /// <summary>
       /// Get all customer list
       /// </summary>
       /// <returns></returns>
        public IHttpActionResult Get()
        {
            var allCustomers = _customerService.GetAllCustomers();
            return Ok(allCustomers);
        }

        /// <summary>
        /// Get customer by id or phone
        /// </summary>
        /// <param name="id"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int? id, long? phone)
        {
            if (!id.HasValue && !phone.HasValue)
            {
                return BadRequest();
            }

            var result = _customerService.GetCustomer(id, phone);

            return Ok(result);
        }
        
        /// <summary>
        /// Add new customer 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public IHttpActionResult Post(string name, string phone, string address)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (phone == null) throw new ArgumentNullException(nameof(phone));

            var isSuccess = _customerService.AddCustomer(new CustomerDto
            {
                Name = name,
                Phone = phone,
                Address = address
            });
            return Ok(isSuccess);
        }
        
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }
       
        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {

        }
    }
}