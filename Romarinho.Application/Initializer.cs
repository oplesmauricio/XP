using Microsoft.Extensions.DependencyInjection;
using Romarinho.Domain.Interfaces;
using Romarinho.Domain.Model;
using Romarinho.Domain.Services;
using Romarinho.Repository;

namespace Romarinho.Application;

public class Initializer
{
    public static void Configure(IServiceCollection services, string conection)
    {
        services.AddScoped(typeof(IRepository<Ordem>), typeof(OrdemRepository));
        services.AddScoped(typeof(IOrdemService), typeof(OrdemService));
    }
}


