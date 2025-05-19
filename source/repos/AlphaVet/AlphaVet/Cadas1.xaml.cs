using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AlphaVet.Model;

namespace AlphaVet;

public partial class Cadas1 : ContentPage
{
    ObservableCollection<especie> lista = new ObservableCollection<especie>();
    public Cadas1()
    {
        InitializeComponent();

        especieList.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        lista.Clear();

        List<especie> tip = await App.Db.GetAll();

        foreach (especie especie in tip)
        {
            lista.Add(especie);
        }
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

