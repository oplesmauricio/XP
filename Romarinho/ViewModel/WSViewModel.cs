using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Romarinho.App.Model;
using Romarinho.App.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace Romarinho.App.ViewModel;

public partial class WSViewModel : ObservableObject
{
    IConnectivity connectivity;
    public WSViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;

        client = new ClientWebSocket();
        cts = new CancellationTokenSource();
        ConnectToServerAsync();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [RelayCommand]
    async Task MinhasOrdens()
    {
        await Shell.Current.GoToAsync($"{nameof(MinhasOrdensPage)}");
    }

    [RelayCommand]
    void Delete(string s)
    {
        if(Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }

    async void ConnectToServerAsync()
    {

//#if __IOS__
        await client.ConnectAsync(new Uri("ws://localhost:5002"), cts.Token);
        //await client.ConnectAsync(new Uri("wss://demo.piesocket.com/v3/channel_1?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self"), cts.Token);
//#else
//      await client.ConnectAsync(new Uri("ws://10.0.2.2:5000"), cts.Token);
//#endif


        await Task.Factory.StartNew(async () =>
        {
            while (true)
            {
                WebSocketReceiveResult result;
                var message = new ArraySegment<byte>(new byte[4096]);
                do
                {
                    result = await client.ReceiveAsync(message, cts.Token);
                    var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();
                    //string serialisedMessae = Encoding.UTF8.GetString(messageBytes);

                    try
                    {
                        var ordem = ByteArrayToObject(messageBytes);
                        Items.Add(ordem.Ativo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalide message format. {ex.Message}");
                    }

                } while (!result.EndOfMessage);
            }
        }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }

    readonly ClientWebSocket client;
    readonly CancellationTokenSource cts;
    readonly string username;

    private Ordem ByteArrayToObject(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        //BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        return JsonSerializer.Deserialize<Ordem>(memStream);

        //return obj;
    }
}
