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
			frame.BorderColor = new Color(255, 0, 0);
        }
		else
		{
			frame.BorderColor = new Color(0,0,255);
		}

		//var random = new Random();
		//var cor = random.Next(1, 4);
		////var frame = (Frame)sender;

		//switch (cor)
		//{
		//	case 1:
		//		frame.BorderColor = new Color(255, 0, 0);
		//		break;
		//	case 2:
		//		frame.BorderColor = new Color(0, 0, 255);
		//		break;
		//	case 3:
		//		frame.BorderColor = new Color(255, 255, 0);
		//		break;
		//	default:
		//		frame.BorderColor = new Color(255, 0, 0);
		//		break;
		//}
	}
}

