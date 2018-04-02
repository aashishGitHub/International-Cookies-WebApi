using System.Collections.Generic;
using System.Linq;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using ApplicationServices.Mapper;
using InternationalCookies.Domain.Interfaces;

namespace ApplicationServices
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }

        public bool AddProduct(ProductDto product)
        {
            return _productDomainService.AddProduct(product.ToProductDomain());
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
           return _productDomainService.GetAllProducts().ToList()
                .Select(p=>p.ToProductDto());
        }

        public bool UpdateProduct(ProductDto product)
        {
            return _productDomainService.UpdateProduct(product.ToProductDomain());
        }
    }
}
