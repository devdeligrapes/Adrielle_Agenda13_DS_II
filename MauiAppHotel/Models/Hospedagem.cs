namespace MauiAppHotel.Models;

public class Hospedagem
{
    // Acréscimos por pessoa, por noite
    public const double AcrescimoAdulto = 40;
    public const double AcrescimoCrianca = 20;

    public Quarto QuartoEscolhido { get; set; } = new();
    public int QuantAdultos { get; set; }
    public int QuantCriancas { get; set; }
    public DateTime DataCheckIn { get; set; }
    public DateTime DataCheckOut { get; set; }

    public int Estadia => (DataCheckOut - DataCheckIn).Days;

    public double ValorDiariaTotal =>
        QuartoEscolhido.ValorDiaria
        + (QuantAdultos * AcrescimoAdulto)
        + (QuantCriancas * AcrescimoCrianca);

    public double ValorTotal => ValorDiariaTotal * Estadia;
}
