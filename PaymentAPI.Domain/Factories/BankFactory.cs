using PaymentAPI.Domain.Models;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Factories;

public class BankFactory : IBankFactory
{
    public IBankView GetBankDetails(IBank bank)
    {
        if (bank == null)
        {
            throw new ArgumentNullException(nameof(bank));
        }

        return new BankView()
        {
            Id = bank.Id,
            BankName = bank.BankName,
            SortCode = bank.SortCode,
            IsActive = bank.IsActive
        };
    }
}