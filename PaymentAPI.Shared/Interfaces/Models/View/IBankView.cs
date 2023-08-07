namespace PaymentAPI.Shared.Interfaces.View;

public interface IBankView
{
    Guid Id { get; set; }
    string BankName { get; set; }
    string SortCode { get; set; }
    bool IsActive { get; set; }
}