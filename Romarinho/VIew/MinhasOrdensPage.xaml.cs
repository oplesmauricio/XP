using Romarinho.ViewModel;

namespace Romarinho;

public partial class MinhasOrdensPage : ContentPage
{

	public MinhasOrdensPage(MinhasOrdensViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

