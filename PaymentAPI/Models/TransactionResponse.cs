using PaymentAPI.Shared.Enum;

namespace PaymentAPI.Models;

public class TransactionResponse
{
    public TransactionStatusEnum StatusCode;
    public string TransactionReference;
}