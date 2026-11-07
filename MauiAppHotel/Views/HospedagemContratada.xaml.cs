using System.Globalization;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    private static readonly CultureInfo PtBr = new("pt-BR");

    public HospedagemContratada(Hospedagem hospedagem)
    {
        InitializeComponent();

        lbl_quarto.Text = hospedagem.QuartoEscolhido.Descricao;
        lbl_adultos.Text = hospedagem.QuantAdultos.ToString();
        lbl_criancas.Text = hospedagem.QuantCriancas.ToString();
        lbl_checkin.Text = hospedagem.DataCheckIn.ToString("dd/MM/yyyy");
        lbl_checkout.Text = hospedagem.DataCheckOut.ToString("dd/MM/yyyy");
        lbl_estadia.Text = hospedagem.Estadia.ToString();

        lbl_diaria.Text = hospedagem.ValorDiariaTotal.ToString("C", PtBr);
        lbl_total.Text = hospedagem.ValorTotal.ToString("C", PtBr);
    }

    private async void OnNovaReservaClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
