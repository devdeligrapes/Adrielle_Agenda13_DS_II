namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    // >>> TROQUE AQUI pelo seu nome completo antes de tirar os prints <<<
    private const string NomeDesenvolvedor = "Adrielle Maciel de Sena";
    private const int AnoDesenvolvimento = 2026;

    public Sobre()
    {
        InitializeComponent();

        lbl_desenvolvedor.Text = NomeDesenvolvedor;
        lbl_ano.Text = AnoDesenvolvimento.ToString();
        lbl_versao.Text = $"Versão {AppInfo.Current.VersionString}";
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
