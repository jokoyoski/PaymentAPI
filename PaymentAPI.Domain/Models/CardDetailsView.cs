using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Models;

public class CardDetailsView : ICardDetailsView
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string CVV { get; set; }
}