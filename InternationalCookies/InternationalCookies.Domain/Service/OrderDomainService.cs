using System.Collections.Generic;
using System.Linq;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.Model;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace InternationalCookies.Domain.Service
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;

        public OrderDomainService(IOrderRepository orderRepository, IStockRepository stockRepository)
        {
            _orderRepository = orderRepository;
            _stockRepository = stockRepository;
        }

        public bool PlaceOrder(Order order)
        {
            bool isSuccess = false;
            var productIdAndQuantityForOrderPlaced = order.OrderDetails.ToDictionary(o => o.ProductId, o => o.Quantity);
            var relatedStocksInDb = _stockRepository.GetStocksForOrder(order.OrderDetails.ToList());

            isSuccess = CheckIfStocksAvailable(relatedStocksInDb, productIdAndQuantityForOrderPlaced)
                        && _orderRepository.PlaceOrder(order);
                       // && UpdateUsedStocks(relatedStocksInDb, productIdAndQuantityForOrderPlaced);

            return isSuccess;

        }

        private bool CheckIfStocksAvailable(IEnumerable<Stock> relatedStocksInDb, Dictionary<int, int> productIdAndQuantityForOrderPlaced)
        {
          
            bool inSufficientProducts = relatedStocksInDb.ToArray().Any(st =>
                        (productIdAndQuantityForOrderPlaced[st.ProductId] > -1
                         &&
                         st.NumberOfItemsAvailable < productIdAndQuantityForOrderPlaced[st.ProductId]
                        )
            );

            return !inSufficientProducts;
        }
        private bool UpdateUsedStocks(IEnumerable<Stock> relatedStocksInDb, Dictionary<int,int> productIdAndQuantityForOrderPlaced)
        {
            var modifiedStocks = relatedStocksInDb.Where(st => productIdAndQuantityForOrderPlaced[st.ProductId] > -1)
                .Select(st => new Stock
                {
                    ProductId = st.ProductId,
                    NumberOfDefectiveItems = st.NumberOfDefectiveItems,
                    NumberOfItemsAvailable = st.NumberOfItemsAvailable - productIdAndQuantityForOrderPlaced.GetOrNull(st.ProductId),
                    Id = st.Id
                });

            return _stockRepository.UpdateStock(modifiedStocks);
        }
    }
}
