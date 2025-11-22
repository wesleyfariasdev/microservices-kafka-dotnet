using LivroApi.Data.DBMongoContext;
using LivroApi.Domain;
using MongoDB.Driver;

namespace LivroApi.Data.Repository;

public class UsuarioRepository(DbContext context) : IUsuarioRepository
{
    public async Task<bool> CriarUsuarioAsync(Usuario usuario)
    {
        await context.Usuarios.InsertOneAsync(usuario);
        return true;
    }

    public async Task<Usuario> ObterUsuarioPorEmailAsync(string email) =>
           await context.Usuarios.Find(u => u.Email == email).FirstAsync();

    public async Task<bool> VerificarUsuarioCadastradoPorEmailAsync(string email) =>
           await context.Usuarios.Find(u => u.Email == email).AnyAsync();
}
