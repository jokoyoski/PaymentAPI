namespace PaymentAPI.Shared.Interfaces;

public interface IMerchantRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<IMerchant> GetMerchantByCode(string code);
}