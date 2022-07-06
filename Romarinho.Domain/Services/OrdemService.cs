using System;
using Romarinho.Domain.Interfaces;
using Romarinho.Domain.Model;

namespace Romarinho.Domain.Services
{
    public class OrdemService : IOrdemService
    {
        private readonly IRepository<Ordem> _repository;

        public OrdemService(IRepository<Ordem> repository)
        {
            _repository = repository;
        }

        public void Cadastrar(Ordem ordem)
        {
            _repository.Cadastrar(ordem);
        }

        public void Editar(Ordem ordem)
        {
            _repository.Editar(ordem);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }

        public Ordem PegarPorId(int id)
        {
            return _repository.PegarPorId(id);
        }

        public IEnumerable<Ordem> PegarPorIdUsuario(int idUsuario)
        {
            return _repository.PegarPorIdUsuario(idUsuario);
        }
    }
}

