
using DOMAIN.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPLICATION.Persistence.Contracts;

public interface IProductRepository
{
    Task<Product> getProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> getProductsAsync();
}

