using System;
namespace Romarinho.App.Services.Interfaces
{
    public interface ISettings
    {
        string UrlApi { get; }

        string Token { get; set; }
    }
}

