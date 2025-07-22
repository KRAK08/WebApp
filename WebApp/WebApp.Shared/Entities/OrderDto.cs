namespace WebApp.Shared.Entities
{
    public class OrderDto
    {
        public int UserId { get; set; }

        public List<ProductOrder>? Details { get; set; }
    }
}