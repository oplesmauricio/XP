using System;
using Romarinho.App.Model;

namespace Romarinho.App.Services.Interfaces
{
    public interface IOrdensService
    {
        Task<RespostaServico<IEnumerable<Ordem>>> BuscarOrdens(string id);
    }
}

