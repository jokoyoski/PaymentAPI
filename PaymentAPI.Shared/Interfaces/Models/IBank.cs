namespace PaymentAPI.Shared.Interfaces;

public interface IBank
{
    Guid Id { get; set; }
    string BankName { get; set; }
    string SortCode { get; set; }
    bool IsActive { get; set; }
}