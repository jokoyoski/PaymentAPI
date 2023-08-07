using System.Text;

namespace PaymentAPI.Shared.Helper;

public  class TransactionGenerator
{
    private readonly Random _random = new Random();
    private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public string GenerateTransactionReference(int length)
    {
        var stringBuilder = new StringBuilder(length);
        
        for (int i = 0; i < length; i++)
        {
            int randomIndex = _random.Next(AllowedChars.Length);
            stringBuilder.Append(AllowedChars[randomIndex]);
        }

        return stringBuilder.ToString();
    }
}
