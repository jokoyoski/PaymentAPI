using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Service;

public class MerchantService : IMerchantService
{
    private readonly IMerchantRepository _merchantRepository;
    private readonly IMerchantFactory _merchantFactory;
    public MerchantService(IMerchantRepository merchantRepository, IMerchantFactory merchantFactory)
    {
        this._merchantFactory = merchantFactory;
        this._merchantRepository = merchantRepository;
    }
    public async Task<IMerchantView> GetMerchantByCode(string merchantCode)
    {
        IMerchant merchant = await this._merchantRepository.GetMerchantByCode(merchantCode);
        return this._merchantFactory.GetMerchantDetails(merchant);
    }

   
}