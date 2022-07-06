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

        public Task<RespostaServico<IEnumerable<Ordem>>> BuscarOrdens(string id)
        {
            return _apiService.GetAsync<IEnumerable<Ordem>>()
        }
    }
}

