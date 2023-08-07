using System.ComponentModel.DataAnnotations;
using PaymentAPI.Shared.Interfaces;


namespace PaymentAPI.Data.Entities;

public class Card : ICard
{
    [Key]
    public Guid Id { get; set; }
    public string CardNumber { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public string CVV { get; set; }
}