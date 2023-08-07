using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PaymentAPI.Controllers;
using PaymentAPI.Models;
using PaymentAPI.Shared.Interfaces;
using PaymentAPI.Shared.Interfaces.Service;
using PaymentAPI.Shared.Interfaces.View;
using Xunit;

namespace UnitTests.Controllers;

public class PaymentControllerTests
{
    private readonly Mock<ICurrencyService> _currencyServiceMock;
    private readonly Mock<ICardService> _cardServiceMock;
    private readonly Mock<IBankService> _bankServiceMock;
    private readonly Mock<IMerchantService> _merchantServiceMock;
    private readonly Mock<ITransactionService> _transactionServiceMock;
    private readonly Mock<IPaymentProcessorService> _paymentProcessorServiceMock;

    private PaymentController _paymentController;

    public PaymentControllerTests()
    {
        _currencyServiceMock = new Mock<ICurrencyService>();
        _cardServiceMock = new Mock<ICardService>();
        _bankServiceMock = new Mock<IBankService>();
        _merchantServiceMock = new Mock<IMerchantService>();
        _transactionServiceMock = new Mock<ITransactionService>();
        _paymentProcessorServiceMock = new Mock<IPaymentProcessorService>();

        _paymentController = new PaymentController(
            _currencyServiceMock.Object,
            _paymentProcessorServiceMock.Object,
            _cardServiceMock.Object,
            _merchantServiceMock.Object,
            _transactionServiceMock.Object,
            _bankServiceMock.Object
        );
    }

    [Fact]
    public async Task ProcessTransaction_InvalidModelState_ReturnsBadRequest()
    {
        // Arrange
        _paymentController.ModelState.AddModelError("test", "error");

        // Act
        var result = await _paymentController.ProcessTransaction(new PaymentRequest());

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }

    [Fact]
    public async Task ProcessTransaction_InvalidMerchant_ReturnsBadRequest()
    {
        // Arrange
        _merchantServiceMock.Setup(x => x.GetMerchantByCode(It.IsAny<string>())).ReturnsAsync((IMerchantView)null);

        // Act
        var result = await _paymentController.ProcessTransaction(new PaymentRequest
        {
            MerchantCode = "InvalidMerchantCode"
        });

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid Merchant", badRequestResult.Value);
    }

    // Add more test cases for other scenarios...

    [Fact]
    public async Task GetPaymentDetails_InvalidModelState_ReturnsBadRequest()
    {
        // Arrange
        _paymentController.ModelState.AddModelError("test", "error");

        // Act
        var result = await _paymentController.GetPaymentDetails("ref", "merchantCode");

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);
    }

    [Fact]
    public async Task GetPaymentDetails_InvalidMerchant_ReturnsBadRequest()
    {
        // Arrange
        _merchantServiceMock.Setup(x => x.GetMerchantByCode(It.IsAny<string>())).ReturnsAsync((IMerchantView)null);

        // Act
        var result = await _paymentController.GetPaymentDetails("ref", "InvalidMerchantCode");

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Invalid Merchant", badRequestResult.Value);
    }
    
}
