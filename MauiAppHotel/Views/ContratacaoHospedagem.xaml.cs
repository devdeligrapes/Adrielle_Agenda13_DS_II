using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private readonly List<Quarto> _quartos = new()
    {
        new Quarto { Descricao = "Suíte Standard",     ValorDiaria = 220 },
        new Quarto { Descricao = "Suíte Luxo",         ValorDiaria = 340 },
        new Quarto { Descricao = "Suíte Vista Mar",    ValorDiaria = 480 },
        new Quarto { Descricao = "Suíte Presidencial", ValorDiaria = 750 },
    };

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = _quartos;

        DateTime hoje = DateTime.Today;
        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkin.Date = hoje;

        dtpck_checkout.MinimumDate = hoje.AddDays(1);
        dtpck_checkout.Date = hoje.AddDays(1);

        // Mantém o check-out sempre depois do check-in
        dtpck_checkin.DateSelected += (s, e) =>
        {
            dtpck_checkout.MinimumDate = e.NewDate.AddDays(1);
            if (dtpck_checkout.Date <= e.NewDate)
                dtpck_checkout.Date = e.NewDate.AddDays(1);
        };
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlert("Atenção", "Selecione uma suíte para continuar.", "OK");
                return;
            }

            if (dtpck_checkout.Date <= dtpck_checkin.Date)
            {
                await DisplayAlert("Atenção", "O check-out deve ser posterior ao check-in.", "OK");
                return;
            }

            var hospedagem = new Hospedagem
            {
                QuartoEscolhido = quarto,
                QuantAdultos = (int)stp_adultos.Value,
                QuantCriancas = (int)stp_criancas.Value,
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new HospedagemContratada(hospedagem));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
