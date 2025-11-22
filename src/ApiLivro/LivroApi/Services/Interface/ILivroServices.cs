using LivroApi.Domain;
using LivroApi.Dto.Request;
using LivroApi.Dto.Response;

namespace LivroApi.Services.Interface;

public interface ILivroServices
{
    Task<LivroResponseDto> Criar(LivroRequestDto livro);
    Task<LivroResponseDto> ObterLivroPorId(string id);
    Task<IEnumerable<LivroResponseDto>> ObterTodosLivros();
    Task Atualizar(string id, Livro livro);
    Task Deletar(string id);
}
