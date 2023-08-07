using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Service;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly ICardFactory _cardFactory;
    public CardService(ICardRepository cardRepository, ICardFactory cardFactory)
    {
        this._cardFactory = cardFactory;
        this._cardRepository = cardRepository;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ICardDetailsView> GetCardDetails(string cardNumber)
    {
        ICard card = await _cardRepository.GetCardDetails(cardNumber);
        return this._cardFactory.GetCardDetails(card);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="card"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SaveCard(ICardDetailsView card)
    {
        await this._cardRepository.SaveCard(card);
    }
}