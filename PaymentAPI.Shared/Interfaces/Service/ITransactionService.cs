using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Service;

public interface ITransactionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transactionView"></param>
    /// <param name="isUpdate"></param>
    /// <returns></returns>
    string UpsertTransaction(ITransactionView transactionView, bool isUpdate);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="reference"></param>
    /// <returns></returns>
    Task<ITransactionView> GetTransactionByReference(string reference);
}