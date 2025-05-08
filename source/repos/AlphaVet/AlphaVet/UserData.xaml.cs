namespace AlphaVet;

public partial class UserData : ContentPage
{
    private string userEmail;

    public UserData(string email, string nome, string cpf, string dataNasc)
    {
        InitializeComponent();

        userEmail = email;

        emailLabel.Text = email;
        nomeLabel.Text = nome;
        cpfLabel.Text = cpf;
        dataNascLabel.Text = dataNasc;
    }

    private void init_Pressed(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private async void del_Pressed(object sender, EventArgs e)
    {
        bool resposta = await DisplayAlert("Confirmação", "Tem certeza que deseja excluir seu cadastro?", "Sim", "Cancelar");

        if (resposta)
        {
            var usuarioParaRemover = Cadas3.usuariosCadastrados.FirstOrDefault(u => u.email == userEmail);

            if (usuarioParaRemover != null)
            {
                Cadas3.usuariosCadastrados.Remove(usuarioParaRemover);
                await DisplayAlert("Sucesso", "Cadastro excluído!", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", "Usuário não encontrado!", "OK");
            }
        }
    }
}
