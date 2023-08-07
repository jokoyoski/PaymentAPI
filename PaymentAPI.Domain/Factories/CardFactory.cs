using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Factories;

public class CardFactory : ICardFactory
{
    public ICardDetailsView GetCardDetails(ICard card)
    {
        if (card == null)
        {
            return null;
        }

        return new CardDetailsView()
        {
            CardNumber = card.CardNumber,
            CVV = card.CVV,
            ExpiryMonth = card.ExpiryMonth,
            Id = card.Id,
            ExpiryYear = card.ExpiryYear
        };
    }
}