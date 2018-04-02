using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalCookies.DataAccess.DbContext
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime? DateOfOrder { get; set; }

        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }
        

        public decimal? TotalCost { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
