using System;
using Romarinho.Domain.Models;

namespace Romarinho.App.Model.Interfaces
{
    public interface IContexto
    {
        Usuario UsuarioLogado { get; set; }
        void SetarUsuarioContexto(Usuario usuario);
    }
}

