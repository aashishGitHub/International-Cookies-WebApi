using System;
using System.Linq;
using InternationalCookies.DataAccess.DbContext;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Customer = InternationalCookies.Domain.Model.Customer;

namespace InternationalCookies.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly CookiesDbContext _cookiesDbContext;

        public CustomerRepository(CookiesDbContext cookiesDbContext)
        {
            _cookiesDbContext = cookiesDbContext;
        }

        public bool AddCustomer(Customer customer)
        {
            var newDbCustomer = new DbContext.Customer
            {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone
            };
            _cookiesDbContext.Customers.Add(newDbCustomer);
           return _cookiesDbContext.SaveChanges()>0;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            try
            {
                var customers = _cookiesDbContext.Customers
                    .Select(x => new Customer
                    {
                        Phone = x.Phone,
                        Address = x.Address,
                        CustomerId = x.CustomerId,
                        Name = x.Name

                    });
                return customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer GetCustomer(int? id, long? phone)
        {
            var customer = _cookiesDbContext.Customers
                .Where(x => 
                ((id.HasValue && id.Value.Equals(x.CustomerId)) || (phone.HasValue && phone.Value.ToString().Equals(x.Phone))
                ))
                .Select(x=>new Customer
                {
                    Phone = x.Phone,
                    Address = x.Address,
                    CustomerId = x.CustomerId,
                    Name = x.Name

                }).First();

            return customer;
        }

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _cookiesDbContext?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomerRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}
