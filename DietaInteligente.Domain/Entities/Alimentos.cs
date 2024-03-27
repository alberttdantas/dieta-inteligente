namespace DietaInteligente.Domain.Entities;

public class Alimento
{
    public Alimento(string nome, int grupoAlimentarId)
    {
        Nome = nome;
        GrupoAlimentarId = grupoAlimentarId;
    }

    public int Id { get; set; }
    public int GrupoAlimentarId { get; set; }
    public virtual GruposAlimentares GruposALimentares { get; set; }
    public string Nome { get; set; }
    public InformacaoNutricional InformacoesNutricionais { get; set; }
}