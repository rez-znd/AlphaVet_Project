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
            bool resposta = await DisplayAlert("Confirma��o", "Deseja realmente voltar � tela inicial?", "Sim", "N�o");
            if (resposta)
            {
                await Navigation.PushAsync(new MainPage());
            }
        });

        return true;
    }
}