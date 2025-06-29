using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AlphaVet.Model;

namespace AlphaVet;
public partial class tblespecies : ContentPage
{
    ObservableCollection<especie> lista = new ObservableCollection<especie>();

    public tblespecies()
	{
        InitializeComponent();

        especielist.ItemsSource = lista;
    }

    protected async override void OnAppearing()
    {
        loadList();
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

    protected async void loadList()
    {
        List<especie> tip = await App.Db.GetAll();

        lista.Clear();

        foreach (especie especie in tip)
        {
            lista.Add(especie);
        }
    }

    private async void savebtn_Clicked(object sender, EventArgs e)
    {
        if (txtespn.Text == null)
        {
            await DisplayAlert("Atenção!", "Preencha os campos necessários.", "Ok");
        }
        else
        {
            especie esp = new especie();
            esp.espnome = txtespn.Text;
            await App.Db.Insert(esp);
            await DisplayAlert("Sucesso!", "Registro inserido", "Ok");
            loadList();
        }
    }

    private async void searchtxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;
        lista.Clear();
        List<especie> tip = await App.Db.Search(q);

        foreach (especie especie in tip)
        {
            lista.Add(especie);
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        MenuItem selecionado = sender as MenuItem;

        especie p = selecionado.BindingContext as especie;

        bool confirm = await DisplayAlert("Aviso", "Confirmar a remoção dos dados?", "Sim", "Não");

        if (confirm == true)
        {
            await App.Db.Delete(p.espid);
            lista.Remove(p);
            await DisplayAlert("aviso", "Conteúdo deletado do banco com sucesso", "OK");
            loadList();
        }
    }

    private async void save_Pressed(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void clean_Clicked(object sender, EventArgs e)
    {
        txtid.Text = string.Empty;
        txtespn.Text = string.Empty;
    }

    private void change_Clicked(object sender, EventArgs e)
    {
        if (txtespn.Text == null)
        {
            DisplayAlert("Atenção!", "Preencha os campos necessários.", "Ok");
        }

        else
        {
            especie p = new especie();
            p.espid = int.Parse(txtid.Text);
            p.espnome = txtespn.Text;

            App.Db.Update(p);
            DisplayAlert("Alteração", "Registro alterado!", "Ok");
            loadList();
        }
    }

    private void especielist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        especie p = e.SelectedItem as especie;

        txtid.Text = p.espid.ToString();
        txtespn.Text = p.espnome.ToString();
    }
}