
namespace DietaInteligente.Application.ViewModels;

public class DietaAlimentoViewModel
{
    public int DietaId { get; set; }
    public int AlimentoId { get; set; }
    public virtual IEnumerable<DietaViewModel>? Dietas { get; set; }
    public virtual IEnumerable<AlimentoViewModel>? Alimentos { get; set; }
    public decimal? QuantidadedeGramas { get; set; }
}
