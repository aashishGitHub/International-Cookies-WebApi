using System.Linq;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.RepositoriesInterfaces
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetAllProducts();

        bool UpdateProduct(Product product);

        bool AddProduct(Product product);


    }
}
