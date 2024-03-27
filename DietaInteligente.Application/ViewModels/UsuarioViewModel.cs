

namespace DietaInteligente.Application.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Altura { get; set; }
    public string? Objetivo { get; set; }
    public virtual IEnumerable<DietaViewModel>? Dietas { get; set; }
    public virtual IEnumerable<RestricaoDieteticaViewModel>? RestricoesDieteticas { get; set; }

}
