namespace PaymentAPI.Shared.Helper;

public static class CardValidator
{
    public static bool IsCardNumberValid(string cardNumber)
    {
        // Remove any spaces or non-digit characters from the card number
        cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

        // Check if the card number contains only digits and is of valid length
        if (!long.TryParse(cardNumber, out long cardNumberAsLong) || cardNumber.Length < 13 || cardNumber.Length > 19)
        {
            return false;
        }

        // Apply the Luhn algorithm to validate the card number
        int sum = 0;
        bool isAlternate = false;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';
            
            if (isAlternate)
            {
                digit *= 2;

                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            isAlternate = !isAlternate;
        }

        return sum % 10 == 0;
    }
}