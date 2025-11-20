using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LivroApi.Domain;

public sealed class Livro(string titulo,
                          string autor,
                          string iSBN,
                          int anoPublicacao,
                          Situacao situacaoLivro,
                          Guid usuarioId)
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; } = ObjectId.GenerateNewId().ToString();
    [BsonElement("titulo_livro")]
    public string Titulo { get; private set; } = titulo;
    [BsonElement("autor")]
    public string Autor { get; private set; } = autor;
    [BsonElement("isbn")]
    public string ISBN { get; private set; } = iSBN;
    [BsonElement("ano_publicacao")]
    public int AnoPublicacao { get; private set; } = anoPublicacao;
    [BsonElement("situacao_livro")]
    public Situacao SituacaoLivro { get; private set; } = situacaoLivro;

    public Usuario? Usuario { get; private set; }
    [BsonElement("usuario_id")]
    public Guid UsuarioId { get; private set; } = usuarioId;
}
