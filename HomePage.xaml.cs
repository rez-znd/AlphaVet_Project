namespace AlphaVet;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    [Obsolete]
    protected override bool OnBackButtonPressed()
    {
        Device.BeginInvokeOnMainThread(async () =>
        {
            bool resposta = await DisplayAlert("Confirmação", "Deseja realmente voltar à tela inicial?", "Sim", "Não");
            if (resposta)
            {
                await Navigation.PushAsync(new MainPage());
            }
        });

        return true;
    }
}