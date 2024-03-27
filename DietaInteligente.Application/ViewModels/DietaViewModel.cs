
namespace DietaInteligente.Application.ViewModels;

public class DietaViewModel
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public UsuarioViewModel? Usuarios { get; set; }
    public virtual IEnumerable<DietaAlimentoViewModel>? DietasAlimentos { get; set; }
}
