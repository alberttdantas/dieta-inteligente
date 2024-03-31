
using DietaInteligente.Domain.Enums;

namespace DietaInteligente.Application.InputModels;

public class UsuarioInputModel
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Altura { get; set; }
    public Objetivos? Objetivo { get; set; }
}
