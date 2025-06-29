using System.Collections.ObjectModel;
using System.Xml.Linq;
using AlphaVet.Model;

namespace AlphaVet;

public partial class tblanimais : ContentPage
{
    ObservableCollection<animal> lista = new();
    ObservableCollection<especie> listaesp = new();
    ObservableCollection<cliente> listacli = new();

    public tblanimais()
    {
        InitializeComponent();
        animalList.ItemsSource = lista;
        especieList.ItemsSource = listaesp;
        clienteList.ItemsSource = listacli;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        listaesp.Clear();
        listacli.Clear();
        var especies = await App.Db.GetAll();
        foreach (var e in especies) listaesp.Add(e);

        var cliente = await App.clientedb.GetAll();
        foreach (var c in cliente) listacli.Add(c);

        loadList();
    }

    async void loadList()
    {
        lista.Clear();
        var animais = await App.animaldb.GetAll();
        foreach (var a in animais) lista.Add(a);
    }

    private async void insertbtn_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtpet.Text) || especieList.SelectedItem == null || clienteList.SelectedItem == null)
        {
            await DisplayAlert("Atenção!", "Preencha todos os campos.", "Ok");
            return;
        }

        var esp = (especie)especieList.SelectedItem;
        var cli = (cliente)clienteList.SelectedItem;
        var ani = new animal
        {
            aninome = txtpet.Text,
            aniapelido = txtapelido.Text,
            anidatanasc = DateTime.Parse(txtnasc.Text),
            aniobservacoes = txtobs.Text,
            espid = esp.espid,
            cliid = cli.cliid
        };

        await App.animaldb.Insert(ani);
        await DisplayAlert("Sucesso!", "Registro inserido", "Ok");
        loadList();
    }

    private void animalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var ani = e.CurrentSelection[0] as animal;
            if (ani == null) return;

            txtid.Text = ani.aniid.ToString();
            txtpet.Text = ani.aninome;
            txtapelido.Text = ani.aniapelido;
            txtnasc.Text = ani.anidatanasc.ToString("dd-MM-yyyy");
            txtobs.Text = ani.aniobservacoes;

            var esp = listaesp.FirstOrDefault(x => x.espid == ani.espid);
            especieList.SelectedItem = esp;

            var cli = listacli.FirstOrDefault(x => x.cliid == ani.cliid);
            clienteList.SelectedItem = cli;
        }
    }


    private async void change_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtpet.Text) || especieList.SelectedItem == null || clienteList.SelectedItem == null)
        {
            await DisplayAlert("Atenção!", "Preencha todos os campos.", "Ok");
            return;
        }

        var esp = (especie)especieList.SelectedItem;
        var cli = (cliente)clienteList.SelectedItem;
        var ani = new animal
        {
            aniid = int.Parse(txtid.Text),
            aninome = txtpet.Text,
            aniapelido = txtapelido.Text,
            anidatanasc = DateTime.Parse(txtnasc.Text),
            aniobservacoes = txtobs.Text,
            espid = esp.espid,
            cliid = cli.cliid
        };

        await App.animaldb.Update(ani);
        await DisplayAlert("Sucesso!", "Registro alterado!", "Ok");
        loadList();
    }

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
        var mi = (MenuItem)sender;
        var ani = (animal)mi.BindingContext;
        if (await DisplayAlert("Confirma", "Remover registro?", "Sim", "Não"))
        {
            await App.animaldb.Delete(ani.aniid);
            lista.Remove(ani);
            await DisplayAlert("Sucesso!", "Registro deletado!", "Ok");
        }
    }

    private void clean_Clicked(object sender, EventArgs e)
    {
        txtid.Text = txtpet.Text = txtapelido.Text = txtnasc.Text = txtobs.Text = string.Empty;
        especieList.SelectedItem = null; clienteList.SelectedItem = null;
    }

    private async void back_Clicked(object sender, EventArgs e)
        => await Navigation.PopAsync();

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

    private bool isEditing;
    private void txtnasc_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (isEditing)
            return;

        isEditing = true;

        var text = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(text))
        {
            isEditing = false;
            return;
        }

        var digits = new string(text.Where(char.IsDigit).ToArray());

        if (digits.Length > 8)
            digits = digits.Substring(0, 8);

        if (digits.Length >= 5)
            text = $"{digits.Substring(0, 2)}/{digits.Substring(2, 2)}/{digits.Substring(4)}";
        else if (digits.Length >= 3)
            text = $"{digits.Substring(0, 2)}/{digits.Substring(2)}";
        else if (digits.Length >= 1)
            text = digits;

        txtnasc.Text = text;
        isEditing = false;
    }

    private async void searchtxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;
        lista.Clear();
        List<animal> tip = await App.animaldb.Search(q);

        foreach (animal animal in tip)
        {
            lista.Add(animal);
        }
    }
}