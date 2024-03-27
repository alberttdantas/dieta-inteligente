namespace DietaInteligente.Domain.Entities;

public class GruposAlimentares
{
    public GruposAlimentares(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<Alimento> Alimentos { get; set; }
}