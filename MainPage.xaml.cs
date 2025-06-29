using System.Threading.Tasks;

namespace AlphaVet;

public partial class MainPage : ContentPage
{
    public MainPage()
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

    private async void especies_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new tblespecies());
    }

    private async void animais_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new tblanimais());
    }

    private async void clientes_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new tblclientes());
    }
}

