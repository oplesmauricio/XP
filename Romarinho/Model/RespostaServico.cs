using System;
namespace Romarinho.App.Model
{
    public class RespostaServico<T>
    {
        public string HttpStatus { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Resposta { get; set; }
    }
}

