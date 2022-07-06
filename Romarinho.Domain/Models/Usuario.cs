using System;
namespace Romarinho.Domain.Models
{
    public class Usuario : Pessoa
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}

