namespace WebApp.Shared.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public float Qty { get; set; }

        public decimal Price => Product == null ? 0 : Product.Price * (decimal)Qty;
    }
}