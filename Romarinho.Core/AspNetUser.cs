using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Romarinho.Core.Interfaces;

namespace Romarinho.Core
{
    public class AspNetUser : IAspNetUser
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor;
        private readonly ITokens _tokens;

        public AspNetUser(Microsoft.AspNetCore.Http.IHttpContextAccessor pHttpContextAccessor, ITokens tokens)
        {
            HttpContextAccessor = pHttpContextAccessor;
            _tokens = tokens;

            if (Claims() != null && Claims().Count() > 0)
            {
                var tokenUsuario = Claims().Where(m => m.Type == "Token").FirstOrDefault().Value;
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(tokenUsuario);
                tokenUsuario = System.Convert.ToBase64String(textoAsBytes);

                this.Token = tokenUsuario;
                this.Cpf = _tokens.ReverterToken(this.Token);
            }
        }

        private IEnumerable<Claim> Claims()
        {
            return HttpContextAccessor.HttpContext.User.Claims;
        }

        public string Cpf { get; }
        public string Token { get; }
    }
}
