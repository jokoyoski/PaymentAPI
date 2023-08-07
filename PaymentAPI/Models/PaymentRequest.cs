using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models;

public class PaymentRequest
{
   
    [Required]
    [StringLength(19, MinimumLength = 13, ErrorMessage = "CardNumber length should be between 13 and 19")]
    public string CardNumber { get; set; }
    
    [Required]
    public string MerchantCode { get; set; }
    
    
    public string CustomerCode { get; set; }
    
    public string CurrencyCode { get; set; }
    
    [Required]
    [MaxLength(4)]
    public string CVV { get; set; }

    // Amount should be greater than 0
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }

    // ExpiryMonth should be between 1 and 12
    [Required]
    [Range(1, 12, ErrorMessage = "ExpiryMonth should be between 1 and 12")]
    public int ExpiryMonth { get; set; }

    // ExpiryYear should be greater than or equal to the current year
    [Required]
    [Range(2023, int.MaxValue, ErrorMessage = "ExpiryYear should be a future year")]
    public int ExpiryYear { get; set; }
}