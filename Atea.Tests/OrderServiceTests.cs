using Atea.Models;
using Atea.Services;

namespace Atea.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void ProcessOrder_WithPayPalGateway_ShouldReturnReceipt()
        {
            var service = new OrderService();
            var orderRequest = new OrderRequest
            {
                OrderNumber = "ORDER - 12345",
                UserId = 1,
                PayableAmount = 100,
                PaymentGateway = "PayPal",
                Description = "Order for #12345"
            };

            var receipt = service.ProcessOrder(orderRequest);

            Assert.NotNull(receipt);
            Assert.Equal(orderRequest.OrderNumber, receipt.OrderNumber);
            Assert.Equal(orderRequest.UserId, receipt.UserId);
            Assert.Equal(orderRequest.PayableAmount, receipt.Amount);
            Assert.Equal(orderRequest.PaymentGateway, receipt.PaymentGateway);
        }

        [Fact]
        public void ProcessOrder_WithStripeGateway_ShouldThrowException()
        {
            var service = new OrderService();
            var orderRequest = new OrderRequest
            {
                OrderNumber = "ORDER - 12345",
                UserId = 1,
                PayableAmount = 100,
                PaymentGateway = "Stripe",
                Description = "Order for #12345"
            };

            Assert.Throws<Exception>(() => service.ProcessOrder(orderRequest));
        }

        [Fact]
        public void GetOrderHistory_ShouldReturnOrdersForUser()
        {
            var service = new OrderService();

            var order1 = new OrderRequest
            {
                OrderNumber = "ORDER - 12345",
                UserId = 1,
                PayableAmount = 100,
                PaymentGateway = "PayPal",
                Description = "Order for #12345"
            };
            var order2 = new OrderRequest
            {
                OrderNumber = "ORDER - 12346",
                UserId = 1,
                PayableAmount = 100,
                PaymentGateway = "PayPal",
                Description = "Order for #12346"
            };
            service.ProcessOrder(order1);
            service.ProcessOrder(order2);

            var order3 = new OrderRequest
            {
                OrderNumber = "ORDER - 12347",
                UserId = 2,
                PayableAmount = 100,
                PaymentGateway = "PayPal",
                Description = "Order for #12347"
            };
            service.ProcessOrder(order3);

            var user1Orders = service.GetOrderHistory(1);
            var user2Orders = service.GetOrderHistory(2);

            Assert.Equal(2, user1Orders.Count);
            Assert.Single(user2Orders);
            Assert.All(user1Orders, o => Assert.Equal(1, o.UserId));
            Assert.All(user2Orders, o => Assert.Equal(2, o.UserId));
        }
    }
}
