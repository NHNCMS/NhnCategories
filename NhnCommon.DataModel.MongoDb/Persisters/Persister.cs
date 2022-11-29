using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NhnCommon.DataModel.Abstracts;

namespace NhnCommon.DataModel.MongoDb.Persisters;

public sealed class Persister<T> : IPersister<T> where T : ModelBase
{
    private readonly IMongoDatabase _mongoDatabase;
    private readonly ILogger _logger;

    public Persister(IMongoDatabase mongoDatabase, ILoggerFactory loggerFactory)
    {
        _mongoDatabase = mongoDatabase;
        _logger = loggerFactory.CreateLogger(GetType());
    }

    public async Task<T> GetById(string id)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName()).AsQueryable();

            var results = await Task.Run(() => collection.Where(t => t.Id.Equals(id)));
            return await results.AnyAsync()
                ? results.First()
                : ConstructEntity();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task Insert(T dtoToInsert)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName());
            await collection.InsertOneAsync(dtoToInsert);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task Replace(T dtoToUpdate)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName());
            await collection.ReplaceOneAsync(x => x.Id == dtoToUpdate.Id, dtoToUpdate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task UpdateOne(string id, Dictionary<string, object> propertiesToUpdate)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName());

            var updateDefination = propertiesToUpdate
                .Select(dataField => Builders<T>.Update.Set(dataField.Key, dataField.Value)).ToList();
            var combinedUpdate = Builders<T>.Update.Combine(updateDefination);

            var updateResult = await collection.UpdateOneAsync(
                Builders<T>.Filter.Eq("_id", id),
                combinedUpdate);

            if (!updateResult.IsAcknowledged)
                throw new Exception($"Failed to Update {typeof(T).Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task Delete(string id)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName());
            var filter = Builders<T>.Filter.Eq("_id", id);
            await collection.FindOneAndDeleteAsync(filter);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task DeleteMany(Expression<Func<T, bool>> filter)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName());
            await collection.DeleteManyAsync(filter);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter = null)
    {
        try
        {
            var collection = _mongoDatabase.GetCollection<T>(GetCollectionName()).AsQueryable();

            return await Task.Run(() => filter != null
                ? collection.Where(filter)
                : collection);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    private static string GetCollectionName() => typeof(T).Name;

    public T ConstructEntity()
    {
        return (T) Activator.CreateInstance(typeof(T), true);
    }
}