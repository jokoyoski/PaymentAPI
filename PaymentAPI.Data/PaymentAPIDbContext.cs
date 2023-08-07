using PaymentAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using PaymentAPI.Shared.Interfaces;

namespace PaymentAPI.Data;
using Microsoft.EntityFrameworkCore;
public class PaymentAPIDbContext : DbContext
{
    public PaymentAPIDbContext(DbContextOptions<PaymentAPIDbContext> options) : base(options)
    {
    }
    
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Transaction>()
            .Property(p => p.Amount)
            .HasPrecision(18, 5); // 18 total digits, with 5 decimal places
        
        
        #region Dummy Record
        modelBuilder.Entity<Merchant>().HasData(
            new Merchant { Id = new Guid("7d8d410e-34d1-11ee-be56-0242ac120002"), Name = "Amazon", IsActive = true, Code = "CHK-1244O4I483"},
            new Merchant { Id = new Guid("830892be-34d1-11ee-be56-0242ac120002"), Name = "Apple", IsActive = true, Code = "CHK-2939494944" },
            new Merchant { Id = new Guid ("830892be-34d2-11ee-be56-0242ac120002"), Name = "Samsung", IsActive = true, Code = "CHK-2934494944" }
        );
        modelBuilder.Entity<Bank>().HasData(
            new Bank { Id = new Guid("0017cd84-34d1-11ee-be56-0242ac120002"), BankName = "HSBC", IsActive = true, SortCode = "000111"},
            new Bank { Id = new Guid("41724ce6-34d1-11ee-be56-0242ac120002"), BankName = "LLoyds", IsActive = true, SortCode = "333444"}
        );
        modelBuilder.Entity<Currency>().HasData(
            new Currency {Code = "NAR", Name = "Naira", Id = new Guid("41724ce6-34d1-11ee-be56-0242ac120002") },
            new Currency { Code = "USD", Name = "Dollars", Id = new Guid("6a243ff0-34d1-11ee-be56-0242ac120002") },
            new Currency { Code = "GBP", Name = "Pounds Sterling", Id = new Guid("715430b4-34d1-11ee-be56-0242ac120002") }
        );
        #endregion
    }
    

}