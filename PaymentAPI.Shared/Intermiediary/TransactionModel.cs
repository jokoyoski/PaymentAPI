using PaymentAPI.Shared.Enum;

namespace PaymentAPI.Shared.Intermiediary;

public class TransactionModel
{
    public Guid Id { get; set; }
    
    public decimal Amount { get; set; }
    
    public string TransactionReference { get; set; }
    
    public string CustomerCode { get; set; }
    
    public TransactionStatusEnum TransactionStatusCode { get; set; }
    
    public PaymentResponseEnum PaymentStatusCode { get; set; }
    
    public string CVV { get; set; }
    
    public int ExpiryYear { get; set; } 
    
    public int ExpiryMonth { get; set; } 
    
    public string CurrencyCode { get; set;  }
   
    public string MaskedCard { get; set; }
    
    public string Currency { get; set; }
    
    public DateTime CreatedAt { get; set;  }
    
    public Guid CardId { get; set; }
    public Guid MerchantId { get; set; }
    public Guid CurrencyId { get; set; }
    
}