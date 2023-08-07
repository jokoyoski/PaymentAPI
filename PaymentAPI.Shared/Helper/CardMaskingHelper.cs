namespace PaymentAPI.Shared.Helper;

public static class CardMaskingHelper
{
    public static string MaskCardNumber(string cardNumber)
    {
        if (string.IsNullOrEmpty(cardNumber))
        {
            return string.Empty;
        }

        int visibleLength = 4; // Number of visible digits at the end
        int totalDigits = cardNumber.Length;

        if (totalDigits <= visibleLength)
        {
            return cardNumber; // No need to mask if the card number is too short
        }

        string maskedPart = new string('*', totalDigits - visibleLength);
        string visiblePart = cardNumber.Substring(totalDigits - visibleLength);

        return maskedPart + visiblePart;
    }
}
