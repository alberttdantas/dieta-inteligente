
namespace DietaInteligente.Application.ViewModels;

public class RestricaoDieteticaViewModel
{
    public int UsuarioId { get; set; }
    public virtual IEnumerable<GrupoAlimentarViewModel>? GruposAlimentares { get; set; }
}
