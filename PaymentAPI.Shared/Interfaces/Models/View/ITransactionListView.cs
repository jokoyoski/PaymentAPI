namespace PaymentAPI.Shared.Interfaces.View;

public interface ITransactionListView
{
    IList<ITransaction> TransactionCollections { get; set; }
}