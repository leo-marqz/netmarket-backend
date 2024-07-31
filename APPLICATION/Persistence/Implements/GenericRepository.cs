

using APPLICATION.Persistence.Contracts;
using DOMAIN.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPLICATION.Persistence.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
{
    private readonly ApplicationDbContext context;

    public GenericRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<T> addAsync(T entity)
    {
        await this.context.Set<T>().AddAsync(entity);
        await this.context.SaveChangesAsync();
        return entity;
    }

    public Task<T> deleteByIdAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IReadOnlyList<T>> getAllAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<T> getByIdAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<T> updateAsync(T entity)
    {
        throw new System.NotImplementedException();
    }
}

