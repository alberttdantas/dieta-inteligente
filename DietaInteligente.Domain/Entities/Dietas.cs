namespace DietaInteligente.Domain.Entities;

public class Dieta
{
    public Dieta(int usuarioId, DateTime data)
    {
        UsuarioId = usuarioId;
        Data = data;
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