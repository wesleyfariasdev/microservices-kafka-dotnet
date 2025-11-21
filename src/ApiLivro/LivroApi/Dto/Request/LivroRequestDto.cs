using LivroApi.Domain;

namespace LivroApi.Dto.Request;

public sealed class LivroRequestDto
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoPublicacao { get; set; }
    public Situacao SituacaoLivro { get; set; }
    public Guid UsuarioId { get; set; }
}
