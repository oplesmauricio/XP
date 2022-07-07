using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Romarinho.App.Model;
using Romarinho.App.Model.Interfaces;
using Romarinho.App.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Romarinho.App.ViewModel;

public partial class MinhasOrdensViewModel : ObservableObject
{
    private IConnectivity connectivity;
    private IContexto _contexto;
    private IOrdensService _service;

    public MinhasOrdensViewModel(IConnectivity connectivity, IContexto contexto, IOrdensService service)
    {
        this.connectivity = connectivity;
        this._service = service;
        this._contexto = contexto;
        this.minhasOrdens = new ObservableCollection<Ordem>();
    }

    internal async Task BuscarOrdens()
    {
        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Atencao", "Parece que vc esta sem internet", "OK");
            }
            else
            {
                var requisicao = await _service.BuscarOrdensPorUsuario(_contexto.UsuarioLogado.Id);

                if (requisicao.Sucesso)
                {
                    foreach (var ordem in requisicao.Resposta)
                    {
                        this.MinhasOrdens.Add(ordem);
                    }
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

    internal void LimparOrdens()
    {
        this.MinhasOrdens = new ObservableCollection<Ordem>();
    }

    [ObservableProperty]
    ObservableCollection<Ordem> minhasOrdens;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
            return;
        }

        //MinhasOrdens.Add(Text);
        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    async Task DeleteAsync(Ordem ordem)
    {
        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("Atencao", "Parece que vc esta sem internet", "OK");
            }
            else
            {
                var requisicao = await _service.Deletar(ordem.Id.ToString());

                if (requisicao.Sucesso)
                {
                    await Application.Current.MainPage.DisplayAlert("Atencao", "Ordem excluida com sucesso!", "OK");
                    if (MinhasOrdens.Contains(ordem))
                    {
                        MinhasOrdens.Remove(ordem);
                    }
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

    [RelayCommand]
    async Task Tap(Ordem ordem)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Ordem", ordem }
        };
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}", navigationParameter);
    }

}
