using LivroApi.Domain;

namespace LivroApi.Data.Repository;

public class LivroRepository : ILivroRepository
{
    public Task Atualizar(string id, Livro livro)
    {
        throw new NotImplementedException();
    }

    public Task<Livro> Criar(Livro livro)
    {
        throw new NotImplementedException();
    }

    public Task Deletar(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Livro> ObterLivroPorId(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Livro>> ObterTodosLivros()
    {
        throw new NotImplementedException();
    }
}
