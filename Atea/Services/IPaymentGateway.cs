using Atea.Models;

namespace Atea.Services
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(OrderRequest order);
    }
}
