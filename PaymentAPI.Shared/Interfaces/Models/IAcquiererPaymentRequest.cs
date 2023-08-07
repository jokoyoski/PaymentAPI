using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces;

public interface IAcquiererPaymentRequest
{
    string CurrencyCode { get; set; }
    decimal Amount { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    string TransactionReference { get; set; }
    string MerchantCode { get; set; }
    string SortCode { get; set; }
}