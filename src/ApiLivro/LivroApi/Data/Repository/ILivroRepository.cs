using LivroApi.Domain;

namespace LivroApi.Data.Repository;

public interface ILivroRepository
{
    Task<Livro> Criar(Livro livro);
    Task<Livro> ObterLivroPorId(string id);
    Task<IEnumerable<Livro>> ObterTodosLivros();
    Task Atualizar(string id, Livro livro);
    Task Deletar(string id);
}
