using LivroApi.Data.DBMongoContext;
using LivroApi.Domain;
using MongoDB.Driver;

namespace LivroApi.Data.Repository;

public class LivroRepository(DbContext dbContext) : ILivroRepository
{
    public async Task Atualizar(string id, Livro livro)
    {
        var livroExistente = await ObterLivroPorId(id);
        if (livroExistente is null)
            throw new KeyNotFoundException("Livro não encontrado.");

        await dbContext.Livros.ReplaceOneAsync(l => l.Id == id, livro);
    }

    public async Task<Livro> Criar(Livro livro) =>
           await dbContext.Livros.InsertOneAsync(livro).ContinueWith(_ => livro);

    public async Task Deletar(string id) =>
           await dbContext.Livros.DeleteOneAsync(l => l.Id == id);

    public async Task<Livro> ObterLivroPorId(string id) =>
           await dbContext.Livros.Find(l => l.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Livro>> ObterTodosLivros() =>
           await dbContext.Livros.Find(_ => true).ToListAsync();
}
