using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AlphaVet;
public static class AnimalData
{
    public static ObservableCollection<Animal> ListaDeAnimais { get; set; } = new ObservableCollection<Animal>();
}

public class Animal
{
    public string Id { get; set; }
    public string Type { get; set; }
}
public partial class AddAnimal : ContentPage
{

    private ObservableCollection<Animal> animais;

    private Animal animalSelecionado;
    public AddAnimal()
	{
        InitializeComponent();
        listViewAnimals.ItemsSource = AnimalData.ListaDeAnimais;
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

    private void confirm_Pressed(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(animalV.Text) && !string.IsNullOrWhiteSpace(idV.Text))
        {
            Animal novoAnimal = new Animal
            {
                Id = idV.Text,
                Type = animalV.Text
            };

            AnimalData.ListaDeAnimais.Add(novoAnimal);

            // Atualiza a CollectionView
            listViewAnimals.ItemsSource = null;
            listViewAnimals.ItemsSource = AnimalData.ListaDeAnimais;

            // Limpa os campos
            idV.Text = "";
            animalV.Text = "";
        }
        else
        {
            DisplayAlert("Erro", "Preencha todos os campos!", "OK");
        }
    }
    private void OnDeleteAnimal(object sender, EventArgs e)
    {
        if (animalSelecionado != null)
        {
            AnimalData.ListaDeAnimais.Remove(animalSelecionado);

            // Atualiza a lista e reseta a seleção
            listViewAnimals.SelectedItem = null;
            animalSelecionado = null;
        }
        else
        {
            DisplayAlert("Erro", "Selecione um animal para excluir!", "OK");
        }
    }

    private void animalSlct(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            animalSelecionado = e.CurrentSelection[0] as Animal;
        }
    }
    private void delButton_Pressed(object sender, EventArgs e)
    {
        if (animalSelecionado != null)
        {
            AnimalData.ListaDeAnimais.Remove(animalSelecionado);


            listViewAnimals.SelectedItem = null;
            listViewAnimals.ItemsSource = null;
            listViewAnimals.ItemsSource = AnimalData.ListaDeAnimais;

            animalSelecionado = null;
        }
        else
        {
            DisplayAlert("Erro", "Selecione um animal para excluir!", "OK");
        }
    }
    private async void save_Pressed(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}