using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Intermiediary;

namespace PaymentAPI.Domain.Factories;

/*
 * Our factory is used to control our response
 * 
 */
public class TransactionFactory : ITransactionFactory
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
     public ITransactionView GetTransactionDetails(TransactionModel transaction)
     {
        return CreateTransactionView(transaction);
     }
     /// <summary>
     /// 
     /// </summary>
     /// <param name="transactions"></param>
     /// <returns></returns>
     public ITransactionListView GetMerchantTransactions(IList<ITransaction> transactions)
     {
        return new TransactionListView()
        {
        TransactionCollections = transactions
     };
 }
     /// <summary>
     /// 
     /// </summary>
     /// <param name="transaction"></param>
     /// <returns></returns>
     private ITransactionView CreateTransactionView(TransactionModel transaction)
     {
          if (transaction == null)
          {
             return null;
          }

          return new TransactionView()
         { 
             Amount = transaction.Amount,
             MaskedCard =  transaction.MaskedCard,
             CVV = transaction.CVV,
             CustomerCode = transaction.CustomerCode,
             ExpiryYear = transaction.ExpiryYear,
             Id = transaction.Id,
             CardId = transaction.CardId,
             CurrencyId = transaction.CurrencyId,
             CurrencyCode = transaction.CurrencyCode,
             MerchantId = transaction.MerchantId,
             ExpiryMonth = transaction.ExpiryMonth,
             Currency = transaction.Currency,
             CreatedAt = transaction.CreatedAt,
            TransactionStatusCode = transaction.TransactionStatusCode,
            TransactionReference = transaction.TransactionReference,
            PaymentStatusCode = transaction.PaymentStatusCode
        };
     }

 }