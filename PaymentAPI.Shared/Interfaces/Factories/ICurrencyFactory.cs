using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Factories;

public interface ICurrencyFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<ICurrencyView> GetCurrencyByCode(ICurrency currency);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task <ICurrencyListView> GetCurrencies(IList<ICurrency> currencies);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ICurrencyView> GetCurrencyById(ICurrency currency);
}