namespace PaymentAPI.Shared.Interfaces.Service;

public interface IPaymentProcessor
{
    Task<string> ProcessPayment(ICard card , decimal amount);
}