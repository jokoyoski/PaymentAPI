using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces;

public interface ICardRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    Task<ICard> GetCardDetails(string cardNumber);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="card"></param>
    Task<string> SaveCard(ICardDetailsView card);
}