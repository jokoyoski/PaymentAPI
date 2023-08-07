using Microsoft.EntityFrameworkCore;
using PaymentAPI.AutoMapper;
using PaymentAPI.Data;
using PaymentAPI.Data.Repository;
using PaymentAPI.Domain.Factories;
using PaymentAPI.Domain.Service;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Factories;
using PaymentAPI.Shared.Interfaces.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*Since my best mode of deployment will be using Amazon ECS, We will use Using AWS Secrets Manager or Parameter Store
           to store our sensitive information*/
var configValue = builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
builder.Services.AddDbContext<PaymentAPIDbContext>(options =>
    options.UseSqlServer(configValue));

#region Dependencies

#region Bank
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankFactory, BankFactory>();
builder.Services.AddScoped<IBankService, BankService>();
#endregion

#region Card
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<ICardFactory, CardFactory>();
builder.Services.AddTransient<ICardService, CardService>();
#endregion

#region Currency
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyFactory, CurrencyFactory>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
#endregion

#region Transaction
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionFactory, TransactionFactory>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
#endregion

#region PaymentProcessor
builder.Services.AddScoped<IPaymentProcessorService, PaymentProcessorService>();
#endregion

#region Merchant
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
builder.Services.AddScoped<IMerchantFactory, MerchantFactory>();
builder.Services.AddScoped<IMerchantService, MerchantService>();
#endregion

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
