using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Proxy;

public class AcquiererPaymentRequest : IAcquiererPaymentRequest
{
    public string CurrencyCode { get; set; }
    
    public string CustomerCode { get; set; }
    public decimal Amount { get; set; }
    public string TransactionReference { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string MerchantCode { get; set; }
    public string SortCode { get; set; }
}