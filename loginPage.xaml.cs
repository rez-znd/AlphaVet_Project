using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AlphaVet.Model;

namespace AlphaVet;
public partial class loginPage : ContentPage
{
    ObservableCollection<user> lista = new ObservableCollection<user>();

    public loginPage()
    {
        InitializeComponent();

        userlist.ItemsSource = lista;
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
        List<user> tip = await App.userdb.GetAll();

        lista.Clear();

        foreach (user user in tip)
        {
            lista.Add(user);
        }
    }

    private async void insertbtn_Clicked(object sender, EventArgs e)
    {
        if (txtnome.Text == null)
        {
            await DisplayAlert("Atenção!", "Preencha os campos necessários.", "Ok");
            return;
        }

        var u = new user
        {
            username = txtnome.Text,
            userpass = txtpass.Text,
        };

        await App.userdb.Insert(u);
        await DisplayAlert("Sucesso!", "Registro inserido", "Ok");
        loadList();
    }

    private async void searchtxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;
        lista.Clear();
        List<user> tip = await App.userdb.Search(q);

        foreach (user user in tip)
        {
            lista.Add(user);
        }
    }

    private async void back_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void clean_Clicked(object sender, EventArgs e)
    {
        txtid.Text = string.Empty;
        txtnome.Text = string.Empty;
        txtpass.Text = string.Empty;
    }

    private void userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        user u = e.SelectedItem as user;

        txtid.Text = u.userid.ToString();
        txtnome.Text = u.username.ToString();
        txtpass.Text = u.userpass.ToString();
    }
}