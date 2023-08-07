using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data.Entities;
using PaymentAPI.Data.Queries;
using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Enum;
using PaymentAPI.Shared.Helper;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Intermiediary;

namespace PaymentAPI.Data.Repository;

public class TransactionRepository : ITransactionRepository
{
    public PaymentAPIDbContext _context { get; }
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public TransactionRepository(PaymentAPIDbContext context,  IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper;
    }

    public string UpsertTransaction(ITransactionView transactionView, bool isUpdate = false)
    {
        string result = string.Empty;
        var transactionRecord = new Transaction()
        {
            Amount = transactionView.Amount,
            CardId = transactionView.CardId,
            TransactionReference = transactionView.TransactionReference,
            CustomerCode = transactionView.CustomerCode,
            CurrencyId = transactionView.CurrencyId,
            CreatedAt = DateTime.Now,
            MerchantId = transactionView.MerchantId,
            TransactionStatusCode = transactionView.TransactionStatusCode,
            PaymentStatusCode = PaymentResponseEnum.Successful
        };

        try
        {
            if (isUpdate)
            {
                _context.Transactions.Update(transactionRecord);
                _context.SaveChanges();
            }
            else
            {
                _context.Transactions.Add(transactionRecord);
                _context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            result = string.Format("update FulfilmentScriptingPayment - {0} , {1}", e.Message,
                e.InnerException != null ? e.InnerException.Message : "");
        }

        return result;
    }
    
    public async Task<TransactionModel> GetTransactionByReference(string reference)
    {
        var transaction = await _context.Transactions.
            Include(x=>x.Merhcant)
            .Include(x=>x.Currency) .Include(x=>x.Card).
            FirstOrDefaultAsync(x => x.TransactionReference == reference);

        return new TransactionModel()
        {
            Id = transaction.Id,
            MaskedCard = CardMaskingHelper.MaskCardNumber(transaction.Card.CardNumber),
            CurrencyCode = transaction.Currency.Code,
            CardId = transaction.Card.Id,
            MerchantId = transaction.Merhcant.Id,
            CurrencyId = transaction.Currency.Id,
            CVV = transaction.Card.CVV,
            ExpiryYear = transaction.Card.ExpiryYear,
            ExpiryMonth = transaction.Card.ExpiryMonth,
            TransactionReference = transaction.TransactionReference,
            Amount = transaction.Amount,
            TransactionStatusCode = transaction.TransactionStatusCode,
            PaymentStatusCode = transaction.PaymentStatusCode,
            CustomerCode = transaction.CustomerCode,
            CreatedAt = transaction.CreatedAt
        };

    }
    
}