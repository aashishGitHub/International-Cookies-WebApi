using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.Interfaces
{
    public interface IOrderDomainService
    {
        bool PlaceOrder(Order order);
    }
}
