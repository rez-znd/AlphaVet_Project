using System.Threading.Tasks;

namespace AlphaVet;

public partial class Cadas3 : ContentPage
{
    public static List<string> animaisCadastrados = new List<string>();

    public static List<User> usuariosCadastrados = new List<User>();
    public Cadas3()
    {
        InitializeComponent();
    }

    public class User
    {
        public string email { get; set; }
        public string nomeResp { get; set; }
        public string cpf { get; set; }
        public string dataNasc { get; set; }
        public string senha { get; set; }
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
        string email = emailV.Text;
        string nomeRes = nomeResV.Text;
        string cpf = cpfV.Text;
        string senha = passV.Text;
        string dataNasc = dataNascV.Date.ToString("dd/MM/yyyy");

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nomeRes) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(senha))
        {
            await DisplayAlert("Ops...", "Preencha todos os campos!", "OK");
            return;
        }

        var novoUsuario = new User
        {
            email = email,
            senha = senha,
            nomeResp = nomeRes,
            cpf = cpf,
        };

        usuariosCadastrados.Add(novoUsuario);

        await DisplayAlert("Oba!", "Cadastro realizado com sucesso!", "OK");

        await Navigation.PushAsync(new UserData(email, nomeRes, cpf, dataNasc));
    }
}