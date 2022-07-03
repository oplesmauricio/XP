//using System;
//using System.Net.WebSockets;
//using System.Text;

//namespace Romarinho.Services
//{
//    public class WSService
//    {
//        readonly ClientWebSocket client;
//        readonly CancellationTokenSource cts;

//        public WSService()
//        {
//            client = new ClientWebSocket();
//            cts = new CancellationTokenSource();
//            messages = new ObservableCollection<Message>();

//            this.username = username;

//            ConnectToServerAsync();
//        }

//        async void ConnectToServerAsync()
//        {

////#if __IOS__
//            await client.ConnectAsync(new Uri("ws://localhost:5000"), cts.Token);
////#else
////            await client.ConnectAsync(new Uri("ws://10.0.2.2:5000"), cts.Token);
////#endif

//            UpdateClientState();

//            await Task.Factory.StartNew(async () =>
//            {
//                while (true)
//                {
//                    WebSocketReceiveResult result;
//                    var message = new ArraySegment<byte>(new byte[4096]);
//                    do
//                    {
//                        result = await client.ReceiveAsync(message, cts.Token);
//                        var messageBytes = message.Skip(message.Offset).Take(result.Count).ToArray();
//                        string serialisedMessae = Encoding.UTF8.GetString(messageBytes);

//                        try
//                        {
//                            var msg = JsonConvert.DeserializeObject<Message>(serialisedMessae);
//                            Messages.Add(msg);
//                        }
//                        catch (Exception ex)
//                        {
//                            Console.WriteLine($"Invalide message format. {ex.Message}");
//                        }

//                    } while (!result.EndOfMessage);
//                }
//            }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);

//            void UpdateClientState()
//            {
//                OnPropertyChanged(nameof(IsConnected));
//                sendMessageCommand.ChangeCanExecute();
//                Console.WriteLine($"Websocket state {client.State}");
//            }
//        }

//        public async void InitRead()
//        {
//            //using var ws = new ClientWebSocket();
//            //await ws.ConnectAsync(new Uri("wss://localhost:7234/"), CancellationToken.None);

//            //var buffer = new byte[256];
//            //while (ws.State == WebSocketState.Open)
//            //{
//            //    var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
//            //    if (result.MessageType == WebSocketMessageType.Close)
//            //        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
//            //    else
//            //        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, result.Count));
//            //}

//            var client = new ClientWebSocket();
            
//            await client.ConnectAsync(new Uri("ws://10.0.2.2:5000"), cts.Token);
//            UpdateClientState();

//            await Task.Factory.StartNew(async () =>
//            {
//                while (true)
//                {
//                    await ReadMessage();
//                }
//            }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            
//        }
//    }
//}

