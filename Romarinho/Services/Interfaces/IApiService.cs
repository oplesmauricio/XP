
using System;
using Romarinho.App.Model;

namespace Romarinho.App.Services.Interfaces
{
    public interface IApiService
    {
        Task<RespostaServico<T>> PostAsync<T>(object item, string url);

        Task<RespostaServico<T>> GetAsync<T>(string url);

        Task<RespostaServico<T>> PutAsync<T>(object item, string url);

        Task<RespostaServico<T>> DeleteAsync<T>(string url);

        Task<RespostaServico<T>> PostAnonymousAsync<T>(object item, string url);
    }
}

