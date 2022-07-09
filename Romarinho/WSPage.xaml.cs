using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class WSPage : ContentPage
{

	public WSPage(WSViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

