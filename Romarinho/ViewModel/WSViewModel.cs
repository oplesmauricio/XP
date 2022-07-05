using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Romarinho.App.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;

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
        //messages = new ObservableCollection<Message>();

        //this.username = username;

        ConnectToServerAsync();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
        //using var ws = new ClientWebSocket();
        //await ws.ConnectAsync(new Uri("wss://demo.piesocket.com/v3/channel_1?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self"), CancellationToken.None);

        //var buffer = new byte[256];
        //while (ws.State == WebSocketState.Open)
        //{
        //    var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
        //    if (result.MessageType == WebSocketMessageType.Close)
        //        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        //    else
        //        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, result.Count));
        //}
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



    public bool IsConnected => client.State == WebSocketState.Open;

    public Command SendMessage => sendMessageCommand ??
        (sendMessageCommand = new Command<string>(SendMessageAsync, CanSendMessage));

    //public ObservableCollection<Message> Messages => messages;

    public string MessageText
    {
        get
        {
            return messageText;
        }
        set
        {
            messageText = value;
            OnPropertyChanged();

            sendMessageCommand.ChangeCanExecute();
        }
    }

    async void ConnectToServerAsync()
    {

//#if __IOS__
        await client.ConnectAsync(new Uri("ws://localhost:5002"), cts.Token);
        //await client.ConnectAsync(new Uri("wss://demo.piesocket.com/v3/channel_1?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self"), cts.Token);
//#else
//      await client.ConnectAsync(new Uri("ws://10.0.2.2:5000"), cts.Token);
//#endif

        //UpdateClientState();

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
                    string serialisedMessae = Encoding.UTF8.GetString(messageBytes);

                    try
                    {
                        //var msg = JsonConvert.DeserializeObject<Message>(serialisedMessae);
                        //Messages.Add(msg);
                        Items.Add(serialisedMessae);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalide message format. {ex.Message}");
                    }

                } while (!result.EndOfMessage);
            }
        }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

        //void UpdateClientState()
        //{
        //    OnPropertyChanged(nameof(IsConnected));
        //    sendMessageCommand.ChangeCanExecute();
        //    Console.WriteLine($"Websocket state {client.State}");
        //}
    }

    async void SendMessageAsync(string message)
    {
        //var msg = new Message
        //{
        //    Name = username,
        //    MessagDateTime = DateTime.Now,
        //    Text = message,
        //    UserId = CrossDeviceInfo.Current.Id
        //};

        //string serialisedMessage = JsonConvert.SerializeObject(msg);

        //var byteMessage = Encoding.UTF8.GetBytes(serialisedMessage);
        //var segmnet = new ArraySegment<byte>(byteMessage);

        //await client.SendAsync(segmnet, WebSocketMessageType.Text, true, cts.Token);
        //MessageText = string.Empty;
    }

    bool CanSendMessage(string message)
    {
        return IsConnected && !string.IsNullOrEmpty(message);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    readonly ClientWebSocket client;
    readonly CancellationTokenSource cts;
    readonly string username;


    Command<string> sendMessageCommand;
    //ObservableCollection<Message> messages;
    string messageText;

}
