using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Factories;

public interface ICardFactory
{
    ICardDetailsView GetCardDetails(ICard card);
}