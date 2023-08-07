using PaymentAPI.Shared.Enum;

namespace PaymentAPI.Shared.Interfaces;

public interface IPaymentResponse
{
     PaymentResponseEnum StatusCode { get; set; }
     
     public string ProcessingMessage { get; set; }
    
     string TransactionReference {get; set; }
}