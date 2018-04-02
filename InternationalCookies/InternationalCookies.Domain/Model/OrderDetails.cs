namespace InternationalCookies.Domain.Model
{
    public class OrderDetails
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int Id { get; set; }
        public int OrderId { get; set; }

    }
}
