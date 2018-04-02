using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.RepositoriesInterfaces
{
    public interface IOrderRepository
    {
        bool PlaceOrder(Order order);
    }
}
