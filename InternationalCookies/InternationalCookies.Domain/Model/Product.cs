using System.ComponentModel.DataAnnotations;

namespace InternationalCookies.Domain.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public int? ProductStocksAvailable { get; set; }
        public int? ProductStocksDamage { get; set; }
    }
}
