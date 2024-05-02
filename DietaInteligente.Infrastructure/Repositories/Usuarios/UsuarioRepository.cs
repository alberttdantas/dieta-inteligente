
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Repositories.Usuarios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DietaInteligenteDbContext _dbContext;

    public UsuarioRepository(DietaInteligenteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Usuario>> BuscarUsuariosAsync()
    {
        return await _dbContext.Set<Usuario>().ToListAsync();
    }

    public async Task<Usuario> BuscarUsuarioAsync(int id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await _dbContext.Set<Usuario>().FindAsync(id);
    }

    public async Task<bool> CriarUsuarioAsync(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        _dbContext.Set<Usuario>().Add(usuario);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletarUsuarioAsync(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        _dbContext.Set<Usuario>().Remove(usuario);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarUsuarioAsync(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        _dbContext.Entry(usuario).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
