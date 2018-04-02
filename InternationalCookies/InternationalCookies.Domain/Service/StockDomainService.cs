using System;
using System.Collections.Generic;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.Service
{
    public class StockDomainService : IStockDomainService
    {
        public IEnumerable<Stock> GetStocks(List<OrderDetails> orderDetails)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStock(Stock stocks)
        {
            throw new NotImplementedException();
        }
    }
}
