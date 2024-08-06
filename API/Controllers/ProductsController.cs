using API.DTOs.Products;
using API.Handlers;
using APPLICATION.Persistence.Contracts;
using APPLICATION.Persistence.Specifications;
using APPLICATION.Persistence.Specifications.SpecModels;
using AutoMapper;
using DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        /// <summary>
        /// IProductRepository repository
        /// </summary>
        private readonly IGenericRepository<Product> repository;
        private IMapper mapper;

        public ProductsController(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            this.repository = genericRepository;
            this.mapper = mapper;
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
                data = products.Select(product => this.mapper.Map<Product, ProductDto>( product) ).ToList();
            }

            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            ISpecification<Product> specification = new ProductWithCategoriesAndBrandsSpecifications(id: id);

            var product = await this.repository.getByIdWithSpecificationAsync(specification);

            if(product == null)
            {
                return NotFound( new CodeErrorResponse(404));
            }

            var data = this.mapper.Map<Product, ProductDto>( product );

            return Ok(data);
        }

    }
}
