using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class EditarOrdemPage : ContentPage
{
	public EditarOrdemPage(EditarOrdemViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}