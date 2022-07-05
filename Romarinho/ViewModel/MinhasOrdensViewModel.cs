using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Romarinho.App.ViewModel;

public partial class MinhasOrdensViewModel : ObservableObject
{
    IConnectivity connectivity;
    public MinhasOrdensViewModel(IConnectivity connectivity)
    {
        MinhasOrdens = new ObservableCollection<string>();
        minhasOrdens.Add("1");
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> minhasOrdens;

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

        MinhasOrdens.Add(Text);
        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if(MinhasOrdens.Contains(s))
        {
            MinhasOrdens.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }

}
