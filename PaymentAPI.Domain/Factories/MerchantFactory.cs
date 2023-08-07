using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Factories;

public class MerchantFactory : IMerchantFactory
{
    public IMerchantView GetMerchantDetails(IMerchant merchant)
    {
        if (merchant == null)
        {
            return null;
        }
        
        return new MerchantView()
        {
            Id = merchant.Id,
            Code = merchant.Code,
            Name = merchant.Name,
            IsActive = merchant.IsActive
        };
    }
}