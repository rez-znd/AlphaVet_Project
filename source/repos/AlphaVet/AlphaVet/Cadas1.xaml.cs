using System.Globalization;
using System.Threading.Tasks;

namespace AlphaVet;

public partial class Cadas1 : ContentPage
{
    int count = 0;

    public static List<string> AnimaisCadastrados = new List<string>();
    private string tipoSelecionado;
    public Cadas1()
    {
        InitializeComponent();
        AtualizarPicker();
    }

    private void AtualizarPicker()
    {
        animalList.ItemsSource = AnimalData.ListaDeAnimais.Select(a => a.Type).ToList();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        AtualizarPicker();  
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

    private async void Backbtn_Pressed(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void next_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Cadas2());
    }

    private async void add_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddAnimal());
    }
}

