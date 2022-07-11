using Moq;
using Romarinho.Core;
using Romarinho.Domain.Model;
using Romarinho.Infra;

namespace Romarinho.Testes;

public class CriptografiaTestes
{
    [Theory]
    [InlineData("romarinho", "mPVCMXB4qcKzXFjiR3mmRQ==")]
    [InlineData("Romarinho", "I2iY0ESssCuWpA3xwDhP7w==")]
    public async System.Threading.Tasks.Task EncryptTeste(string romarinho, string romarinhoCriptografado)
    {
        var romarinhoRetornado = Criptografia.Encrypt(romarinho);
        var romarinhoEsperado = romarinhoCriptografado;

        Assert.Equal(romarinhoEsperado, romarinhoRetornado);
    }

    [Theory]
    [InlineData("romarinho", "mPVCMXB4qcKzXFjiR3mmRQ==")]
    [InlineData("Romarinho", "I2iY0ESssCuWpA3xwDhP7w==")]
    public async System.Threading.Tasks.Task DecryptTeste(string romarinho, string romarinhoCriptografado)
    {
        var romarinhoRetornado = Criptografia.Decrypt(romarinhoCriptografado);
        var romarinhoEsperado = romarinho;

        Assert.Equal(romarinhoEsperado, romarinhoRetornado);
    }
}