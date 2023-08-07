using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Domain.Models;
using PaymentAPI.Models;
using PaymentAPI.Shared.Enum;
using PaymentAPI.Shared.Helper;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Proxy;

namespace PaymentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    #region Properties
    private readonly ICurrencyService _currencyService;
    private readonly ICardService _cardService;
    private readonly IBankService _bankService;
    private readonly IMerchantService _merchantService;
    private readonly ITransactionService _transactionService;
    private readonly IPaymentProcessorService _paymentProcessorService;
    #endregion
    
    #region Constructor
    public PaymentController(ICurrencyService currencyService,IPaymentProcessorService paymentProcessorService, ICardService cardService, IMerchantService merchantService, ITransactionService transactionService, IBankService bankService)
    {
        _currencyService = currencyService;
        _cardService = cardService;
        _paymentProcessorService = paymentProcessorService;
        _merchantService = merchantService;
        _transactionService = transactionService;
        _bankService = bankService;
    }
    #endregion
   
    [HttpPost]
    [Route("initiate")]
    public async Task<IActionResult> ProcessTransaction(PaymentRequest paymentRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

         // Validate merchant
        var merchant = await GetValidMerchant(paymentRequest.MerchantCode);
        if (merchant == null)
        {
            return BadRequest("Invalid Merchant");
        }

        // Validate currency
        var currency = await GetValidCurrency(paymentRequest.CurrencyCode);
        if (currency == null)
        {
            return BadRequest("Invalid Currency");
        }

        // Get or create card record
        var cardRecord = await GetOrCreateCard(
            paymentRequest.CardNumber,
            paymentRequest.CVV,
            paymentRequest.ExpiryMonth,
            paymentRequest.ExpiryYear
        );

       // Create transaction view
        var transactionView = CreateTransactionView(
            paymentRequest.Amount,
            merchant.Id,
            currency.Id,
            cardRecord.Id,
            paymentRequest.CustomerCode
        );

         // Upsert transaction
        _transactionService.UpsertTransaction(transactionView, false);

        // Create acquirer payment request
        var acquirerPaymentRequest = CreateAcquirerPaymentRequest(paymentRequest, transactionView);

        // Process payment
        IPaymentResponse paymentResponse = await _paymentProcessorService.ProcessPayment(acquirerPaymentRequest);

        // Update transaction status
        var updatedTransaction = await UpdateTransactionStatus(transactionView, paymentResponse);

        // Build response model
        var responseModel = new
        {
            TransactionReference = updatedTransaction.TransactionReference,
            StatusCode = updatedTransaction.TransactionStatusCode
        };

        return Ok(responseModel);
    }
    
    
    [HttpGet]
    [Route("payments/{paymentRef}/{merchantCode}")]
    public async Task<IActionResult> GetPaymentDetails(string paymentRef, string merchantCode)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Validate merchant
        var merchant = await GetValidMerchant(merchantCode);
        if (merchant == null)
        {
            return BadRequest("Invalid Merchant");
        }
         // Validate tranRef
        var transaction = await _transactionService.GetTransactionByReference(paymentRef);
        if (transaction == null)
        {
            return BadRequest("Invalid TransactionRef");
        }
        // Validate the order is for the merchan
        //TO DO this can be moved down to the repository level
        if (transaction.MerchantId != merchant.Id)
        {
            return BadRequest("You are not allowed to view this TransactionRef");
        }

        return Ok(transaction);
    }

    private async Task<IMerchantView> GetValidMerchant(string merchantCode)
    {
        var merchant = await _merchantService.GetMerchantByCode(merchantCode);
        
        return merchant;
    }
    

    private async Task<ICurrencyView> GetValidCurrency(string currencyCode)
    {
        var currency = await _currencyService.GetCurrencyByCode(currencyCode);

        return currency;
    }
    
    private async Task<ICardDetailsView> GetOrCreateCard(string cardNumber, string cvv, int expiryMonth, int expiryYear)
    {
       
        var cardRecord = await this._cardService.GetCardDetails(cardNumber);

        if (cardRecord is null)
        {
            cardRecord = CreateCardDetailsView(cardNumber, cvv, expiryMonth, expiryYear);
            await _cardService.SaveCard(cardRecord); //TO DO Validate that card is saved before proceeding with other flow
        }

        return cardRecord;
    }

    private ICardDetailsView CreateCardDetailsView(string cardNumber, string cvv, int expiryMonth, int expiryYear)
    {
        return new CardDetailsView
        {
            CardNumber = cardNumber,
            CVV = cvv,
            ExpiryMonth = expiryMonth,
            ExpiryYear = expiryYear
        };
    }
    private ITransactionView CreateTransactionView(decimal amount, Guid merchantId, Guid currencyId, Guid cardId, string CustomerCode)
    {
        return new TransactionView
        {
            Id = Guid.NewGuid(),
            TransactionReference = new TransactionGenerator().GenerateTransactionReference(10), //TO DO Find a better way to generate ref
            Amount = amount,
            CreatedAt = DateTime.Now,
            CustomerCode = CustomerCode,
            MerchantId = merchantId,
            CardId = cardId,
            CurrencyId = currencyId,
            TransactionStatusCode = TransactionStatusEnum.TransactionCreated,
            PaymentStatusCode = PaymentResponseEnum.NotStarted
        };
    }
    private AcquiererPaymentRequest CreateAcquirerPaymentRequest(PaymentRequest paymentRequest, ITransactionView transactionView)
    {
        return new AcquiererPaymentRequest
        {
            CurrencyCode = paymentRequest.CurrencyCode,
            Amount = transactionView.Amount,
            CVV = paymentRequest.CVV,
            CardNumber = paymentRequest.CardNumber,
            ExpiryMonth = paymentRequest.ExpiryMonth,
            ExpiryYear = paymentRequest.ExpiryYear,
            TransactionReference = transactionView.TransactionReference,
            MerchantCode = paymentRequest.MerchantCode,
            CustomerCode = paymentRequest.CustomerCode,
        };
    }
    private async Task<ITransactionView> UpdateTransactionStatus(ITransactionView transactionView, IPaymentResponse paymentResponse)
    {
        // Get the transaction by reference
        var existingTransaction = await _transactionService.GetTransactionByReference(transactionView.TransactionReference);

        // Update the transaction status based on payment response
        var newTransactionStatus = paymentResponse.StatusCode == PaymentResponseEnum.Successful
            ? TransactionStatusEnum.TransactionSuccessful
            : TransactionStatusEnum.TransactionFailed;

        // Update the payment status code
        existingTransaction.TransactionStatusCode = newTransactionStatus;
        existingTransaction.PaymentStatusCode = paymentResponse.StatusCode;

        // Update the transaction in the database
        _transactionService.UpsertTransaction(existingTransaction, true);

         // Return the updated transaction
        return existingTransaction;
    }
    
    
}