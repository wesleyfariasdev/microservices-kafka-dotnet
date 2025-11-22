using LivroApi.Data.Settings;
using LivroApi.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LivroApi.Data.DBMongoContext;

public sealed class DbContext
{
    private readonly IMongoDatabase _database;

    public DbContext(IOptions<MongoDbSettings> options)
    {
        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<Livro> Livros => _database.GetCollection<Livro>("livros");
    public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("usuarios");
}
