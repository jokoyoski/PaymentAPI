using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Intermiediary;

namespace PaymentAPI.Domain.Service;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ITransactionFactory _transactionFactory;
    public TransactionService(ITransactionRepository transactionRepository, ITransactionFactory transactionFactory)
    {
        this._transactionFactory = transactionFactory;
        this._transactionRepository = transactionRepository;
    }
    
    public string UpsertTransaction(ITransactionView transactionView, bool isUpdate)
    {
        return _transactionRepository.UpsertTransaction(transactionView, isUpdate);
    }

    public async Task<ITransactionView> GetTransactionByReference(string reference)
    {
        TransactionModel transaction = await _transactionRepository.GetTransactionByReference(reference);
        return _transactionFactory.GetTransactionDetails(transaction);
    }
    
}