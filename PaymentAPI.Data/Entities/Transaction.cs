using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PaymentAPI.Shared.Enum;
using PaymentAPI.Shared.Interfaces;


namespace PaymentAPI.Data.Entities;

public class Transaction 
{
    [Key]
    public Guid Id { get; set; }
    
    [DataType("decimal(18,5)")]
    public decimal Amount { get; set; }
    
    public string TransactionReference { get; set; }
    
    public string CustomerCode { get; set; }
    
    public TransactionStatusEnum TransactionStatusCode { get; set; }
    
    public PaymentResponseEnum PaymentStatusCode { get; set; }
    
    public Guid CardId { get; set; }
    
    public Guid MerchantId { get; set; } 
    
    public Guid CurrencyId { get; set;  }
   
    public Card Card { get; set; }
    
    public Merchant Merhcant { get; set; }
    public Currency Currency { get; set; }
    
    public DateTime CreatedAt { get; set;  }
    
}