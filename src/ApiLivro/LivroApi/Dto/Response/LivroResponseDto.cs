using LivroApi.Domain;

namespace LivroApi.Dto.Response;

public sealed class LivroResponseDto
{
    public string Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoPublicacao { get; set; }
    public Situacao SituacaoLivro { get; set; }
    public Guid UsuarioId { get; set; }
}