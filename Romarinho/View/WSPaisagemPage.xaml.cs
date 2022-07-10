using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class WSPaisagemPage : ContentPage
{

	public WSPaisagemPage(WSViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

