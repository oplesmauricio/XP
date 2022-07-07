using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Romarinho.App.Model;
using Romarinho.App.Model.Interfaces;
using Romarinho.App.Services.Interfaces;

namespace Romarinho.App.ViewModel;

public partial class NovaOrdemViewModel : ObservableObject
{
    private IConnectivity connectivity;
    private IContexto _contexto;
    private IOrdensService _service;
    public NovaOrdemViewModel(IConnectivity connectivity, IContexto contexto, IOrdensService service)
    {
        this.connectivity = connectivity;
        this._service = service;
        this._contexto = contexto;
        this.Ordem = new Ordem();
    }

    [ObservableProperty]
    Ordem ordem;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task Cadastrar()
    {
        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Atencao", "Parece que vc esta sem internet", "OK");
            }
            else
            {
                //ordem.Conta = "";
                //ordem.Reducao = "";
                //ordem.Tipo = "";
                var requisicao = await _service.Cadastrar(ordem);

                if (requisicao.Sucesso)
                {
                    await Application.Current.MainPage.DisplayAlert("Atencao", "Ordem cadastrada com sucesso!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Atencao", requisicao.Mensagem, "OK");
                }
            }
        }
        catch (System.Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Vixi", "Algo deu errado, tente novamente mais tarde", "Ok");
        }
    }
}
