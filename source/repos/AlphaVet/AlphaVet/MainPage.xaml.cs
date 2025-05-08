using System.Threading.Tasks;

namespace AlphaVet;

public partial class MainPage : ContentPage
{
    int count = 0;
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Loginbtn_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
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

    private async void cadasbtn_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadas3());
    }
}

