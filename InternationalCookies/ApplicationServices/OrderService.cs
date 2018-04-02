using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using ApplicationServices.Mapper;
using InternationalCookies.Domain.Interfaces;

namespace ApplicationServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDomainService _orderDomainService;

        public OrderService(IOrderDomainService orderDomainService)
        {
            _orderDomainService = orderDomainService;
        }

        public bool PlaceOrder(OrderDto order)
        {
            var isSuccess = _orderDomainService.PlaceOrder(order.ToOrderDomain());
            return isSuccess;
        }
    }
}
