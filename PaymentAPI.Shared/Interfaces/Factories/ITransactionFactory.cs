using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Intermiediary;

namespace PaymentAPI.Shared.Interfaces.Factories;

public interface ITransactionFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    ITransactionView GetTransactionDetails(TransactionModel transaction);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transactions"></param>
    /// <returns></returns>
    ITransactionListView GetMerchantTransactions(IList<ITransaction> transactions);
    
}