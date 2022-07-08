using System;
using Romarinho.Domain.Model;

namespace Romarinho.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity PegarPorId(int id);
        IEnumerable<TEntity> PegarPorIdUsuario(int idUsuario);
        void Cadastrar(TEntity entity);
        void Editar(TEntity entity);
        void Excluir(int id);
        IEnumerable<Ordem> PegarTodas();
    }
}

