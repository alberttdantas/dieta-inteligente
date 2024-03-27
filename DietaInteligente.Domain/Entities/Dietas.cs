namespace DietaInteligente.Domain.Entities;

public class Dieta
{
    public Dieta()
    {
        DietasAlimento = new List<DietaAlimento>();
    }

    public Dieta(int usuarioId)
    {
        UsuarioId = usuarioId;
        Data = DateTime.Now;
    }

    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuarios { get; set; }
    public DateTime Data { get; set; }
    public ICollection<DietaAlimento> DietasAlimento { get; set; }
}