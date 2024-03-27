
namespace DietaInteligente.Application.ViewModels;

public class GrupoAlimentarViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public virtual IEnumerable<AlimentoViewModel>? Alimentos { get; set; }
}
