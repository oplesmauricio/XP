using System;
namespace Romarinho.Core.Interfaces
{
    public interface ITokens
    {
        string ReverterToken(string token);
        string Base64(string token);
    }
}
