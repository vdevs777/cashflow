using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities.Cryptography;
public class PasswordEncryptorBuilder
{
    private readonly Mock<IPasswordEncryptor> _mock;

    public PasswordEncryptorBuilder()
    {
        _mock = new Mock<IPasswordEncryptor>();

        _mock.Setup(passwordEncrypter => passwordEncrypter.Encrypt(It.IsAny<string>())).Returns("!%dlfjkd545");
    }

    public PasswordEncryptorBuilder Verify(string? password)
    {
        if (string.IsNullOrWhiteSpace(password) == false)
        {
            _mock.Setup(passwordEncryptor => passwordEncryptor.Verify(password, It.IsAny<string>())).Returns(true);
        }

        return this;
    }

    public IPasswordEncryptor Build() => _mock.Object;
}