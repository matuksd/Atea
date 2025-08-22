namespace Atea.Models
{
    public class Receipt
    {
        public string ReceiptId { get; set; }
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string PaymentGateway { get; set; }
    }
}
