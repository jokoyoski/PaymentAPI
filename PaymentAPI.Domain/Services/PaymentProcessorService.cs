using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Simulator;

namespace PaymentAPI.Domain.Service;

public class PaymentProcessorService : IPaymentProcessorService
{
    public async Task<IPaymentResponse> ProcessPayment(IAcquiererPaymentRequest acquiererPaymentRequest)
    {
        SwitchSDK switchSDK = new SwitchSDK();
        IPaymentResponse paymentResponse = switchSDK.ProcessTransaction(acquiererPaymentRequest);
        return paymentResponse;
    }
}