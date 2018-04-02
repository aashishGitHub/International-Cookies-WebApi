namespace InternationalCookies.Domain.Model
{
    public class Stock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? NumberOfItemsAvailable { get; set; }

        public int? NumberOfDefectiveItems { get; set; }

        //public virtual Product Product { get; set; }
    }
}
