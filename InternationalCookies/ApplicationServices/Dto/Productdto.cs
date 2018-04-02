using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }
        public int? ProductStocksAvailable { get; set; }
        public int? ProductStocksDamage { get; set; }

    }
}
