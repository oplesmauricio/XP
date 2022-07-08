using System.Net;
using System.Net.WebSockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
//var ordemService = app.Services.GetService<IOrdemService>();

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
            foreach (var ordem in ordens)
            {
                byte[] array;
                //BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    JsonSerializer.Serialize(ms, ordem);
                    //bf.Serialize(ms, ordem);
                    array = ms.ToArray();
                }

                await webSocket.SendAsync(
                    array,
                    //Encoding.ASCII.GetBytes(array),
                    WebSocketMessageType.Text,
                    true, CancellationToken.None);
            }
            await Task.Delay(10000);
        }
    }
});
await app.RunAsync();