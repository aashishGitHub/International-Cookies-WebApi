using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalCookies.DataAccess.DbContext
{
    [Table("Stocks")]
    public class Stock
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int? NumberOfItemsAvailable { get; set; }

        public int? NumberOfDefectiveItems { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
