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
        Items = new ObservableCollection<Ordem>();
        BorderColorObservable = Microsoft.Maui.Graphics.Color.FromRgb(100, 0, 0);
        BorderColorSetProperty = Microsoft.Maui.Graphics.Color.FromRgb(100, 0, 0);
        BorderColor = "Red";
        this.connectivity = connectivity;

        client = new ClientWebSocket();
        cts = new CancellationTokenSource();
        ConnectToServerAsync();
    }

    //[ObservableProperty]
    //ObservableCollection<Ordem> items;

    [ObservableProperty]
    //Color borderColor;
    string borderColor;

    [ObservableProperty]
    Color borderColorObservable;

    private Color borderColorSetProperty;

    public Color BorderColorSetProperty
    {
        get => borderColorSetProperty;
        set => SetProperty(ref borderColorSetProperty, value);
    }

    private ObservableCollection<Ordem> items;

    public ObservableCollection<Ordem> Items
    {
        get => items;
        set => SetProperty(ref items, value);
    }

    [RelayCommand]
    async Task MinhasOrdens()
    {
        await Shell.Current.GoToAsync($"{nameof(MinhasOrdensPage)}");
    }

    [RelayCommand]
    void Delete(Ordem ordem)
    {
        if (Items.Contains(ordem))
        {
            Items.Remove(ordem);
        }
    }

    [RelayCommand]
    async Task Tap(Ordem ordem)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}");
    }

    async void ConnectToServerAsync()
    {

        ////#if __IOS__
        await client.ConnectAsync(new Uri("ws://mauricionetwork-001-site1.gtempurl.com"), cts.Token);
        //        //await client.ConnectAsync(new Uri("wss://demo.piesocket.com/v3/channel_1?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self"), cts.Token);
        ////#else
        ////      await client.ConnectAsync(new Uri("ws://10.0.2.2:5000"), cts.Token);
        ////#endif


        await Task.Factory.StartNew(async () =>
        {
            try
            {
                while (true)
                {
                    WebSocketReceiveResult result;
                    var message = new ArraySegment<byte>(new byte[4096]);
                    do
                    {
                        result = await client.ReceiveAsync(message, cts.Token);
                        var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();

                        var ordens = await ByteArrayToObjectAsync(messageBytes);
                        //Items = new ObservableCollection<Ordem>(ordens);
                        foreach (var ordem in ordens)
                        {
                            if (!Items.Contains(ordem))
                            {
                                BorderColor = "Blue";
                                BorderColorObservable = Color.FromRgb(0, 0, 255);
                                BorderColorSetProperty = Color.FromRgb(0, 0, 255);
                                Items.Add(ordem);
                            }
                            else
                            {
                                BorderColor = "Red";
                                BorderColorObservable = Color.FromRgb(255, 0, 0);
                                BorderColorSetProperty = Color.FromRgb(255, 0, 0);
                                Items.Remove(ordem);
                                Items.Add(ordem);
                            }
                        }

                    } while (!result.EndOfMessage);
                }

            }
            catch (Exception ex)
            {

            }
        }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }

    readonly ClientWebSocket client;
    readonly CancellationTokenSource cts;
    readonly string username;

    private async Task<List<Ordem>> ByteArrayToObjectAsync(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        //BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        return await JsonSerializer.DeserializeAsync<List<Ordem>>(memStream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        //return obj;
    }
}
