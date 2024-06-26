﻿
namespace DietaInteligente.Application.ViewModels;

public class AlimentoViewModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int GrupoAlimentarId { get; set; }
    public virtual InformacaoNutricionalViewModel? InformacoesNutricionais { get; set; }
}
