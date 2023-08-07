using PaymentAPI.Shared.Enum;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;

public class TransactionView : ITransactionView
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
   
   public Guid MerchantId { get; set; }
   public Guid CurrencyId { get; set; }
   public Guid CardId { get; set; }
   
}