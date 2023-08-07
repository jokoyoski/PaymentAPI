using PaymentAPI.Shared.Enum;

namespace PaymentAPI.Shared.Interfaces;

public interface ITransaction
{
    Guid Id { get; set; }
    
    decimal Amount { get; set; }
    
    string TransactionReference { get; set; }
    
    TransactionStatusEnum TransactionStatusCode { get; set; }
    
    PaymentResponseEnum PaymentStatusCode { get; set; }
    
    Guid CardId { get; set; }
    
    Guid MerchantId { get; set; }

    Guid CurrencyId { get; set; }
    
    string CustomerCode { get; set; } // this is only recognised by the merchant
    
    ICard Card { get; set; }
    
    IMerchant Merhcant { get; set; }
    
    ICurrency Currency { get; set; }
    
    DateTime CreatedAt { get; set;  }
}