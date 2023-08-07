using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Shared.Interfaces.Service;

public interface ICardService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    Task<ICardDetailsView> GetCardDetails(string cardNumber);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="card"></param>
    Task SaveCard(ICardDetailsView card);
}