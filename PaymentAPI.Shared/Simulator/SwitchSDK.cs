using System.Transactions;
using PaymentAPI.Shared.Interfaces.View;
using PaymentAPI.Shared.Proxy;
using System.Collections.Generic;
using PaymentAPI.Shared.Enum;
using PaymentAPI.Shared.Interfaces;


namespace PaymentAPI.Shared.Simulator;

public class SwitchSDK
{
    public PaymentResponse ProcessTransaction(IAcquiererPaymentRequest acquirerPaymentRequest)
    {
        var response = new PaymentResponse();

        string cardResponse = ValidateCard(acquirerPaymentRequest);

        if (cardResponse == PaymentResponseEnum.CardOK.ToString())
        {
            response.StatusCode = MapAmountToStatusCode(acquirerPaymentRequest.Amount);
        }
        else
        {
            // Set a fallback status code response here if needed
            // response.StatusCode = PaymentResponseEnum.FallbackStatusCode;
        }

        response.TransactionReference = acquirerPaymentRequest.TransactionReference;

        return response;
    }
    
    private PaymentResponseEnum MapAmountToStatusCode(decimal amount)
    {
        switch (amount)
        {
            case 2000:
                return PaymentResponseEnum.Timeout;
            case 4200:
                return PaymentResponseEnum.CardBlacklisted;
            case 20:
                return PaymentResponseEnum.InsufficientFunds;
            case 9000:
                return PaymentResponseEnum.PaymentBlocked;
            case 5000:
                return PaymentResponseEnum.BadTrackData;
            case 10000:
                return PaymentResponseEnum.DeclinedDoNotHonour;
            default:
                return PaymentResponseEnum.Successful;
        }
    }
    
    static bool IsExpired(int month, int year)
    {
        DateTime currentDate = DateTime.Now;
        DateTime inputDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        return currentDate > inputDate;
    }
    
    private string ValidateCard(IAcquiererPaymentRequest acquiererPaymentRequest)
    {
        if (acquiererPaymentRequest.CardNumber.Length < 10)
        {
            return PaymentResponseEnum.InvalidCard.ToString();
        }

        if (acquiererPaymentRequest.CVV.Length < 2 || acquiererPaymentRequest.CVV.Length > 3)
        {
            return PaymentResponseEnum.CVVNotOk.ToString();
        }

        if (IsExpired(acquiererPaymentRequest.ExpiryMonth, acquiererPaymentRequest.ExpiryYear))
        {
            return PaymentResponseEnum.CardExpired.ToString();
        }

        return PaymentResponseEnum.CardOK.ToString();
    }
}