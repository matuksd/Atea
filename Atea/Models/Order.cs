namespace Atea.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public decimal PayableAmount { get; set; }
        public string PaymentGateway { get; set; }
        public string Description { get; set; }
        public Receipt Receipt { get; set; } = new();
    }
}
