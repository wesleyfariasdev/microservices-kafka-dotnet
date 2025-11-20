using LivroApi.Data.Repository;
using LivroApi.Domain;
using LivroApi.Dto.Request;
using LivroApi.Dto.Response;

namespace LivroApi.Services;

public class LivroServices(ILivroRepository livroRepository) : ILivroServices
{
    public async Task Atualizar(string id, Livro livro) =>
           await livroRepository.Atualizar(id, livro);

    public async Task<LivroResponseDto> Criar(LivroRequestDto livro) =>
           await livroRepository.Criar(new Livro(
           livro.Titulo,
           livro.Autor,
           livro.ISBN,
           livro.AnoPublicacao,
           livro.SituacaoLivro,
           livro.UsuarioId)).ContinueWith(livro => new LivroResponseDto
           {
               Id = livro.Result.Id,
               Titulo = livro.Result.Titulo,
               Autor = livro.Result.Autor,
               ISBN = livro.Result.ISBN,
               AnoPublicacao = livro.Result.AnoPublicacao,
               SituacaoLivro = livro.Result.SituacaoLivro,
               UsuarioId = livro.Result.UsuarioId
           });

    public async Task Deletar(string id) =>
           await livroRepository.Deletar(id);

    public async Task<LivroResponseDto> ObterLivroPorId(string id) =>
           await livroRepository.ObterLivroPorId(id).ContinueWith(_ => new LivroResponseDto
           {
               Id = id,
               Titulo = _.Result.Titulo,
               Autor = _.Result.Autor,
               ISBN = _.Result.ISBN,
               AnoPublicacao = _.Result.AnoPublicacao,
               SituacaoLivro = _.Result.SituacaoLivro,
               UsuarioId = _.Result.UsuarioId
           });

    public async Task<IEnumerable<LivroResponseDto>> ObterTodosLivros() =>
           await livroRepository.ObterTodosLivros().ContinueWith(task =>
           task.Result.Select(livro => new LivroResponseDto
           {
               Id = livro.Id,
               Titulo = livro.Titulo,
               Autor = livro.Autor,
               ISBN = livro.ISBN,
               AnoPublicacao = livro.AnoPublicacao,
               SituacaoLivro = livro.SituacaoLivro,
               UsuarioId = livro.UsuarioId
           }));
}
