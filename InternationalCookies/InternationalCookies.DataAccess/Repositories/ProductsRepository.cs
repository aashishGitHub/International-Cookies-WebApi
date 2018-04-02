using System;
using System.Linq;
using InternationalCookies.DataAccess.DbContext;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Product = InternationalCookies.Domain.Model.Product;

namespace InternationalCookies.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository, IDisposable
    {
        private readonly CookiesDbContext _cookiesDbContext;
        public ProductsRepository(CookiesDbContext cookiesDbContext)
        {
            _cookiesDbContext = cookiesDbContext;
        }


        public IQueryable<Product> GetAllProducts()
        {
            var allProductsAndStocks = _cookiesDbContext.Products.Select(x => new Product
            {
                ProductId = x.ProductId,
                Price = x.Price,
                ProductName = x.ProductName,
                ProductStocksAvailable = x.Stock.NumberOfItemsAvailable,
                ProductStocksDamage = x.Stock.NumberOfDefectiveItems
            });
            return allProductsAndStocks;
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                var productDbOrject = _cookiesDbContext.Products.First(x => x.ProductId.Equals(product.ProductId));

                productDbOrject.Price = product.Price ?? productDbOrject.Price;
                productDbOrject.ProductName = product.ProductName ?? productDbOrject.ProductName;
                productDbOrject.Stock.NumberOfItemsAvailable = product.ProductStocksAvailable ?? productDbOrject.Stock.NumberOfItemsAvailable;
                productDbOrject.Stock.NumberOfDefectiveItems = product.ProductStocksDamage ?? productDbOrject.Stock.NumberOfDefectiveItems;
                return _cookiesDbContext.SaveChanges() > 0;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        public bool AddProduct(Product product)
        {
            try
            {
                var productDbOrject = new DbContext.Product
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Stock = new Stock()
                    {
                        NumberOfDefectiveItems = product.ProductStocksDamage,
                        NumberOfItemsAvailable = product.ProductStocksDamage
                    }
                };
                
                productDbOrject.Stock.ProductId = productDbOrject.ProductId;

                _cookiesDbContext.Products.Add(productDbOrject);

                return _cookiesDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
