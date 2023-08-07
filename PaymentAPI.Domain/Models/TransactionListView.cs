using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;

public class TransactionListView : ITransactionListView
{
    public IList<ITransaction> TransactionCollections { get; set; }
}