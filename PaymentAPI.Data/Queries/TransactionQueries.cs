using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data.Entities;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Queries;

public class TransactionQueries
{
    internal static IEnumerable<Transaction> GetTransactionsForMerchant(PaymentAPIDbContext _context, Guid  merchantId)
    {
        var transactions = _context.Transactions
            .Where(x => x.MerchantId == merchantId)
            .Include(x => x.Currency)
            .Select(x => new Transaction()
            {
                Id = x.Id,
                MerchantId = x.Id,
                Amount = x.Amount,
                CustomerCode = x.CustomerCode,
                CardId = x.CardId,
                CurrencyId = x.CurrencyId,
                CreatedAt = x.CreatedAt,
                TransactionStatusCode = x.TransactionStatusCode,
                PaymentStatusCode = x.PaymentStatusCode
            })
            .ToList();
        return transactions;
    }
}