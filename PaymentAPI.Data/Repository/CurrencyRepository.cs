using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data.Entities;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Repository;

public class CurrencyRepository : ICurrencyRepository
{
    public PaymentAPIDbContext _context { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CurrencyRepository(PaymentAPIDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
   /// <summary>
   /// 
   /// </summary>
   /// <param name="code"></param>
   /// <returns></returns>
    public async Task<ICurrency> GetCurrencyByCode(string code)
    {
        var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Code == code);
        return currency;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IList<ICurrency>> GetCurrencies()
    {
        var currencies = await  this._context.Currencies.ToListAsync();
        return currencies.ToList<ICurrency>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ICurrency> GetCurrencyById(Guid id)
    {
        var currency = await _context.Currencies.FirstOrDefaultAsync(x => x.Id == id);
        return currency;
    }
}