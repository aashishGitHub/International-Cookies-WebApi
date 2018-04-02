using System;
using System.Collections.Generic;
using System.Linq;
using InternationalCookies.DataAccess.DbContext;
using InternationalCookies.Domain.Model;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Unity.Interception.Utilities;
using Stock = InternationalCookies.Domain.Model.Stock;

namespace InternationalCookies.DataAccess.Repositories
{
    public class StockRepository : IStockRepository, IDisposable
    {
        private readonly CookiesDbContext _cookiesDbContext;

        public StockRepository(CookiesDbContext cookiesDbContext)
        {
            _cookiesDbContext = cookiesDbContext;
        }

        public IQueryable<Stock> GetStocksForOrder(List<OrderDetails> orderDetails)
        {
            var requiredProductIds = orderDetails.Select(od => od.ProductId);

           IQueryable<Stock> result = _cookiesDbContext.Stocks.Where(st => requiredProductIds.Contains(st.ProductId))
                .Select(sto => new Stock
               {
                    ProductId = sto.ProductId,
                    NumberOfDefectiveItems = sto.NumberOfDefectiveItems,
                    NumberOfItemsAvailable = sto.NumberOfItemsAvailable
                });

            return result;
        }

        public bool UpdateStock(IEnumerable<Stock> stocks)
        {
            stocks.ForEach(st =>
            {
                var dbStock = _cookiesDbContext.Stocks.First(dbS => dbS.ProductId.Equals(st.ProductId));

                dbStock.NumberOfDefectiveItems = st.NumberOfDefectiveItems;
                dbStock.NumberOfItemsAvailable = st.NumberOfItemsAvailable;
            });

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
