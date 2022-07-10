using Romarinho.App.Model;
using Romarinho.App.Model.Interfaces;
using Romarinho.App.Services;
using Romarinho.App.Services.Interfaces;
using Romarinho.App.ViewModel;
using Romarinho.Infra;

namespace Romarinho.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IContexto>(new Contexto { UsuarioLogado = new Model.Usuario { Id = "1" } });
		builder.Services.AddSingleton<ISettings>(new Settings { Token = "token"});

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();


        builder.Services.AddTransient<EditarOrdemPage>();
        builder.Services.AddTransient<EditarOrdemViewModel>();

		builder.Services.AddTransient<WSPage>();
		builder.Services.AddTransient<WSViewModel>();

		builder.Services.AddTransient<WSPaisagemPage>();

		builder.Services.AddTransient<MinhasOrdensPage>();
		builder.Services.AddTransient<MinhasOrdensViewModel>();

		builder.Services.AddTransient<NovaOrdemPage>();
		builder.Services.AddTransient<NovaOrdemViewModel>();

		builder.Services.AddTransient<IApiService, ApiService>();
		builder.Services.AddTransient<IOrdensService, OrdensService>();

		return builder.Build();
	}
}
