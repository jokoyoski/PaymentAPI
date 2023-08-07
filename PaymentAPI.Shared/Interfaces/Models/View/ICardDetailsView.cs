namespace PaymentAPI.Shared.Interfaces.View;

public interface ICardDetailsView
{
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string CVV { get; set; }
}