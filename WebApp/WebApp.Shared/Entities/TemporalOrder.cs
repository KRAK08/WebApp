namespace WebApp.Shared.Entities
{
    public class TemporalOrder
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public string? UserId { get; set; }

        public Product? Product { get; set; }

        public int ProductId { get; set; }

        public float Quantity { get; set; }

        public decimal Value => Product == null ? 0 : Product.Price * (decimal)Quantity;
    }
}