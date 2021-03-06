using System;
using Romarinho.App.Model;
using Romarinho.Infra;

namespace Romarinho.App.Services.Interfaces
{
    public interface IOrdensService
    {
        Task<RespostaServico<Ordem>> Buscar(string id);

        Task<RespostaServico<IEnumerable<Ordem>>> Cadastrar(Ordem ordem);

        Task<RespostaServico<string>> Editar(Ordem ordem);

        Task<RespostaServico<IEnumerable<Ordem>>> Deletar(string id);

        Task<RespostaServico<IEnumerable<Ordem>>> BuscarOrdensPorUsuario(string idUsuario);
    }
}

