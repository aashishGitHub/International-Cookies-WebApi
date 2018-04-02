using System.Collections.Generic;
using ApplicationServices.Dto;

namespace ApplicationServices.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        bool UpdateProduct(ProductDto product);
        bool AddProduct(ProductDto product);
    }
}
