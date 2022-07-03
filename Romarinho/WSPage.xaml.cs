using Romarinho.ViewModel;

namespace Romarinho;

public partial class WSPage : ContentPage
{

	public WSPage(WSViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

