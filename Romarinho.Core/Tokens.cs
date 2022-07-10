using System;
using System.Text;
using Romarinho.Core.Interfaces;

namespace Romarinho.Core
{
    public class Tokens : ITokens
    {
        public string ReverterToken(string token)
        {
            try
            {
                var textoAsBytes = System.Convert.FromBase64String(token);
                token = Encoding.ASCII.GetString(textoAsBytes);
                token = token.Split(':')[0];
                return Criptografia.Decrypt(token).Split('|')[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Base64(string token)
        {
            try
            {
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(token);
                return System.Convert.ToBase64String(textoAsBytes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
