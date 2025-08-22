using Atea.Models;

namespace Atea.Services
{
    public class PayPalGateway : IPaymentGateway
    {
        public bool ProcessPayment(OrderRequest order) => true;
    }
}
