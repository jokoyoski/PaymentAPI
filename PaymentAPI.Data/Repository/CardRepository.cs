using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data.Entities;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Data.Repository;

public class CardRepository : ICardRepository
{
    public PaymentAPIDbContext _context { get; }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="context"></param>
   /// <exception cref="ArgumentNullException"></exception>
    public CardRepository(PaymentAPIDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
   
   public async Task<ICard> GetCardDetails(string cardNumber)
   {
       var card = await _context.Cards.FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
       return card;
   }

    
   public async Task<string> SaveCard(ICardDetailsView card)
    {
        string result = string.Empty;
        var cardRecord = new Card
        {
            CardNumber = card.CardNumber,
            CVV = card.CVV,
            ExpiryMonth = card.ExpiryMonth,
            ExpiryYear = card.ExpiryYear,
            Id = new Guid()
        };

        try
        {
                _context.Cards.Add(cardRecord);
                _context.SaveChanges();
        }
        catch (Exception e)
        {
            result = string.Format("update FulfilmentScriptingPayment - {0} , {1}", e.Message,
                e.InnerException != null ? e.InnerException.Message : "");
        }

        return result;
    }
}