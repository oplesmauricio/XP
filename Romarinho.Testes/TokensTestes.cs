using Moq;
using Romarinho.Core;
using Romarinho.Domain.Model;
using Romarinho.Infra;

namespace Romarinho.Testes;

public class TokenTestes
{
    [Theory]
    [InlineData("38477992827", "adG/EqWd3VE+KnSqOvoSdMJbKh8f9utRmCeN2L1L3qCkzl+L7ovnEfTK5CyYPT5w")]
    public async System.Threading.Tasks.Task ReverterTokenTeste(string cpf, string token)
    {
        var tokens = new Tokens();
        token = tokens.Base64(token);
        var cpfRetornado = tokens.ReverterToken(token);
        var cpfEsperado = cpf;

        Assert.Equal(cpfEsperado, cpfRetornado);
    }
}