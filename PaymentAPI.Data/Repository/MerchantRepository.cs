using Microsoft.EntityFrameworkCore;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data.Repository;

public class MerchantRepository : IMerchantRepository
{
    public PaymentAPIDbContext _context { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public MerchantRepository(PaymentAPIDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IMerchant> GetMerchantByCode(string code)
    {
        var merchant = await _context.Merchants.FirstOrDefaultAsync(x => x.Code == code);
        return merchant;
    }
}