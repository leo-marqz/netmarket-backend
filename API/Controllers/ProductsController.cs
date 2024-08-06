using API.DTOs.Products;
using APPLICATION.Persistence.Contracts;
using APPLICATION.Persistence.Specifications;
using APPLICATION.Persistence.Specifications.SpecModels;
using DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// IProductRepository repository
        /// </summary>
        private readonly IGenericRepository<Product> repository;

        public ProductsController(IGenericRepository<Product> genericRepository)
        {
            this.repository = genericRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            List<ProductDto> data = null;
            ISpecification<Product> specification = new ProductWithCategoriesAndBrandsSpecifications();

            IReadOnlyList<Product> products = await this.repository.getAllWithSpecificationsAsync(specification);

            if(products == null)
            {
                data = new List<ProductDto>();
            }
            else
            {
                data = products.Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Stock = x.Stock,
                    Image = x.Image,
                    Price = x.Price,
                    Category = x.Category.Name,
                    Brand = x.Brand.Name

                }).ToList();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            ISpecification<Product> specification = new ProductWithCategoriesAndBrandsSpecifications(id: id);

            var product = await this.repository.getByIdWithSpecificationAsync(specification);

            if(product == null)
            {
                return NotFound();
            }

            var data = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Stock = product.Stock,
                Image = product.Image,
                Price = product.Price,
                Category = product.Category.Name,
                Brand = product.Brand.Name
            };

            return Ok(data);
        }

    }
}
