using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class NovaOrdemPage : ContentPage
{
	public NovaOrdemPage(NovaOrdemViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}