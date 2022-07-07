using System;
using Romarinho.App.Model;
using Romarinho.App.Services.Interfaces;
using Romarinho.Infra;

namespace Romarinho.App.Services
{
    public class OrdensService : IOrdensService
    {
        private IApiService _apiService;
        private ISettings _settings;
        private List<KeyValuePair<string, string>> _headers;

        public OrdensService(IApiService apiService, ISettings settings)
        {
            _apiService = apiService;
            _settings= settings;
            _headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>
                    (
                        "Authorization",
                        _settings.Token
                    )
                };
        }

        public Task<RespostaServico<Ordem>> Buscar(string id)
        {
            return _apiService.GetAsync<Ordem>($"{ _settings.UrlApi }Ordem/{ id }", _headers);
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> Cadastrar(Ordem ordem)
        {
            return _apiService.PostAsync<IEnumerable<Ordem>>(ordem, $"{ _settings.UrlApi }Ordem/", _headers);
        }

        public Task<RespostaServico<string>> Editar(Ordem ordem)
        {
            return _apiService.PutAsync<string>(ordem, $"{ _settings.UrlApi }Ordem/", _headers);
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> Deletar(string id)
        {
            return _apiService.DeleteAsync<IEnumerable<Ordem>>($"{ _settings.UrlApi }Ordem/{ id }", _headers);
        }

        public Task<RespostaServico<IEnumerable<Ordem>>> BuscarOrdensPorUsuario(string idUsuario)
        {
            return _apiService.GetAsync<IEnumerable<Ordem>>($"{ _settings.UrlApi }Ordem/GetByUser/{ idUsuario }", _headers);
        }
    }
}

