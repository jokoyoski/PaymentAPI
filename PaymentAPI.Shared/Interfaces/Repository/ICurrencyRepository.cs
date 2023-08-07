namespace PaymentAPI.Shared.Interfaces;

public interface ICurrencyRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<ICurrency> GetCurrencyByCode(string code);
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Currency"></typeparam>
    /// <returns></returns>
    Task <IList<ICurrency>> GetCurrencies();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ICurrency> GetCurrencyById(Guid id);
}