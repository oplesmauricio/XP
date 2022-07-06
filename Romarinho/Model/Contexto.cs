using Romarinho.App.Model;
using Romarinho.App.Model.Interfaces;
using Romarinho.Domain.Models;

[assembly: Dependency(typeof(Contexto))]
namespace Romarinho.App.Model
{
    public class Contexto : IContexto
    {
        public Contexto()
        {
        }

        public Usuario UsuarioLogado { get; set; }

        public void SetarUsuarioContexto(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}