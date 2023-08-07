using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Service;

public interface IMerchantService
{
    Task<IMerchantView> GetMerchantByCode(string merchantCode);
}