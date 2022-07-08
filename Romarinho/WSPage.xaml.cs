using Romarinho.App.ViewModel;

namespace Romarinho.App;

public partial class WSPage : ContentPage
{

	public WSPage(WSViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    void Frame_PropertyChanging(System.Object sender, Microsoft.Maui.Controls.PropertyChangingEventArgs e)
    {
		var frame = (Frame)sender;
		if(lblColor.Text == "Red")
        {
			frame.BorderColor = new Color(100, 0, 0);
        }
		else
		{
			frame.BorderColor = new Color(0,100,0);
		}
	}
}

