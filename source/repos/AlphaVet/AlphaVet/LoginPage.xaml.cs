using System.Threading.Tasks;

namespace AlphaVet;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void Backbtn_Pressed(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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

    private async void confirm_Pressed(object sender, EventArgs e)
    {
        string emailInserido = email.Text;
        string senhaInserida = password.Text;

        var usuario = Cadas3.usuariosCadastrados.FirstOrDefault(u => u.email == emailInserido && u.senha == senhaInserida);

        if (usuario != null)
        {
            await DisplayAlert("Oba!", "Login realizado com sucesso!", "OK");
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Ops...", "E-mail ou senha inválido", "OK");
        }

    }

    private async void back_Pressed(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}