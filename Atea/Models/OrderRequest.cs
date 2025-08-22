using System.ComponentModel.DataAnnotations;

namespace Atea.Models
{
    public class OrderRequest
    {
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Payable amount must be greater than 0")]
        public decimal PayableAmount { get; set; }

        [Required]
        public string PaymentGateway { get; set; }

        public string Description { get; set; }
    }
}
