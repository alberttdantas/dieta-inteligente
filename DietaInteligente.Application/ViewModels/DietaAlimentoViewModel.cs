
namespace DietaInteligente.Application.ViewModels;

public class DietaAlimentoViewModel
{
    public int DietaId { get; set; }
    public AlimentoViewModel Alimento { get; set; }
    public decimal? QuantidadeGramas { get; set; }
}