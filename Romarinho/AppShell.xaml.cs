namespace Romarinho.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(EditarOrdemPage), typeof(EditarOrdemPage));
        Routing.RegisterRoute(nameof(NovaOrdemPage), typeof(NovaOrdemPage));
        Routing.RegisterRoute(nameof(MinhasOrdensPage), typeof(MinhasOrdensPage));
    }
}
