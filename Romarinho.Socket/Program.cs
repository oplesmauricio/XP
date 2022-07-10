using System.Net;
using System.Net.WebSockets;
using System.Text.Json;
using Romarinho.Domain.Interfaces;
using Romarinho.Domain.Model;
using Romarinho.Domain.Services;
using Romarinho.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient(typeof(IRepository<Ordem>), typeof(OrdemRepository));
builder.Services.AddTransient(typeof(IOrdemService), typeof(OrdemService));

var app = builder.Build();
var ordemService = (OrdemService)app.Services.GetServices(typeof(IOrdemService)).FirstOrDefault();

app.UseWebSockets();

app.Map("/", async context =>
{
    if (!context.WebSockets.IsWebSocketRequest)
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    else
    {
        var random = new Random();
        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        while (true)
        {
            var ordens = ordemService.PegarTodas();

            byte[] array;
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, ordens);
                array = ms.ToArray();
            }

            await webSocket.SendAsync(
                array,
                WebSocketMessageType.Text,
                true, CancellationToken.None);
            await Task.Delay(2000);

            var ordensQuaisquer = ordens.Where(m => m.IdUsuario == 2);

            foreach (var ordemQualquer in ordensQuaisquer)
            {
                ordemQualquer.Valor = random.Next(1, 200);
                ordemQualquer.Quantidade = random.Next(1, 200);
                ordemService.Editar(ordemQualquer);
            }
        }
    }
});
await app.RunAsync();