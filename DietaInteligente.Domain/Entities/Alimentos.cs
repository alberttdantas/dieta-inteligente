namespace DietaInteligente.Domain.Entities;

public class Alimento
{
    public Alimento(string nome, int grupoAlimentarId, int informacaoNutricionalId)
    {
        Nome = nome;
        GrupoAlimentarId = grupoAlimentarId;
        InformacaoNutricionalId = informacaoNutricionalId;
    }

    public int Id { get; set; }
    public int GrupoAlimentarId { get; set; }
    public virtual GrupoAlimentar GruposAlimentares { get; set; }
    public string Nome { get; set; }
    public int InformacaoNutricionalId { get; set; }
    public virtual InformacaoNutricional InformacaoNutricional { get; set; }
}