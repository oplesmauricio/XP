using System;
using Romarinho.App.Model;
using Romarinho.App.Services.Interfaces;

namespace Romarinho.App.Services
{
    public class OrdensService : IOrdensService
    {
        private IApiService _apiService;
        public OrdensService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<RespostaServico<Ordem>> Buscar(string id)
        {
            return _apiService.GetAsync<Ordem>($"Ordem/{ id }");
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> Cadastrar(Ordem ordem)
        {
            return _apiService.PostAsync<IEnumerable<Ordem>>(ordem, $"Ordem/");
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> Editar(Ordem ordem)
        {
            return _apiService.PutAsync<IEnumerable<Ordem>>(ordem, $"Ordem/");
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> Deletar(string id)
        {
            return _apiService.DeleteAsync<IEnumerable<Ordem>>($"Ordem/{ id }");
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> BuscarOrdensPorUsuario(string idUsuario)
        {
            return _apiService.GetAsync<IEnumerable<Ordem>>($"Ordem/GetByUser/{ idUsuario }");
        }
    }
}

