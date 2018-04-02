using System.Web.Http;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using CookiesBootstrapper;
using Unity;

namespace InternationalCookies.Controllers
{
    public class OrderApiController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderApiController()
        {
            _orderService = CookiesUnityContainer.Current.Resolve<IOrderService>();
        }

        /// <summary>
        /// Place order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        [HttpPost]
        public IHttpActionResult PlaceOrder(OrderDto order)
        {
            bool isSuccess = _orderService.PlaceOrder(order);

            return Ok(isSuccess);
        }

    }
}
