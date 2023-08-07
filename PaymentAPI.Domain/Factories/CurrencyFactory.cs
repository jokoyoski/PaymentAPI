using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Factories;

public class CurrencyFactory : ICurrencyFactory
{
    public async Task<ICurrencyView> GetCurrencyByCode(ICurrency currency)
    {
        return CreateCurrencyView(currency);
    }

    public async Task<ICurrencyListView> GetCurrencies(IList<ICurrency> currencies)
    {
        return new CurrencyListView()
        {
            CurrencyCollections = currencies
        };
    }
    
    
    public async Task<ICurrencyView> GetCurrencyById(ICurrency currency)
    {
        if (currency == null)
        {
            throw new ArgumentNullException(nameof(currency));
        }

        return CreateCurrencyView(currency);
    }

    private ICurrencyView CreateCurrencyView(ICurrency currency)
    {
        if (currency == null)
        {
            return null;
        }

        return new CurrencyView()
        {
            Id = currency.Id,
            Name = currency.Name,
            Code = currency.Code
        };
    }
}



