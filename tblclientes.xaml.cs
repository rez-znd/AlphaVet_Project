using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AlphaVet.Model;
using System.Xml.Linq;

namespace AlphaVet;

public partial class tblclientes : ContentPage
{
    ObservableCollection<cliente> lista = new ObservableCollection<cliente>();

    public tblclientes()
    {
        InitializeComponent();

        clientelist.ItemsSource = lista;
    }
    protected async override void OnAppearing()
    {
        loadList();
    }
    protected async void loadList()
    {
        List<cliente> tip = await App.clientedb.GetAll();

        lista.Clear();

        foreach (cliente cliente in tip)
        {
            lista.Add(cliente);
        }
    }

    private async void insertbtn_Clicked(object sender, EventArgs e)
    {
        if (txtcli.Text == null || txtcpf.Text == null || txtemail.Text == null)
        {
            await DisplayAlert("Atenção!", "Preencha os campos necessários.", "Ok");
        }
        else
        {
            cliente cli = new cliente();
            cli.clinome = txtcli.Text;
            cli.clicpf = txtcpf.Text;
            cli.cliemail = txtemail.Text;
            await App.clientedb.Insert(cli);
            await DisplayAlert("Sucesso!", "Registro inserido", "Ok");
            loadList();
        }
    }

    private async void searchtxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;
        lista.Clear();
        List<cliente> tip = await App.clientedb.Search(q);

        foreach (cliente cliente in tip)
        {
            lista.Add(cliente);
        }
    }

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
        var mi = (MenuItem)sender;
        var cli = (cliente)mi.BindingContext;
        if (await DisplayAlert("Confirma", "Remover registro?", "Sim", "Não"))
        {
            await App.clientedb.Delete(cli.cliid);
            lista.Remove(cli);
            await DisplayAlert("Sucesso!", "Registro deletado!", "Ok");
        }
    }

    private void clean_Clicked(object sender, EventArgs e)
    {
        txtid.Text = string.Empty;
        txtcli.Text = string.Empty;
        txtcpf.Text = string.Empty;
        txtemail.Text = string.Empty;
        txtdata.Text = string.Empty;
    }

    private void clientelist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        cliente p = e.SelectedItem as cliente;

        txtid.Text = p.cliid.ToString();
        txtcli.Text = p.clinome.ToString();
        txtcpf.Text = p.clicpf.ToString();
        txtemail.Text = p.cliemail.ToString();
        txtdata.Text = p.clidatacadastro.ToString();
    }

    private void change_Clicked(object sender, EventArgs e)
    {
        if (txtcli.Text == null || txtcpf.Text == null || txtemail.Text == null)
        {
            DisplayAlert("Atenção!", "Preencha os campos necessários.", "Ok");
        }

        else
        {
            cliente p = new cliente();
            p.cliid = int.Parse(txtid.Text);
            p.clinome = txtcli.Text;
            p.clicpf = txtcpf.Text;
            p.cliemail = txtemail.Text;
            p.clidatacadastro = DateTime.Parse(txtdata.Text);

            App.clientedb.Update(p);
            DisplayAlert("Alteração", "Registro alterado!", "Ok");
            loadList();
        }
    }

    private async void cliente_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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

    private void clientelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var cli = e.CurrentSelection[0] as cliente;
            if (cli == null) return;

            txtid.Text = cli.cliid.ToString();
            txtcli.Text = cli.clinome.ToString();
            txtcpf.Text = cli.clicpf.ToString();
            txtemail.Text = cli.cliemail.ToString();
            txtdata.Text = cli.clidatacadastro.ToString();
        }
    }
}