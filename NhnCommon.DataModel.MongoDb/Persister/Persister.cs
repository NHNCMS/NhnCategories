using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using NhnCommon.DataModel.Abstracts;

namespace NhnCommon.DataModel.MongoDb.Persister;

public class Persister<T>:IPersister<T> where T:ModelBase
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly ILogger _logger;

    public Persister(IMongoDatabase mongoDatabase, ILoggerFactory loggerFactory)
    {
        _mongoDatabase = mongoDatabase;
        _logger = loggerFactory.CreateLogger(GetType());
    }
    
    public async Task<T> GetById(Guid id)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(MapToMongoDbCollectionName());

            var filter = Builders<T>.Filter.Eq(c => c.Id, id);
            return await collection.CountDocumentsAsync(filter) > 0
                ? (await collection.FindAsync(filter)).First()
                : throw new Exception($"No document found in {typeof(T).Name} with Id {id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public Task Insert(T dtoToInsert)
    {
        throw new NotImplementedException();
    }

    public Task Replace(T dtoToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOne(Guid id, Dictionary<string, object> propertiesToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<string> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMany(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public T ConstructEntity()
    {
        throw new NotImplementedException();
    }
    
    
    private static string MapToMongoDbCollectionName() 
    {
        return typeof(T).Name;
    }
}