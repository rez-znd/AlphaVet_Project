using System.Threading.Tasks;

namespace AlphaVet;

public partial class Sobre : ContentPage
{
	public Sobre()
	{
		InitializeComponent();
	}
    private async void OnButtonPressed(object sender, EventArgs e)
    {
        var button = (Button)sender;
        await button.ScaleTo(0.95, 100, Easing.CubicInOut);
    }

    private async void OnButtonReleased(object sender, EventArgs e)
    {
        var button = (Button)sender;
        await button.ScaleTo(1, 100, Easing.CubicInOut);
    }
}