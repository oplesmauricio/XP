using System;
using Romarinho.App.Services.Interfaces;

namespace Romarinho.App
{
    public class Settings : ISettings
    {
#if DEBUG
        public string UrlApi { get => DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5001/" : "http://localhost:5001/"; }
#else
        public string UrlApi { get => "http://ec2-52-91-69-122.compute-1.amazonaws.com:8181/api/"; }
#endif

        public string Token { get; set; }
    }
}

