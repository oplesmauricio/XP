using System;
using Romarinho.Domain.Model;

namespace Romarinho.Domain.Services
{
    public interface IOrdemService
    {
        Ordem PegarPorId(int id);
        void Cadastrar(Ordem ordem);
        void Editar(Ordem ordem);
        void Excluir(int id);
        IEnumerable<Ordem> PegarPorIdUsuario(int idUsuario);
    }
}

