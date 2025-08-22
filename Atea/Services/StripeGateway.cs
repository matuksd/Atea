using Atea.Models;

namespace Atea.Services
{
    public class StripeGateway : IPaymentGateway
    {
        public bool ProcessPayment(OrderRequest order) => false;
    }
}
