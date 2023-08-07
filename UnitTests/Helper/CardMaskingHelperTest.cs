using PaymentAPI.Shared.Helper;
using Xunit;

namespace UnitTests.Helper;

public class CardMaskingHelperTest
{
    [Fact]
    public void MaskCardNumber_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string cardNumber = string.Empty;

        // Act
        string maskedCard = CardMaskingHelper.MaskCardNumber(cardNumber);

        // Assert
        Assert.Equal(string.Empty, maskedCard);
    }
    [Fact]
    public void MaskCardNumber_ShortCardNumber_ReturnsOriginalNumber()
    {
        // Arrange
        string cardNumber = "123";

        // Act
        string maskedCard = CardMaskingHelper.MaskCardNumber(cardNumber);

        // Assert
        Assert.Equal(cardNumber, maskedCard);
    }
    [Fact]
    public void MaskCardNumber_LongCardNumber_ReturnsMaskedNumber()
    {
        // Arrange
        string cardNumber = "4111111111111111";
        string expectedMasked = "************1111";

        // Act
        string maskedCard = CardMaskingHelper.MaskCardNumber(cardNumber);

        // Assert
        Assert.Equal(expectedMasked, maskedCard);
    }
    [Fact]
    public void MaskCardNumber_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string cardNumber = null;

        // Act
        string maskedCard = CardMaskingHelper.MaskCardNumber(cardNumber);

        // Assert
        Assert.Equal(string.Empty, maskedCard);
    }

}