
using DOMAIN.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPLICATION.Persistence.Contracts;

public interface IGenericRepository<T> where T : ModelBase
{
    Task<T> getByIdAsync(int id);
    Task<IReadOnlyList<T>> getAllAsync();
    Task<T> addAsync(T entity);
    Task<T> updateAsync(T entity);
    Task<T> deleteByIdAsync(int id);
}

