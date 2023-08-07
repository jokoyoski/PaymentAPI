using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;

namespace PaymentAPI.Domain.Service;

public class BankService : IBankService
{
    private readonly IBankRepository _bankRepository;
    private readonly IBankFactory _bankFactory;
    public BankService(IBankRepository bankRepository, IBankFactory bankFactory)
    {
        this._bankFactory = _bankFactory;
        this._bankRepository = bankRepository;
    }
    
    public async Task<IBankView> GetBankDetails(string sortcode)
    {
        IBank bank = await this._bankRepository.GetBankBySortCode(sortcode);
        return this._bankFactory.GetBankDetails(bank);
    }
}
