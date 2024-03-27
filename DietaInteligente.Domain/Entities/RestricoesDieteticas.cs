namespace DietaInteligente.Domain.Entities;

public class RestricaoDietetica
{
    public RestricaoDietetica(int usuarioId, int grupoAlimentarId)
    {
        UsuarioId = usuarioId;
        GrupoAlimentarId = grupoAlimentarId;
    }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int GrupoAlimentarId { get; set; }
    public GruposAlimentares GrupoAlimentar { get; set; }
}