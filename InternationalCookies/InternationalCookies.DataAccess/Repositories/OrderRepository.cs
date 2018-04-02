using System;
using System.Data.Entity;
using System.Linq;
using InternationalCookies.DataAccess.DbContext;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Order = InternationalCookies.Domain.Model.Order;

namespace InternationalCookies.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly CookiesDbContext _cookiesDbContext;

        public OrderRepository(CookiesDbContext cookiesDbContext)
        {
            _cookiesDbContext = cookiesDbContext;
        }


        public bool PlaceOrder(Order order)
        {   
          var products = _cookiesDbContext.Products.Join(order.OrderDetails.Select(od => od.ProductId),
                dbP => dbP.ProductId, op => op, 
                (dbP, op) => new 
                {
                    ProductId = dbP.ProductId,
                    Price = dbP.Price
                }).ToList();
            

            var newDbOrder = new DbContext.Order
            {
                CustomerId = order.CustomerId,
                DateOfOrder = DateTime.UtcNow,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    Cost =   products.Where(p=>p.ProductId.Equals(od.ProductId)).Sum(x=>x.Price.Value)
                }).ToList() 
            };
            newDbOrder.TotalCost = newDbOrder.OrderDetails.Sum(x => x.Cost);

            _cookiesDbContext.Orders.Add(newDbOrder);

            return _cookiesDbContext.SaveChanges() > 0;
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
