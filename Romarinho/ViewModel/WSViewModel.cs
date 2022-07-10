using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Romarinho.App.Model;
using Romarinho.App.Services;
using Romarinho.App.Services.Interfaces;
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
    IConnectivity _connectivity;
    ISettings _settings;
    ClientWebSocket _client;
    CancellationTokenSource _cts;

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

    public WSViewModel(IConnectivity connectivity, ISettings settings)
    {
        this._connectivity = connectivity;
        this._settings = settings;
        this._client = new ClientWebSocket();
        this._cts = new CancellationTokenSource();
        this.Items = new ObservableCollection<Ordem>();
        this.BorderColorObservable = Microsoft.Maui.Graphics.Color.FromRgb(100, 0, 0);
        this.BorderColorSetProperty = Microsoft.Maui.Graphics.Color.FromRgb(100, 0, 0);
        ConnectToServerAsync();
    }

    [ObservableProperty]
    int totalQuantidade;

    [ObservableProperty]
    int totalDisponivel;

    [ObservableProperty]
    Color borderColorObservable;

    [RelayCommand]
    async Task MinhasOrdens()
    {
        await Shell.Current.GoToAsync($"{nameof(MinhasOrdensPage)}");
    }

    async void ConnectToServerAsync()
    {
        try
        {
            await _client.ConnectAsync(new Uri(_settings.UrlSocket), _cts.Token);

            await Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await ReceberOrdens();
                }

            }, _cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Vixi", "Tivemos um problema com servidor das ordens, tente novamente mais tarde", "Ok");

        }
    }

    private async Task ReceberOrdens()
    {
        try
        {
            WebSocketReceiveResult result;
            var message = new ArraySegment<byte>(new byte[4096]);
            do
            {
                result = await _client.ReceiveAsync(message, _cts.Token);
                var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();

                var ordens = await ByteArrayToObjectAsync(messageBytes);
                foreach (var ordem in ordens)
                {
                    if (!Items.Contains(ordem))
                    {
                        ordem.GambiarraDaCor = Color.FromRgb(0, 0, 255);
                        BorderColorObservable = Color.FromRgb(0, 0, 255);
                        BorderColorSetProperty = Color.FromRgb(0, 0, 255);
                        Items.Add(ordem);
                    }
                    else
                    {
                        var ordemAtual = items.Where(m => m.Id == ordem.Id).FirstOrDefault();
                        if (ordemAtual.Valor > ordem.Valor)
                        {
                            ordem.GambiarraDaCor = Color.FromRgb(255, 0, 0);
                            BorderColorObservable = Color.FromRgb(255, 0, 0);
                            BorderColorSetProperty = Color.FromRgb(255, 0, 0);
                        }
                        else if (ordemAtual.Valor < ordem.Valor)
                        {
                            ordem.GambiarraDaCor = Color.FromRgb(255, 255, 0);
                            BorderColorObservable = Color.FromRgb(255, 255, 0);
                            BorderColorSetProperty = Color.FromRgb(255, 255, 0);
                        }
                        else
                        {
                            ordem.GambiarraDaCor = Color.FromHex("#242938");
                        }
                        Items.Remove(ordem);
                        Items.Add(ordem);
                    }
                }

                this.TotalQuantidade = ordens.Count();
            } while (!result.EndOfMessage);
        }
        catch (Exception ex)
        {
        }
    }

    private async Task<IEnumerable<Ordem>> ByteArrayToObjectAsync(byte[] arrayBytes)
    {
        MemoryStream memStream = new MemoryStream();
        memStream.Write(arrayBytes, 0, arrayBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        return await JsonSerializer.DeserializeAsync<IEnumerable<Ordem>>(memStream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }
}
