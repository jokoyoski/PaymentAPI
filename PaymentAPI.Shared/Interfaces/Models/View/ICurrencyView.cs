namespace PaymentAPI.Shared.Interfaces.View;

public interface ICurrencyView
{
    Guid Id { get; set; }
    
    string Name { get; set; }
    
    string Code { get; set; }
}