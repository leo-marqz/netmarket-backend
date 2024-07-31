
using APPLICATION.Persistence.Contracts;
using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Product> getProductByIdAsync(int id)
    {
        return await this.context.Products
            .Include(x=>x.Category)
            .Include(x=>x.Brand)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IReadOnlyList<Product>> getProductsAsync()
    {
        return await this.context.Products
            .Include(x=>x.Category)
            .Include(x=>x.Brand)
            .ToListAsync();
    }
}

