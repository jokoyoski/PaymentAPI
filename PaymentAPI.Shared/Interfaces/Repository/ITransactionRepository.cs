using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Intermiediary;

namespace PaymentAPI.Shared.Interfaces;

public interface ITransactionRepository
{
    string UpsertTransaction(ITransactionView transactionView, bool isUpdate);
    Task<TransactionModel> GetTransactionByReference(string reference);
  
}