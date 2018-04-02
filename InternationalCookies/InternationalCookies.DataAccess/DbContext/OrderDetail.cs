using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalCookies.DataAccess.DbContext
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int? Quantity { get; set; }
        
        public virtual Order Order { get; set; }

        public decimal Cost { get; set; }
    }
}
