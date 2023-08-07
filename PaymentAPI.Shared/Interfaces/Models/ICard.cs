namespace PaymentAPI.Shared.Interfaces;

public interface ICard
{
    Guid Id { get; set; }
    
    string CardNumber { get; set; }
    
    int ExpiryMonth { get; set; }
    
    int ExpiryYear { get; set; }
    
    string CVV { get; set; }
}