using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class MinhasOrdensPage : ContentPage
{

	public MinhasOrdensPage(MinhasOrdensViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

