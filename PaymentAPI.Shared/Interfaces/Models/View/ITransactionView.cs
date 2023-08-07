using PaymentAPI.Shared.Enum;

namespace PaymentAPI.Shared.Interfaces.View;

public interface ITransactionView
{
    Guid Id { get; set; }
    
    decimal Amount { get; set; }
    
    string TransactionReference { get; set; }
    
    string CustomerCode { get; set; }
    
    TransactionStatusEnum TransactionStatusCode { get; set; }
    
    PaymentResponseEnum PaymentStatusCode { get; set; }
    
    string CVV { get; set; }
    
    int ExpiryYear { get; set; } 
    
    int ExpiryMonth { get; set; } 
    
    string CurrencyCode { get; set;  }
   
    string MaskedCard { get; set; }
    
    string Currency { get; set; }
    
    DateTime CreatedAt { get; set;  }
    
    Guid MerchantId { get; set; }
    Guid CurrencyId { get; set; }
    Guid CardId { get; set; }
}