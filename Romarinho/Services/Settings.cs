using System;
using Romarinho.App.Services.Interfaces;

namespace Romarinho.App
{
    public class Settings : ISettings
    {
#if DEBUG
        public string UrlApi{ get => "http://mauriciocph-001-site1.gtempurl.com/"; }
        //public string UrlApi { get => DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5001/" : "http://localhost:5001/"; }
#else
        public string UrlApi { get => "http://mauriciocph-001-site1.gtempurl.com/"; }
#endif

        public string Token { get; set; }
    }
}

