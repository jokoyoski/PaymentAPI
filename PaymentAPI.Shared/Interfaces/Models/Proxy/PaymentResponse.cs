using PaymentAPI.Shared.Enum;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Shared.Proxy;

public class PaymentResponse : IPaymentResponse
{
    public PaymentResponseEnum StatusCode { get; set; }
    
    public string ProcessingMessage { get; set; }
    
    public string TransactionReference {get; set; }
}