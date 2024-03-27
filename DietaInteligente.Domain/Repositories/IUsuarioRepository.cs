
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> BuscarUsuariosAsync();
    Task<Usuario> BuscarUsuarioAsync(int id);
    Task<bool> CriarUsuarioAsync(Usuario usuario);
    Task<bool> AtualizarUsuarioAsync(Usuario usuario);
    Task<bool> DeletarUsuarioAsync(Usuario usuario);
}
