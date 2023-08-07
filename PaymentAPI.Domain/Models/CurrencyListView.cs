using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;


    public class CurrencyListView : ICurrencyListView
    {
        public IList<ICurrency> CurrencyCollections { get; set; }
    }
