using System.Web.Http;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using CookiesBootstrapper;
using Unity;

namespace InternationalCookies.Controllers.Api
{
    public class ProductsApiController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsApiController()
        {
            _productService = CookiesUnityContainer.Current.Resolve<IProductService>();
        }
        /// <summary>
        /// Get All Products with stocks
        /// </summary>
        /// <returns></returns>
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Add products
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="numberOfProductStocksAvailable"></param>
        /// <param name="numberOfProductStocksDamage"></param>
        /// <returns>isSuccess</returns>
        // POST api/<controller>
        public IHttpActionResult Post(string productName, decimal price, int numberOfProductStocksAvailable, int? numberOfProductStocksDamage)
        {
            var result =  _productService.AddProduct(new ProductDto
            {
                Price = price,
                ProductName = productName,
                ProductStocksAvailable = numberOfProductStocksAvailable,
                ProductStocksDamage = numberOfProductStocksDamage
            });
            return Ok(result);
        }

        /// <summary>
        /// Update product and stock details by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="numberOfProductStocksAvailable"></param>
        /// <param name="numberOfProductStocksDamage"></param>
        /// <returns></returns>
        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, string productName, decimal? price, int? numberOfProductStocksAvailable, int? numberOfProductStocksDamage)
        {
            if(id <=0)
            return BadRequest();

          var isSuccessful = _productService.UpdateProduct(new ProductDto
          {
                ProductId = id,
                ProductStocksDamage = numberOfProductStocksDamage,
                Price = price,
                ProductName = productName,
                ProductStocksAvailable = numberOfProductStocksAvailable
            });
            return Ok(isSuccessful);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}