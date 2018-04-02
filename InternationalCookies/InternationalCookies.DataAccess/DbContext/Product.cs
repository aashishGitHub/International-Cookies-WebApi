using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalCookies.DataAccess.DbContext
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public decimal? Price { get; set; }
        
        public virtual Stock Stock { get; set; }

    }
}
