using Atea.Models;

namespace Atea.Services
{
    public class OrderService
    {
        private readonly Dictionary<string, IPaymentGateway> gateways;
        private readonly List<Order> orders = new();

        public OrderService()
        {
            gateways = new()
            {
                { "PayPal", new PayPalGateway() },
                { "Stripe", new StripeGateway() }
            };
        }

        public Receipt ProcessOrder(OrderRequest request)
        {
            if (!gateways.TryGetValue(request.PaymentGateway, out var gateway))
                throw new Exception("Invalid payment gateway");

            bool success = gateway.ProcessPayment(request);
            if (!success) throw new Exception("Payment failed");

            var receipt = new Receipt
            {
                ReceiptId = Guid.NewGuid().ToString(),
                OrderNumber = request.OrderNumber,
                UserId = request.UserId,
                Amount = request.PayableAmount,
                Timestamp = DateTime.Now,
                PaymentGateway = request.PaymentGateway
            };

            orders.Add(new Order
            {
                OrderNumber = request.OrderNumber,
                UserId = request.UserId,
                PayableAmount = request.PayableAmount,
                PaymentGateway = request.PaymentGateway,
                Description = request.Description,
                Receipt = receipt
            });

            return receipt;
        }

        public List<Order> GetOrderHistory(int userId) =>
            orders.Where(o => o.UserId == userId).ToList();
    }
}
