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
       string result = String.Empty;
        try
        {
            var cardRecord = new Card
            {
                CardNumber = card.CardNumber,
                CVV = card.CVV,
                ExpiryMonth = card.ExpiryMonth,
                ExpiryYear = card.ExpiryYear,
                Id = Guid.NewGuid()
            };

            _context.Cards.Add(cardRecord);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            result = $"Error adding card record: {e.Message}, Inner: {e.InnerException?.Message}";
        }
        catch (Exception e)
        {
            result = $"An unexpected error occurred: {e.Message}";
        }

        return result;

    }
}