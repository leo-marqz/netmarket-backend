

using APPLICATION.Persistence.Contracts;
using APPLICATION.Persistence.Specifications;
using DOMAIN.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

    public async Task<T> deleteByIdAsync(int id)
    {
        var entity = await this.context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            throw new System.Exception("Entity not found");
        }

        this.context.Set<T>().Remove(entity);
        await this.context.SaveChangesAsync();

        return entity;
    }

    public async Task<IReadOnlyList<T>> getAllAsync()
    {
        return await this.context.Set<T>().ToListAsync();
    }

    

    public async Task<T> getByIdAsync(int id)
    {
        return await this.context.Set<T>().FindAsync(id);
    }

    

    public Task<T> updateAsync(T entity)
    {
        throw new System.NotImplementedException();
    }


    //-----------------------------------------------------------------------------
    //-----------------------------------------------------------------------------

    public async Task<T> getByIdWithSpecificationAsync(ISpecification<T> specification)
    {
        return await this.applySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> getAllWithSpecificationsAsync(ISpecification<T> specification)
    {
        return await this.applySpecification(specification).ToListAsync();
    }


    private IQueryable<T> applySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(this.context.Set<T>().AsQueryable(), specification);
    }

    public async Task<int> countAsync(ISpecification<T> especification)
    {
        return await this.applySpecification(especification).CountAsync();
    }
}

