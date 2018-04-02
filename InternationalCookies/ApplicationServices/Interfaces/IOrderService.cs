using ApplicationServices.Dto;

namespace ApplicationServices.Interfaces
{
    public interface IOrderService
    {
        bool PlaceOrder(OrderDto order);

    }

}
