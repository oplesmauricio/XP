using System;
namespace Romarinho.Services
{
    //public class WebSocketSimpleDemo
    //{
    //    private Websockets.IWebSocketConnection _connection;
    //    private readonly string _uriWebSocket = "wss://echo.websocket.org";

    //    public WebSocketSimpleDemo()
    //    {
    //        _connection = Websockets.WebSocketFactory.Create();
    //        _connection.OnLog += Connection_OnLog;
    //        _connection.OnError += Connection_OnError;
    //        _connection.OnMessage += Connection_OnMessage;
    //        _connection.OnOpened += Connection_OnOpened;
    //        _connection.OnClosed += Connection_OnClosed;

    //        _connection.Open(_uriWebSocket);
    //    }

    //    private void Connection_OnError(string obj)
    //    {
    //        Debug.WriteLine("ERRO " + obj);
    //    }

    //    private void Connection_OnClosed()
    //    {
    //        Debug.WriteLine("CONEXÃO FECHADA");
    //    }

    //    private void Connection_OnLog(string obj)
    //    {
    //        Debug.WriteLine("LOG " + obj);
    //    }

    //    private void Connection_OnOpened()
    //    {
    //        Debug.WriteLine("CONEXÃO ABERTA");
    //    }

    //    private void Connection_OnMessage(string obj)
    //    {
    //        Debug.WriteLine("NOVA MENSAGEM " + obj);

    //    }
    //}

}

