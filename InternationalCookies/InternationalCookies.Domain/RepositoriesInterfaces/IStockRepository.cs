using System.Collections.Generic;
using System.Linq;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.RepositoriesInterfaces
{
   public interface IStockRepository
    {
        bool UpdateStock(IEnumerable<Stock> stocks);

        IQueryable<Stock> GetStocksForOrder(List<OrderDetails> orderDetails);
    }
}
