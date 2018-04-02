using System.Linq;
using ApplicationServices.Dto;
using InternationalCookies.Domain.Model;

namespace ApplicationServices.Mapper
{
    public static class Mapper
    {
        public static CustomerDto ToCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                CustomerId = customer.CustomerId
            };
        }

        public static Customer ToCustomerDomain(this CustomerDto customer)
        {
            return new Customer
            {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone,
                CustomerId = customer.CustomerId
            };
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
             CustomerId = order.CustomerId,
             DateOfOrder = order.DateOfOrder,
             OrderId = order.OrderId,
             TotalCost = order.TotalCost,
             OrderDetails = order.OrderDetails.Select(o => o.ToOrderDetailsDto())
            };
        }

        public static OrderDetailDto ToOrderDetailsDto(this OrderDetails orderDetails) => new OrderDetailDto
        {
            Id = orderDetails.Id,
            ProductId = orderDetails.ProductId,
            Quantity = orderDetails.Quantity,
            OrderId = orderDetails.OrderId
        };
        public static OrderDetails ToOrderDetailsDto(this OrderDetailDto  orderDetails) => new OrderDetails
        {
            Id = orderDetails.Id,
            ProductId = orderDetails.ProductId,
            Quantity = orderDetails.Quantity,
            OrderId = orderDetails.OrderId
        };

        public static Order ToOrderDomain(this OrderDto order)
        {
            return new Order
            {
                CustomerId = order.CustomerId,
                DateOfOrder = order.DateOfOrder,
                TotalCost = order.TotalCost,
                OrderDetails = order.OrderDetails.Select(o => o.ToOrderDetailsDto())
            };
        }

        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Price = product.Price,
                ProductName = product.ProductName,
                ProductStocksAvailable = product.ProductStocksAvailable,
                ProductStocksDamage = product.ProductStocksDamage
            };
        }

        public static Product ToProductDomain(this ProductDto product)
        {
            return new Product
            {
                ProductId = product.ProductId, 
                Price = product.Price,
                ProductName = product.ProductName,
                ProductStocksAvailable = product.ProductStocksAvailable,
                ProductStocksDamage = product.ProductStocksDamage
            };
        }
    }
}
