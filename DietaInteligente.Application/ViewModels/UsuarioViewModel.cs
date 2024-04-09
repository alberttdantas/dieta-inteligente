

using DietaInteligente.Domain.Enums;

namespace DietaInteligente.Application.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Altura { get; set; }
    public Objetivos? Objetivo { get; set; }
    public DietaViewModel? Dietas { get; set; }
    public RestricaoDieteticaViewModel? RestricaoDietetica { get; set; }

}
