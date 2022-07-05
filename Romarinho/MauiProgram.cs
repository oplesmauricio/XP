﻿using Romarinho.App.ViewModel;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();


        builder.Services.AddTransient<DetailPage>();
        builder.Services.AddTransient<DetailViewModel>();

		builder.Services.AddTransient<WSPage>();
		builder.Services.AddTransient<WSViewModel>();

		builder.Services.AddTransient<MinhasOrdensPage>();
		builder.Services.AddTransient<MinhasOrdensViewModel>();

		return builder.Build();
	}
}
