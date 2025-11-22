using LivroApi.Domain;

namespace LivroApi.Data.Repository.Interface;

public interface IUsuarioRepository
{
    Task<bool> CriarUsuarioAsync(Usuario usuario);
    Task<bool> VerificarUsuarioCadastradoPorEmailAsync(string email);
    Task<Usuario> ObterUsuarioPorEmailAsync(string email);
}
