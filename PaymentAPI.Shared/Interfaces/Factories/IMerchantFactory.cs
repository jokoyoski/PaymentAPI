using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Factories;

public interface IMerchantFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="merchant"></param>
    /// <returns></returns>
    IMerchantView GetMerchantDetails(IMerchant merchant);
}