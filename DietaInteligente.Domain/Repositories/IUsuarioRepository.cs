
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Usuarios> BuscarUsuariosAsync();
    Task<Usuarios> BuscarUsuarioAsync(int id);
    Task CriarUsuarioAsync(string nome, string email, decimal peso, string objetivo, decimal altura);
    Task AtualizarUsuarioAsync(int id);
    Task DeletarUsuarioAsync(int id);
}
