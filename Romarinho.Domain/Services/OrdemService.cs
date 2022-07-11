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
            Mock(ordem);

            _repository.Cadastrar(ordem);
        }

        private static void Mock(Ordem ordem)
        {
            ordem.Assessor = "Romarinho";
            ordem.Ativo = "PETR4";
            ordem.Conta = "Conta";
            ordem.Data = DateTime.Now;
            ordem.ObjDispon = 0;
            ordem.Objetivo = 0;
            ordem.QtdAparente = ordem.Quantidade;
            ordem.QtdCancelada = ordem.Quantidade;
            ordem.QtdDisponivel = ordem.Quantidade;
            ordem.QtdExecutada = 0;
            ordem.Reducao = "";
            ordem.ValorDisponivel = ordem.Valor;
            ordem.Tipo = "C";
            ordem.IdUsuario = 1;
        }

        public void Editar(Ordem ordem)
        {
            Mock(ordem);
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

        public IEnumerable<Ordem> PegarTodas()
        {
            return _repository.PegarTodas();
        }
    }
}

