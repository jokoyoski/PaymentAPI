using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Factories;

public interface IBankFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bank"></param>
    /// <returns></returns>
    IBankView GetBankDetails(IBank bank);
}