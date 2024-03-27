namespace DietaInteligente.Domain.Entities;

public class RestricoesDieteticas
{
    public RestricoesDieteticas(int usuarioId, int grupoAlimentarId)
    {
        UsuarioId = usuarioId;
        GrupoAlimentarId = grupoAlimentarId;
    }

    public int UsuarioId { get; set; }
    public Usuarios Usuario { get; set; }
    public int GrupoAlimentarId { get; set; }
    public GruposAlimentares GrupoAlimentar { get; set; }
}