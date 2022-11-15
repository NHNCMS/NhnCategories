using System.Linq.Expressions;

namespace NhnCommon.DataModel.Abstracts;

public interface IPersister<T>
{
    Task<T> GetById(Guid id);
    Task Insert(T dtoToInsert) ;
    Task Replace(T dtoToUpdate) ;
    Task UpdateOne(Guid id, Dictionary<string, object> propertiesToUpdate) ;

    Task<string>Delete(string id);
    Task DeleteMany(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter = null);

    T ConstructEntity();
}