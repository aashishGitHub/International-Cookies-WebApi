using System.Collections.Generic;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.Interfaces
{
    public interface IStockDomainService
    {
        bool UpdateStock(Stock stocks);

        IEnumerable<Stock> GetStocks(List<OrderDetails> orderDetails);
    }
}
