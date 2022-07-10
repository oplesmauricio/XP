using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class MinhasOrdensPage : ContentPage
{
    private MinhasOrdensViewModel _vm;
	public MinhasOrdensPage(MinhasOrdensViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.BuscarOrdens();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        _vm.LimparOrdens();
    }
}

