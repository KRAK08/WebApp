using WebApp.Shared.Enums;

namespace WebApp.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public OrderStates OrderState { get; set; }

        public decimal Value => OrderDetails == null || OrderDetails.Count == 0 ? 0 : OrderDetails.Sum(x => x.Price);
    }
}