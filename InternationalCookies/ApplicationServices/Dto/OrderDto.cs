using System;
using System.Collections.Generic;

namespace ApplicationServices.Dto
{
    public class OrderDto
    {
        public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
        public int? OrderId { get; set; }
        public DateTime DateOfOrder { get; set; }

        public int CustomerId { get; set; }
        public decimal TotalCost { get; set; }
    }
}
