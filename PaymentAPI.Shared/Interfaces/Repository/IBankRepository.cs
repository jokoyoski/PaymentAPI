namespace PaymentAPI.Shared.Interfaces;

public interface IBankRepository
{ 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bank"></param>
    /// <returns></returns>
    Task<IBank> GetBankBySortCode(string bank);
}