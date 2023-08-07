namespace PaymentAPI.Shared.Interfaces;

public interface ICurrency
{
    Guid Id { get; set; }
    string Name { get; set; }
    
    string Code { get; set; }
}