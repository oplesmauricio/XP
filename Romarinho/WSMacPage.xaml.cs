using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class WSMacPage : ContentPage
{

	public WSMacPage(WSViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

