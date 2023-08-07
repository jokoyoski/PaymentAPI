using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Service;

public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRepository _currencyRepository;
    private readonly ICurrencyFactory _currencyFactory;
    public CurrencyService(ICurrencyRepository currencyRepository, ICurrencyFactory currencyFactory)
    {
        this._currencyFactory = currencyFactory;
        this._currencyRepository = currencyRepository;
    }
    public async Task<ICurrencyView> GetCurrencyByCode(string code)
    {
        ICurrency currency = await _currencyRepository.GetCurrencyByCode(code);
        return await _currencyFactory.GetCurrencyByCode(currency);
    }

    public async Task<ICurrencyListView> GetCurrencies()
    {
        IList<ICurrency> currencies = await _currencyRepository.GetCurrencies();
        return await _currencyFactory.GetCurrencies(currencies);
    }

    public async Task<ICurrencyView> GetCurrencyById(Guid id)
    {
        ICurrency currency = await _currencyRepository.GetCurrencyById(id);
        return await _currencyFactory.GetCurrencyById(currency);
    }
}