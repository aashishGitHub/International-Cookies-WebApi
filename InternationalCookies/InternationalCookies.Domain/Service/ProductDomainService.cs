using System.Linq;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.Model;
using InternationalCookies.Domain.RepositoriesInterfaces;

namespace InternationalCookies.Domain.Service
{
    public class ProductDomainService: IProductDomainService
    {
        private readonly IProductsRepository _productRepository;

        public ProductDomainService(IProductsRepository productsRepository)
        {
            _productRepository = productsRepository;
        }

        public bool AddProduct(Product product)
        {
           return _productRepository.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
           return _productRepository.UpdateProduct(product);
        }

        IQueryable<Product> IProductDomainService.GetAllProducts()
        {
          return  _productRepository.GetAllProducts();
        }
    }
}
