using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Service;

public interface IBankService
{
    Task<IBankView> GetBankDetails(string sortcode);
}