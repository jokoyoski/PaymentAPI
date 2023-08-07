namespace PaymentAPI.Shared.Interfaces.View;

    public interface ICurrencyListView
    {
        IList<ICurrency> CurrencyCollections { get; set; }
    }
