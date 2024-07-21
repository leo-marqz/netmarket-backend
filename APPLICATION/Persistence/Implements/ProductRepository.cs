
using APPLICATION.Persistence.Contracts;
using DOMAIN.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPLICATION.Persistence.Implements;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext context;

    public ProductRepository( ApplicationDbContext dbContext )
    {
        this.context = dbContext;
    }

    public Task<Product> getProductByIdAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> getProductsAsync()
    {
        throw new System.NotImplementedException();
    }
}

