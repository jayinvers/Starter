namespace Starter.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public string Receiver { get; set; }
        public decimal Gst { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
    }
}
