namespace Romarinho.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(NovaOrdemPage), typeof(NovaOrdemPage));
        Routing.RegisterRoute(nameof(MinhasOrdensPage), typeof(MinhasOrdensPage));
    }
}
