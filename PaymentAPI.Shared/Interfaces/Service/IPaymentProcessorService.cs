namespace PaymentAPI.Shared.Interfaces;

public interface IPaymentProcessorService
{
    Task<IPaymentResponse> ProcessPayment(IAcquiererPaymentRequest acquiererPaymentRequest);
}