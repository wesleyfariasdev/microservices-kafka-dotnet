using LivroApi.Data.Settings;
using LivroApi.Domain;
using MongoDB.Driver;

namespace LivroApi.Data.DBMongoContext;

public sealed class DbContext
{
    private readonly IMongoDatabase _database;

    public DbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<Livro> Livros => _database.GetCollection<Livro>("livros");
} 
