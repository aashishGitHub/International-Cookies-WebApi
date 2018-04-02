using System.Linq;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.Interfaces
{
    public interface IProductDomainService
    {
        IQueryable<Product> GetAllProducts();
        bool UpdateProduct(Product product);
        bool AddProduct(Product product);
    }
}
