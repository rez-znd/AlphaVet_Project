using System.Globalization;

namespace AlphaVet;

public partial class Cadas2 : ContentPage
{
    int count = 0;
    public Cadas2()
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

    private async void back_Pressed(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void confirm_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadas1());
    }

}

