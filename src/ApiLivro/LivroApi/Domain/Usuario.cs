using MongoDB.Bson.Serialization.Attributes;

namespace LivroApi.Domain;

public sealed class Usuario(string nome,
                            string email,
                            bool isActive,
                            string passwordHash)
{
    [BsonId]
    [BsonElement("id_usuario")]
    public string Id { get; private set; }
    [BsonElement("nome")]
    public string Nome { get; private set; } = nome;
    [BsonElement("email")]
    public string Email { get; private set; } = email;
    [BsonElement("is_active")]
    public bool IsActive { get; private set; } = isActive;
    [BsonElement("password_hash")]
    public string PasswordHash { get; private set; } = passwordHash;

    public void Desativar() => IsActive = false;
    public void AlterarSenha(string newHash) => PasswordHash = newHash;
}